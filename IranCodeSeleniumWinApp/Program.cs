using System;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IranCodeSeleniumWinApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            ChromeOptions options2 = new ChromeOptions();
            options.AddArgument(@"user-data-dir=C:\Users\ym\AppData\Local\Google\Chrome\User Data\Default");
            options.AddArgument("--log-level=3");
            options.AddArgument("headless");
            options2.AddArgument("--log-level=3");
            options2.AddArgument(@"user-data-dir=C:\Users\ym\AppData\Local\Google\Chrome\User Data\Default");
            

            IWebDriver driver = new ChromeDriver(options);

            var ncid = driver.FindElements(By.ClassName("productLink"));
            var dtl = driver.FindElements(By.ClassName("more"));
            int page = 1;
            //driver2.Url = $"http://192.168.10.250/CodingTree.Aspx";
            IWebDriver driver2 = new ChromeDriver(options2);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter IRANCODE url:");
                var url = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Start...");
                driver2.Url = $"http://192.168.10.247:5000/";

                do
                {
                    driver.Url = $"{url}{page}";

                    ncid = driver.FindElements(By.ClassName("productLink"));
                    dtl = driver.FindElements(By.ClassName("more"));

                    int j = 0;
                    for (int i = 0; i < ncid.Count; i++)
                    {

                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeSeparator")).Clear();
                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeSeparator")).SendKeys("-");


                        var t = ncid[i].Text.Substring(7);
                        var t2 = t.Insert(4, "-");
                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeCode")).Clear();
                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeCode")).SendKeys(t2);


                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeName")).Clear();
                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeName")).SendKeys(dtl[j].Text);


                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeNameEN")).Clear();
                        driver2.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCoodingTreeNameEN")).SendKeys(dtl[j + 1].Text);

                        j = j + 2;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Inserting Complete");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter a key to continue: ");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Inserting Product please wait...");

                        //LogAsync(ncid[i].Text).Wait();
                        //LogAsync(dtl[j].Text).Wait();
                        //LogAsync(dtl[j + 1].Text).Wait();
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Changing page, it take long a bit more...");

                    page++;

                } while (ncid.Count > 0);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All products has been inserted succussfully. Start by new url...");
            }
            
        }

        //private async static Task LogAsync(string text)
        //{
        //    using (StreamWriter writetext = new StreamWriter("log.txt", true))
        //    {
        //        await writetext.WriteLineAsync(text);
        //    }
        //}
    }
}
