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
using System.Windows.Forms;

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

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Do you agree to the following?" +
                "\n" +
                "\n" +
                "- This program is purely for educational purposes" +
                "\n" +
                "- You will not use this program for any malicious purposes" +
                "\n" +
                "- Any damage caused by this program is not the creators responsibility" +
                "\n" +
                "- These are random images taken by people, because of this there may be gore, NSFW, obscene images, and more" +
                "\n" +
                "- Only continue if you don't mind seeing images as such" +
                "\n" +
                "\n" +
                "DO NOT CONTINUE USING THIS PROGRAM IF YOU DO NOT AGREE WITH THE ABOVE" +
                "\n" +
                "Any damage caused by the use of this application is in no way the responsibility of the creator." +
                "\n" +
                "\n" +
                "\n" +
                "\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("If you agree, please type the letter y" +
                "\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("If you don't agree, please type the letter n" +
                "\n" +
                "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Agree? (y/n): ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Console.Clear();
            }
            if (response == "n")
            {
                Console.Clear();
                Console.Write("You need to agree to the terms before using the application!");
                Thread.Sleep(-1);
            }
            if (response != "y")
            {
                if (response != "n")
                {
                    Console.Clear();
                    Console.Write("Please reopen the application and type ONLY n OR y");
                    Thread.Sleep(-1);
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Folder to store scraped images (Make sure it ends with \\ ): ");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(200);
            string folder = Console.ReadLine();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
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
                driver.Navigate().GoToUrl(link);
                try
                {
                    string filename = link.Replace("https://prnt.sc/", "\n");
                    var element = driver.FindElement(By.Id("screenshot-image"));
                    string imageSrc = element.GetAttribute("src");
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
