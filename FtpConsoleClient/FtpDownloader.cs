using FluentFTP;
using System;
using System.IO;
using System.Net;

namespace FtpConsoleClient
{
    public class FtpDownloader
    {
        public FtpDownloader(FtpDownloadOptions options)
        {
            var host = options.Host;
            var credential = options.Credential;
            var localRootFolder = options.LocalPath;
            var remotePaths = options.RemotePaths;
            foreach (var remotePath in remotePaths)
            {
                Download(host, localRootFolder, remotePath, credential);
            }
        }

        private void Download(string host, string localRootFolder, string remotePath, NetworkCredential credential)
        {
            using (var ftp = new FtpClient(host, credential))
            {
                ftp.AutoConnect();
                ftp.Config.RetryAttempts = 10;
                var list = ftp.GetListing(remotePath);
                foreach (var item in list)
                {
                    Action<FtpProgress> progress = delegate (FtpProgress p)
                    {
                        if (p.Progress == 1)
                        {
                            //all done
                        }
                        else
                        {
                            //show progress
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(0, 4);
                            Console.Write("Current object: " + item.Name + new string(' ', Console.BufferWidth));
                            Console.SetCursorPosition(0, 5);
                            Console.Write("Downloading " + new string('\u2592', 25) + " "
                                + (int)p.Progress + "%" + " " + p.TransferSpeedToString() + " " + new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(12, 5);
                            Console.Write(new string('\u2588', (int)p.Progress / 4));
                        }
                    };

                    if (item.Type == FtpObjectType.File)
                    {
                        var localPath = localRootFolder + item.FullName.Replace('/', '\\');
                        var localDir = Directory.GetParent(localPath);
                        if (!Directory.Exists(localDir.FullName))
                        {
                            Directory.CreateDirectory(localDir.FullName);
                        }

                        ftp.DownloadFile(localPath, item.FullName, FtpLocalExists.Resume, FtpVerify.Retry, progress);
                    }
                    else if (item.Type == FtpObjectType.Directory)
                    {
                        var localPath = localRootFolder + item.FullName.Replace('/', '\\');
                        if (!Directory.Exists(localPath))
                        {
                            Directory.CreateDirectory(localPath);
                        }
                        ftp.DownloadDirectory(localPath, item.FullName, FtpFolderSyncMode.Update, FtpLocalExists.Resume, FtpVerify.Retry, null, progress);
                    }


                }
            }
        }
    }
}
