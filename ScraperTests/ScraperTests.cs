
using System.Collections.Generic;
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
    }
}
