using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JoeyNovak.Scraper
{
   public class CsScraper
   {
      public void GoToUrl(string url)
      {

      }

      public async Task<WebPage> GetWebPageAsync(string url)
      {
         HttpClient httpClient = new HttpClient();
         HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url); 
         WebPage webPage = new WebPage();
         webPage.Body = await httpResponseMessage.Content.ReadAsStringAsync();     
         return webPage;
      }

      public WebPage GetWebPage(string url)
      {
         Task<WebPage> task = null;
         Task runningTask = Task.Run(() =>
         {
             task = GetWebPageAsync(url);
         });

         while(!runningTask.IsCompleted && !runningTask.IsCanceled && !runningTask.IsFaulted)
            Thread.Sleep(10);         
         
         return task.Result;
      }
   }
}
