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
                        responseStream.DecryptStream(fs,login.GetKey());
                        //byte[] buffer = new byte[64];
                        //int size = 0;
                        //while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        //{
                        //    fs.Write(buffer, 0, size);
                        //}
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
                //byte[] fileContents = new byte[fs.Length];
                //fs.Read(fileContents, 0, fileContents.Length);
                //request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    //requestStream.Write(fileContents, 0, fileContents.Length);
                    fs.EncryptStream(requestStream, login.GetKey());
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.StatusCode;
                }
            }
        }

        public static List<string> GetFilesList(string address, string login, string password)
        {
            List<string> files = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);

            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(login, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            files.Add(reader.ReadLine());
                        }
                    }
                }
            }
            return files;
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
