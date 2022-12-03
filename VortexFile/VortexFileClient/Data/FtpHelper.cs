using System.Net;

namespace VortexFileClient.Data
{
    internal static class FtpHelper
    {
        public static FtpStatusCode DownloadFile(string filename, string address, string login, string password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(login, password);
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        responseStream.DecryptStream(fs, login.GetKey(16));
                    }
                }
                return response.StatusCode;
            }
        }

        public static FtpStatusCode UploadFile(string filename, string address, string login, string password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(login, password);
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    fs.EncryptStream(requestStream, login.GetKey(16));
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.StatusCode;
                }
            }
        }

        public static List<string> GetFilesList(string address, string login, string password)
        {
            List<string> lines = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(login, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            lines.Add(reader.ReadLine());
                        }
                    }
                }
            }
            List<string> files = new List<string>();
            foreach (string line in lines)
            {
                string[] tokens =
                    line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[8];
                string permissions = tokens[0];

                files.Add(name + (permissions[0] == 'd' ? "/" : ""));
            }
            return files;
        }

        public static FtpStatusCode CreateDirectory(string address, string login, string password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);

            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(login, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusCode;
            }
        }

        public static FtpStatusCode DeleteDirectory(string address, string login, string password)
        {
            var listRequest = (FtpWebRequest)WebRequest.Create(address);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            var credentials = new NetworkCredential(login, password);
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (var listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (var listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    lines.Add(listReader.ReadLine());
                }
            }

            foreach (string line in lines)
            {
                string[] tokens =
                    line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[8];
                string permissions = tokens[0];

                string fileUrl = address + name;
                if (permissions[0] == 'd')
                {
                    DeleteDirectory(fileUrl + "/", login, password);
                }
                else
                {
                    var deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                    deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    deleteRequest.Credentials = credentials;

                    deleteRequest.GetResponse();
                }

            }

            var removeRequest = (FtpWebRequest)WebRequest.Create(address.Remove(address.Length - 1));
            removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
            removeRequest.Credentials = credentials;

            using (FtpWebResponse response = (FtpWebResponse)removeRequest.GetResponse())
            {
                return response.StatusCode;
            }
        }

        public static FtpStatusCode DeleteFile(string address, string login, string password)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);

            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(login, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusCode;
            }
        }
    }
}
