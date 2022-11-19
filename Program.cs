using HtmlAgilityPack;
using System.Net;

public class Program
{
    private static void Main(string[] args)
    {
        WebClient client = new WebClient();
        var pg = 1;
        var counter = 0;

        while (pg <= 1)
        {
            string url = "https://www.n11.com/bilgisayar/dizustu-bilgisayar?pg=" + pg;
            string htmlString = client.DownloadString(url);
            HtmlDocument htmlBelgesi = new HtmlDocument();
            htmlBelgesi.LoadHtml(htmlString);
            HtmlNodeCollection test = htmlBelgesi.DocumentNode.SelectNodes("//*[@class=\"columnContent\"]/div/a/h3");
            foreach (var item in test)
            {
                counter++;
                Console.WriteLine(counter + " - " + item.InnerText);
            }
            pg++;
        }

        Console.ReadKey();
    }
}