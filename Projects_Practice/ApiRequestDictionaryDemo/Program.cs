using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRequestDictionaryDemo {

    public class Demo {
        public string baseUrl = "https://google.com";
        public string requestUrl;

        public Dictionary<string, string> urlParams;
       public void SetPageSize(string pageSize) {
            urlParams = AddOrUpdate(urlParams, "PageSize", pageSize);
            UrlFormation(urlParams);
        }

        public void SetPageNumber(string pageNumber) {
            urlParams = AddOrUpdate(urlParams, "PageNumber", pageNumber);
            UrlFormation(urlParams);
        }

        Dictionary<string, string> AddOrUpdate(Dictionary<string, string> dic, string key, string newValue) {
            if (dic.ContainsKey(key))
                dic[key] = newValue;
            else
                dic.Add(key, newValue);

            return dic;
        }

        void UrlFormation(Dictionary<string, string> urlParams) {
            requestUrl = baseUrl;

            if (urlParams.Count > 1) {
                var first = urlParams.FirstOrDefault();
                requestUrl += $"?{first.Key}={first.Value}";

                for (var i = 1; i < urlParams.Count; i++) {
                    requestUrl += $"&{urlParams.ElementAt(i).Key}={urlParams.ElementAt(i).Value}";
                }
            }
            else {
                var first = urlParams.FirstOrDefault();
                requestUrl += $"?{first.Key}={first.Value}";
            }

            GetDate(requestUrl);
        }

        void GetDate(string urlRequest) {
            // http request ...
            Console.WriteLine(urlRequest);
            Console.ReadKey();
        }
    }

    class Program {
        static void Main(string[] args) {
            Demo demo = new Demo();
            demo.urlParams = new Dictionary<string, string>();
            demo.SetPageSize("2");
            demo.SetPageSize("4");
            demo.SetPageNumber("3");
            demo.SetPageSize("1");
            demo.SetPageNumber("8");
        }
    }
}
