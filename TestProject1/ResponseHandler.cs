using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TestProject1
{
    public class ResponseHandler
    {
        public string Handler(string codeStatus)
        {
            //RestClient client = new RestClient(url);
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            var handlr = new Dictionary<string, string>
            {
                //{"",""}
                {"Continue","101"},
                {"Switching protocols","102"},
                {"Early hints","103"},
                {"OK","200"},
                {"Created","201"},
                {"Accepted","202"},
                {"Non-Authoritative Information","203"},
                {"No Content","204"},
                {"Reset Content","205"},
                {"Partial Content","206"},
                {"Multiple Choices","300"},
                {"Moved Permanntly","301"},
                {"Moved Temporarily","302"},
                {"See Other", "303"},
                {"Not Modified","304"},
                {"Temporary Redirected","307" },
                {"Permanent Redirect","308"},
                {"Bad Request","400"},
                {"Unauthorized","401"},
                {"Forbidden","403"},
                {"Not found","404"},
                {"Method not allowed","405"},
                {"Not Acceptable","406"},
                {"Internal Server Error","500"},
                {"Not Implemented","501"},
                {"Bad Gateway","502"},
                {"Service Unavailable","503"},
                {"Gateway Timeout","504"},
                {"HTTP Version Not Supported","505" },
                { "Network Authentication Required","511"}         

            };
           
            foreach (var status in handlr)
            {
                if(codeStatus == status.Key)
                {
                    return status.Value;
                }
            }
            return "";
        }
    }
}
