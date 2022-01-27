using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System.Threading;

namespace TestProject1
{
    public class UnitTest1
    {


        [Fact]
        public void DownloadPictureTest()
        {
            //full method in AoiRequest
            ApiRequest.DownloadPicture("https://www.film.ru/sites/default/files/filefield_paths/cowboy_bebop.jpg");
        }

        [Fact]
        public void UploadPictureToSavepice()
        {
            
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://savepice.ru");
            Thread.Sleep(3000);
            RestClient client = new RestClient("https://savepice.ru");
            var reqToUpload = new RestRequest(Method.POST);
            reqToUpload.AddFile("", "/testPIC/igosha.jpg");
            IRestResponse response = client.Execute(reqToUpload);

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact]
        public void Aboba()
        {
            var headers = new Dictionary<string, string>
            {
                {"Content-type","application/json" }



            };
            var body = new Dictionary<string, string>
            {
                {"email","sindrian02@gmail.com" },
                { "password","192002ilya"}

            };

            IWebDriver driver = new ChromeDriver();


            //CAUTH
            var response = ApiRequest.SendAPIRequest(body, headers, "https://www.coursera.org/login?", Method.POST);
            var cookie = ApiRequest.ExtractCookie(response, "CSRF3-Token");
            var cookie2 = ApiRequest.ExtractCookie(response, "__204u");
            


            driver.Navigate().GoToUrl("https://www.coursera.org/");

            driver.Manage().Cookies.AddCookie(cookie);
            driver.Manage().Cookies.AddCookie(cookie2);
                   
            driver.Navigate().GoToUrl("https://www.coursera.org/");

            
            var header2 = new Dictionary<string, string>
            {
                {"CSRF3-Token","1644157800.FABNLqqrXJZp7w6u" },
                {"__204u","5323589985-1643293800736" }
            };

            var request2 = ApiRequest.SendAPIRequest(body, header2, "https://www.coursera.org/login?", Method.POST);

            Assert.Equal("OK", request2.StatusCode.ToString());
          
            
            
            
            

            //var body2 = new Dictionary<IRestResponse, string>
            //{
            //    {response, "CSRF3-Token" },
            //    {response, "__204u" }
            //};

            //var response2 = ApiRequest.SendAPIRequest(body2, headers, "https://www.coursera.org/login?", Method.POST);

           
            
        }
        
    }
}