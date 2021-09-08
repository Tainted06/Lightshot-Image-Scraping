using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Net;

namespace Prnt_Scr_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mass Image Downloader (Needs chrome to be installed) | By: Tainted | https://github.com/Tainted06/Lightshot-Image-Scraping";
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "chromedriver.exe"))
                { }
            else
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://cdn.discordapp.com/attachments/847195756107399170/884423529007837224/chromedriver.exe", AppDomain.CurrentDomain.BaseDirectory + "chromedriver.exe");
                }
            }

            /*Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Folder to store scraped images:");
            Console.ForegroundColor = ConsoleColor.White;
            string folder = Console.ReadLine();*/
            string folder = @"Z:\Projects\img\take2\";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Amount of images to scrape:");
            Console.ForegroundColor = ConsoleColor.White;
            string amount = Console.ReadLine();

            int e = Int32.Parse(amount);
            for (int i = 0; i < e; i++)
            {
                var random = new Random();
                var letter = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z", "w" };
                var number = new List<string> { "1", "2", "3", "4", "6", "5", "7", "8", "9", "0" };
                int c1 = random.Next(number.Count);
                int c2 = random.Next(number.Count);
                int c3 = random.Next(letter.Count);
                int c4 = random.Next(letter.Count);
                int c5 = random.Next(letter.Count);
                int c6 = random.Next(letter.Count);
                string link = "https://prnt.sc/" + number[c1] + number[c2] + letter[c3] + letter[c4] + letter[c5] + letter[c6];
                IWebDriver driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                Console.WriteLine(link);
                driver.Navigate().GoToUrl(link);
                try
                {
                    string filename = link.Replace("https://prnt.sc/", "");
                    var element = driver.FindElement(By.Id("screenshot-image"));
                    string imageSrc = element.GetAttribute("src");
                    Console.WriteLine(imageSrc);
                    string extension = Path.GetExtension(imageSrc);
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(imageSrc, folder+filename+extension);
                    }
                }
                catch { }
                driver.Close();
                driver.Quit();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done!");
            Thread.Sleep(-1);
        }
    }
}
