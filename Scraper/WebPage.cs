using System;
using System.Collections.Generic;
using System.Net.Http;

namespace JoeyNovak.Scraper
{
    public class WebPage
    {
        private readonly HttpResponseMessage _httpResponseMessage;
        public string Body { get; set; }

        public HttpResponseMessage HttpResponseMessage
        {
            get { return _httpResponseMessage; }
        }

        public WebPage(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;            
        }

        public Dictionary<string, string> GetResponseHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            foreach (var header in HttpResponseMessage.Headers)
            {
                headers[header.Key] = String.Join(";", header.Value);
            }
            return headers;
        }

        public Dictionary<string, string> GetRequestHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            foreach (var header in HttpResponseMessage.RequestMessage.Headers)
            {
                headers[header.Key] = String.Join(";", header.Value);
            }
            return headers;
        }
    }
}