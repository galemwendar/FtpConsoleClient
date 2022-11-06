using System;
using System.IO;
using System.Reflection;

namespace FtpConsoleClient
{
    internal class Program
    {
      
  
        static void Main(string[] args)
        {

            Console.Title = "Ftp Console Client";
            Console.WriteLine("Starting Ftp Console Client...");
            Console.WriteLine("Reading FtpConsoleClientSettings...");
            try
            {
                var options = new FtpDownloadOptions("FtpConsoleClientSettings.txt");
                Console.WriteLine("Read!");
                var downloader = new FtpDownloader(options);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("All done!");
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

    }
}
