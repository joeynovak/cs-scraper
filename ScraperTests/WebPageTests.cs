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
         WebPage webPage = scraper.GetWebPage("http://www.example.com");
         string[] headers = webPage.GetHeaders();
         Assert.IsNotNull(headers);
      }
   }
}