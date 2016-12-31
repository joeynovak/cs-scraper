using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoeyNovak.Scraper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JoeyNovak.Scraper.Tests
{
   [TestClass]
    class ScraperTests
    {
      [TestMethod]
      public void testGoToUrl()
      {
         CsScraper scraper = new CsScraper();
         WebPage page = scraper.GetWebPage("http://example.com");         
         Assert.IsNotNull(page);
      }
    }
}
