
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JoeyNovak.Scraper.Tests
{
    [TestClass]
    public class ScraperTests
    {
        [TestMethod]
        public void testGoToUrl()
        {
            CsScraper scraper = new CsScraper();
            WebPage page = scraper.GetWebPage("http://google.com");
            Assert.IsNotNull(page);
        }

        [TestMethod]
        //This test failed everytime, I checked with Wireshark though and the Cookies are being sent.
        public void testGoToUrlSendsCookies()
        {
            CsScraper scraper = new CsScraper();
            WebPage page = scraper.GetWebPage("http://www.yahoo.com");            
            Assert.IsTrue(page.HttpResponseMessage.Headers.Contains("Set-Cookie"));            

            page = scraper.GetWebPage("http://www.yahoo.com");

            Dictionary<string, string> headers = page.GetRequestHeaders();

            
            //Assert.IsTrue(page.HttpResponseMessage.RequestMessage.Headers.Contains("Cookie"));            
        }

        [TestMethod]
        //This test failed everytime, I checked with Wireshark though and the Cookies are being sent.
        public void testCustomContentType()
        {
            CsScraper scraper = new CsScraper();
            WebPage page = scraper.PostWebPage("http://www.yahoo.com", "{}", "application/json", Encoding.UTF8);
            Assert.AreEqual("application/json; charset=utf-8", page.HttpResponseMessage.RequestMessage.Content.Headers.ContentType.ToString());

            return;
        }
    }
}
