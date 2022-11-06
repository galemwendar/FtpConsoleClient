using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FtpConsoleClient
{
    public class FtpDownloadOptions
    {
        public string Host { get; set; }
        public string LocalPath { get; set; }
        public NetworkCredential Credential { get; set; }
        public List<string> RemotePaths { get; set; }

        /// <summary>
        /// Setup options for FtpDownloader
        /// </summary>
        /// <param name="path"></param>
        public FtpDownloadOptions(string path)
        {

            try
            {
                var settinfsFile = File.ReadAllLines(path).ToList();
                var username = string.Empty;
                var password = string.Empty;
                RemotePaths = new List<string>();
                foreach (string line in settinfsFile)
                {

                    if (line.StartsWith("host:"))
                    {
                        Host = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ElementAt(1);
                    }

                    if (line.StartsWith("user:"))
                    {
                        username = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ElementAt(1);

                    }

                    if (line.StartsWith("password:"))
                    {
                        password = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ElementAt(1);

                    }

                    if (line.Contains(":\\"))
                    {
                        LocalPath = line.Replace(" ", "");

                    }

                    if (line.StartsWith("/"))
                    {
                        RemotePaths.Add(line);
                    }
                }
                Credential = new NetworkCredential(username, password);
                if (string.IsNullOrEmpty(Host))
                {
                    throw new Exception("Host is empty");
                }

                if (string.IsNullOrEmpty(Credential.UserName))
                {
                    throw new Exception("Username is empty");
                }

                if (string.IsNullOrEmpty(Credential.Password))
                {
                    throw new Exception("Password is empty");
                }
                if (string.IsNullOrEmpty(LocalPath))
                {
                    throw new Exception("Local folder is empty");
                }

                if (!(RemotePaths.Count > 0))
                {
                    throw new Exception("Files to download is empty");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
