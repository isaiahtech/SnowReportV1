using HtmlAgilityPack;
using System;
using System.Text.RegularExpressions;

namespace SnowReportV1

{
    class Program
    {
        static void Main(string[] args)
        {
            // Create method here to Pull SnowReport data and write it to a CSV

            string filePath = @"D:\eMGP\csharp\Ski\SnowReportV1\SnowReportV1\mountain_data.csv";
            CsvReader reader = new CsvReader(filePath);

            Mountain[] mountains = reader.ReadFirstNMountains(3);

            HtmlWeb web = new HtmlWeb();
            HtmlDocument schweitzerDoc = web.Load("https://www.schweitzer.com/discover/conditions-report/");
            HtmlDocument mtspokaneDoc = web.Load("https://www.mtspokane.com/mountain-conditions/");
            HtmlDocument lookoutDoc = web.Load("https://skilookout.com/snow-report");

            // This Method will then read the CSV (after snowreport pulled) and print the mountain reports

            void PrintSnowReport(string mountainName, int mountainSnow)
            {
                Console.WriteLine(mountainName + "\n" + "24 HR Snow: " + mountainSnow + '"' + "\n");
            }

            // Schweitzer snow data

            HtmlNode schSnow = schweitzerDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div/div/div[3]/div/div/div/div/div[2]/div[2]/div[2]/div[2]/h2");
            int schTrim = int.Parse(Regex.Match(schSnow.InnerText, @"^\d+").Value);

            // Mt Spokane snow data

            HtmlNode spkSnow = mtspokaneDoc.DocumentNode.SelectSingleNode("/html/body/div/section/article/div/div/div[2]/div[2]/div/text()");
            int spkTrim = int.Parse(Regex.Match(spkSnow.InnerText.Trim(), @"^\d+").Value);

            // Lookout Pass snow data

            HtmlNode lookSnow = lookoutDoc.DocumentNode.SelectSingleNode("/html/body/section/div/div/div[2]/div/div[5]/div/div[2]/div[2]/p");
            int lookTrim = int.Parse(Regex.Match(lookSnow.InnerText, @"^\d+").Value);


            foreach (Mountain mountain in mountains)
            {
                string mtn = mountain.Name;
                switch (mtn)
                {
                    case "Schweitzer":
                        PrintSnowReport(mountain.Name, schTrim);
                        break;
                    case "Mt Spokane":
                        PrintSnowReport(mountain.Name, spkTrim);
                        break;
                    case "Lookout Pass":
                        PrintSnowReport(mountain.Name, lookTrim);
                        break;
                    default:
                        Console.WriteLine("Oops, nothing here");
                        break;
                }
            }

            Console.WriteLine("\nHit Enter to quit");
            Console.ReadLine();
        }
    }
}
