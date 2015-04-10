using System.IO;
using System.Net;
using System.Text;

namespace PremiumMigration.Components
{
    internal class WebRequestHandler
    {
        public WebRequestHandler()
        {
            Cookies = new CookieContainer();
        }

        public CookieContainer Cookies { get; private set; }

        public string ExecutePost(string url, string postData = null, bool autoRedirect = false)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = autoRedirect;
            request.CookieContainer = Cookies;

            if (!string.IsNullOrWhiteSpace(postData))
            {
                var data = Encoding.ASCII.GetBytes(postData);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }

            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }

            return null;
        }

        public string ExecuteGet(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = Cookies;

            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }

            return null;
        }

        public void ClearCookies()
        {
            Cookies = new CookieContainer();
        }
    }
}
