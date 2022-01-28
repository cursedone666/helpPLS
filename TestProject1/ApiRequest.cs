using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestProject1
{
    public class ApiRequest
    {
        public static IRestResponse SendAPIRequest(object body, Dictionary<string, string> headers, string url, Method type)
        {
            RestClient client = new RestClient(url)
            {
                Timeout = 300000
            };

            RestRequest request = new RestRequest(type);

            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            if (!headers.Any(h => h.Value.Contains("appllication/json")))
            {
                foreach(var data in (Dictionary<string, string>)body){
                    request.AddParameter(data.Key,data.Value);
                }
            }
            else
            {
                request.AddJsonBody(body);

                request.RequestFormat = DataFormat.Json;
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        public static Cookie ExtractCookie(IRestResponse response, string cookieName)
        {
            Cookie res = null;
            foreach (var cookie in response.Cookies)
            {
                if (cookie.Name.Equals(cookieName))
                {
                    res = new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null);
                }
            }
            return res;
        }

        public static List<Cookie> ExtractAllCookies(IRestResponse response)
        {
            List<Cookie> res = new List<Cookie>();
            foreach(var cookie in response.Cookies)
            {
                res.Add(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null));
            }
            return res;
        }

        public static void DownloadPicture(string url)
        {
            RestClient client = new RestClient(url);

            var pictureResponse = new RestRequest(Method.GET);

            byte[] result = client.DownloadData(pictureResponse);
            //downloads to drive where's Studio installed
            File.WriteAllBytes(Path.Combine("/testPIC", "test1.jpg"), result); 
        }

       

        
    }
}
