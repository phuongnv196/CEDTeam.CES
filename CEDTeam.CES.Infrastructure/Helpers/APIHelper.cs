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
        public static string lzdCookie = "lzd_cid=1ea65e71-561a-4e2f-aa45-3b680fab7b3a; t_uid=1ea65e71-561a-4e2f-aa45-3b680fab7b3a; lzd_sid=1b689c4da36c57ac981964c0e51a9ea4; _m_h5_tk=cfcbf9e935fecdb13542cc2951fa7951_1574519233170; _m_h5_tk_enc=693efec50af8b547bd6ee685dbbbc4c0; hng=VN|vi|VND|704; userLanguageML=vi; _tb_token_=6e1b863b65fe; _bl_uid=6RkIL3CabOvj1vtbh8Xyt78fzs2y; t_fv=1574512034578; t_sid=b8Jh1PVI0mqrLODOcC8HsiCmaHyL2Cyn; utm_channel=NA; cna=ohNgFg7qVhACAXG5bU5ktqJK; cto_lwid=1e98a2ae-241a-489a-b39b-e701d916404b; _fbp=fb.1.1574512040358.1738583968; isg=BD8_wWw0Xq-4BFqz5JvQ9T68zhPJJJPGCLJL1dEMO-4R4F5i2fVKFmaxIui7n2s-; l=dBjW5ZUrqWFtxf3pBOfZourza77OqIRb81VzaNbMiICPOkCHkR01WZp6JmTMCnMNnsNWR3Jt3efYBY8nRyUIQVQ1pHPQ1dbZudLh.; x5sec=7b22617365727665722d6c617a6164613b32223a223339363565666235333361303932333931663464653866303666316562663139434c334c354f3446454f477a374d2b377175477147773d3d227d;";
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
                //if(url.ToLower().Contains("lazada"))
                //{
                //    request.Headers.Add("Cookie", lzdCookie);
                //}
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
