namespace JDGuardian.Helpers
{
    public static class HttpHelper
    {
        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数json</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostJsonAsync(string url, string data, Dictionary<string, string> header = null)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpContent content = new StringContent(data);
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static async Task<string> PostAsync(string url, Dictionary<string, string> form)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            HttpContent content = new FormUrlEncodedContent(form);
            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 使用get方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string> header = null)
        {
            HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false });
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Mobile Safari/537.36");
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
