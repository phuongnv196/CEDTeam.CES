using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CEDTeam.CES.Infrastructure.Helpers
{
    public class APIHelper
    {
        public static T GetAsync<T>(string url, bool isAllowRedirect = false)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                if (!isAllowRedirect) request.AllowAutoRedirect = false;
                request.Headers.Add("Upgrade-Insecure-Requests: 1");
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/66.4.120 Chrome/60.4.3112.120 Safari/537.36";
                request.Headers.Add("Accept-Language:vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
                var response = (HttpWebResponse)request.GetResponse();
                if (!HttpStatusCode.OK.Equals(response.StatusCode)) return default(T);
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var result = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(result)) return default(T);
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return default(T);
            }
        }
        public static T PostAsync<T>(string url, string postData,  string contentType = "application/x-www-form-urlencoded", bool isAllowRedirect = false)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                if (!isAllowRedirect) request.AllowAutoRedirect = false;
                request.Headers.Add("Upgrade-Insecure-Requests: 1");
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/66.4.120 Chrome/60.4.3112.120 Safari/537.36";
                request.Headers.Add("Accept-Language:vi-VN,vi;q=0.8,fr-FR;q=0.6,fr;q=0.4,en-US;q=0.2,en;q=0.2");
                Stream dataStream;
                request.ContentType = contentType;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Flush();
                dataStream.Close();
                var response = (HttpWebResponse)request.GetResponse();
                if (!HttpStatusCode.OK.Equals(response.StatusCode)) return default(T);
                dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                var result = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(result)) return default(T);
                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return default(T);
            }
        }
    }
}
