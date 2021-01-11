using HtmlAgilityPack;
using System;
using System.Text.RegularExpressions;

namespace SnowReportV1

{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\eMGP\csharp\Ski\SnowReportV1\SnowReportV1\mountain_data.csv";
            CsvReader reader = new CsvReader(filePath);

            Mountain[] mountains = reader.ReadFirstNMountains(3);

            HtmlWeb web = new HtmlWeb();
            HtmlDocument schweitzerDoc = web.Load("https://www.schweitzer.com/discover/conditions-report/");
            HtmlDocument mtspokaneDoc = web.Load("https://www.mtspokane.com/mountain-conditions/");
            HtmlDocument lookoutDoc = web.Load("https://skilookout.com/snow-report");

            // Testing Method to pull data from CSV and refactor code

            void PrintSnowReport(string mountainName, int mountainSnow)
            {
                Console.WriteLine(mountainName + "\n" + "24 HR Snow: " + mountainSnow + '"' + "\n");
            }

            PrintSnowReport("Alta", 60);

            // Schweitzer recent snow sch

            HtmlNode schSnow = schweitzerDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div/div/div[3]/div/div/div/div/div[2]/div[2]/div[2]/div[2]/h2");
            int schTrim = int.Parse(Regex.Match(schSnow.InnerText, @"^\d+").Value);
            Console.WriteLine("Schweitzer...\n" + "24 HR Snow: " + schTrim + '"' + "\n");

            // Mt Spokane recent snow spk

            HtmlNode spkSnow = mtspokaneDoc.DocumentNode.SelectSingleNode("/html/body/div/section/article/div/div/div[2]/div[2]/div/text()");
            int spkTrim = int.Parse(Regex.Match(spkSnow.InnerText.Trim(), @"^\d+").Value);
            Console.WriteLine("Mt Spokane...\n" + "24 HR Snow: " + spkTrim + '"' + "\n");

            // Lookout Pass recent snow look

            HtmlNode lookSnow = lookoutDoc.DocumentNode.SelectSingleNode("/html/body/section/div/div/div[2]/div/div[5]/div/div[2]/div[2]/p");
            int lookTrim = int.Parse(Regex.Match(lookSnow.InnerText, @"^\d+").Value);
            Console.WriteLine("Lookout Pass...\n" + "24 HR Snow: " + lookTrim + '"' + "\n");


            foreach (Mountain mountain in mountains)
            {
                Console.WriteLine($"{mountain.Name}, {mountain.State}");
            }

            Console.WriteLine("\nHit Enter to quit");
            Console.ReadLine();
        }
    }
}
