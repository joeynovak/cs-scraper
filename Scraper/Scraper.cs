using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JoeyNovak.Scraper
{
    public class CsScraper
    {
        private HttpClient _httpClient = null;
        private CookieContainer _cookieContainer = new CookieContainer();

        public CsScraper()
        {
            _httpClient = new HttpClient(
                new HttpClientHandler()
                {
                    AllowAutoRedirect = true,
                    UseCookies = true,
                    CookieContainer = _cookieContainer
                }
            );
        }

        public async Task<WebPage> GetWebPageAsync(string url)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(url));            
            ImpersonateChrome(httpRequestMessage);

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
            
            WebPage webPage = new WebPage(httpResponseMessage);            
            webPage.Body = await httpResponseMessage.Content.ReadAsStringAsync();
                        
            return webPage;
        }

        private void ImpersonateChrome(HttpRequestMessage httpResponseMessage)
        {
            httpResponseMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            httpResponseMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            httpResponseMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            httpResponseMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            httpResponseMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            httpResponseMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("sdch"));

            httpResponseMessage.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36");
        }

        public WebPage GetWebPage(string url)
        {
            Task<WebPage> task = null;
            task = GetWebPageAsync(url);

            task.Wait();

            return task.Result;
        }

        public async Task<WebPage> PostWebPageAsync(string url, Dictionary<string, string> data)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            httpRequestMessage.Content = new FormUrlEncodedContent(data);

            ImpersonateChrome(httpRequestMessage);            
            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            WebPage webPage = new WebPage(httpResponseMessage);
            webPage.Body = await httpResponseMessage.Content.ReadAsStringAsync();

            return webPage;
        }

        public CookieCollection GetCookiesForUrl(string url)
        {
            return _cookieContainer.GetCookies(new Uri(url));
        }
    }
}
