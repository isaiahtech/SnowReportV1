using HtmlAgilityPack;
using System;

namespace SnowReportV1
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument schweitzerDoc = web.Load("https://www.schweitzer.com/discover/conditions-report/");
            HtmlDocument mtspokaneDoc = web.Load("https://www.mtspokane.com/mountain-conditions/");
            HtmlDocument lookoutDoc = web.Load("https://skilookout.com/snow-report");

            // Schweitzer recent snow sch

            HtmlNode schTime = schweitzerDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div/div/div[3]/div/div/div/div/div[2]/div[2]/div[2]/div[2]/h5");
            HtmlNode schSnow = schweitzerDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div/div/div[3]/div/div/div/div/div[2]/div[2]/div[2]/div[2]/h2");
            Console.WriteLine("Schweitzer...\n" + schTime.InnerHtml + " Snow: " + schSnow.InnerText + "\n");

            // Mt Spokane recent snow spk

            HtmlNode spkSnow = mtspokaneDoc.DocumentNode.SelectSingleNode("/html/body/div/section/article/div/div/div[2]/div[2]/div/text()");
            Console.WriteLine("Mt Spokane...\n" + "24 HR Snow: " + spkSnow.InnerText.Trim() + "\"\n");

            // Lookout Pass recent snow look

            HtmlNode lookSnow = lookoutDoc.DocumentNode.SelectSingleNode("/html/body/section/div/div/div[2]/div/div[5]/div/div[2]/div[2]/p");
            Console.WriteLine("Lookout Pass...\n" + "24 HR Snow: " + lookSnow.InnerHtml);

            Console.WriteLine("\n\nHit Enter to quit");
            Console.ReadLine();
        }
    }
}
