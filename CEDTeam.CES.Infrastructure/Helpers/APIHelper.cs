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
        public static string lzdCookie = "_bl_uid=FgkCn4q8bpwceko77vpLmq8ysbsb; _lang=vi_VN; t_fv=1577370524252; t_uid=xDRHDEP0J7hjl3t5ZoYwjMpZFsVc7dS8; cna=4BuBFjtjWwgCAXRi0Oa9DZRg; hng=VN|vi|VND|704; lzd_cid=57c081fe-5bb6-48dc-9736-a99ea0139a3d; _ga=GA1.2.1850983755.1577562930; wfx_unq=V8oCa5cOmsuSG3Da; miidlaz=miid5hinju1duvevs4t3bfj; lzd_click_id=clk5h31do1e0qnf44oqpec; lzd_sid=171268ee7496fd1f39a63f3f3a29f5c3; _m_h5_tk=7a4af4512ba501ad9570fec0581949aa_1585409817915; _m_h5_tk_enc=b2dca0b2ee4be35a3bd27a5f8da7ffc0; _tb_token_=73ee456933ed6; _gid=GA1.2.1120841350.1585400925; t_sid=qXzDLB5BVAv7tbWaq2Po6SKmy8RHOTOf; utm_channel=NA; XSRF-TOKEN=8dacede2-c58a-419a-9ea6-77f116a55f31; smart_banner_exist=checked; cto_bundle=jiWNRl9PWjRtdjVjN2NLZGpoaUVacVpnJTJCVmtDYnFHbnBqMHZqTFdPbmlPc2NsUGNhRmlEUiUyQlFleE9pJTJGa1FOR3U4T2RqJTJCTGVFdUEyYlI3eWlYYTJJM1ZEN3IxUyUyRmxXcWRkQU9BYm1nSU1ENEJ0TFN2ZmlxbnpyckJxaGpOOU42MHpuNThqQ2h6QkYxSUJXQnFnb1dJRmdVNllwYVNpd1VkNHBYOWY4b09SVmY4SCUyRlklM0Q; utm_origin=https://icms.alibaba.com/recommend2.htm?language=en-SG&voyagerVersion=2&platform=m&is_tbc=0&xRegion=VN&pageNo=0&jsonBackup=false&debug=false&isbackup=true&terminalType=0&backupParams=language,regionID,jsonBackup&xLang=vi&position=top&appId=201711220; isg=BAIC_UVJ6KKDf_f7UX3WW8dMUwhk0wbt7lX0IUwbGXUgn6MZNGJ8_T-eT4PjyX6F; l=dBNmfAKHqq61z8pJBOCaKjzDVQbtpIRbou-4nE7yi_5CY686J9QOoyDRPFJ6cAWcMU8B4cjscS2TFe2bJyMZndLHRWN6INPWBef..; JSESSIONID=6C4F00C73AE878A9C669EB105CD48A57";
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
                //if (url.ToLower().Contains("lazada"))
                //{
                //    request.Headers.Add("Cookie", lzdCookie);
                //}
                //if (url.ToLower().Contains("shopee"))
                //{
                //    request.Headers.Add("if-none-match-", "55b03-6ebbd9dac9bda7d43f175f06ae72b999");
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
        public static T PostAsync<T>(string url, string postData, string contentType = "application/x-www-form-urlencoded", bool isAllowRedirect = false)
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
