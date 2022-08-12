using System.Net;

namespace APIRateLimiter.Mocking
{
    public interface IFileManager
    {
        void DownloadFile(string url, string path);
    }
    public class FileManager : IFileManager
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
    public class InstallerHelper
    {
        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                var file = new FileManager();

                var destinationPath = "c://Test";
                var url = string.Format("http://example.com/{0}/{1}", customerName, installerName);

                file.DownloadFile(url, destinationPath);

                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }
    }
}
