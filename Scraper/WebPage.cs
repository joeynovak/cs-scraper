namespace JoeyNovak.Scraper
{
    public class WebPage
    {
       public string Body { get; set; }

       public string[] GetHeaders()
       {
          return new string[0];
       }
    }
}