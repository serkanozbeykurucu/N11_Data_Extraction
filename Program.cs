using HtmlAgilityPack;
using System.Net;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        WebClient client = new WebClient();
        StringBuilder st = new StringBuilder();

        var pg = 1;
        var counter = 0;

        while (pg <= 1)
        {
            string url = "https://www.n11.com/bilgisayar/dizustu-bilgisayar?pg=" + pg;
            string htmlString = client.DownloadString(url);
            HtmlDocument htmlBelgesi = new HtmlDocument();
            htmlBelgesi.LoadHtml(htmlString);
            var selectedHtml = htmlBelgesi.DocumentNode.SelectNodes("//*[@id=\"listingUl\"]");

            foreach (var item in selectedHtml)
            {
                foreach (var innerItem in item.SelectNodes("li"))
                {
                    foreach (var div1 in innerItem.SelectNodes("div"))
                    {
                        foreach (var div2 in div1.SelectNodes("div"))
                        {
                            foreach (var h3 in div2.SelectNodes("a//h3"))
                            {
                                
                                    st.AppendLine(h3.InnerText); // gelen değeri ekle ve bir altsatıra geç v
                                
                            }
                        }
                    }
                }
                
            }
            pg++;
           
        }

        Console.WriteLine(st.ToString());
        Console.ReadKey();
    }
}