using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JoeyNovak.Scraper.Tests
{
   [TestClass()]
   public class WebPageTests
   {
      [TestMethod()]
      public void GetHeadersTest()
      {
         CsScraper scraper = new CsScraper();
         WebPage webPage = scraper.GetWebPage("https://www.yahoo.com");
         Dictionary<string, string> headers = webPage.GetResponseHeaders();
         Assert.IsNotNull(headers);
      }
   }
}