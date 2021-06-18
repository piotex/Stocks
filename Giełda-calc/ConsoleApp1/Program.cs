using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Gielda_calc;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            string comm =   "1- Get Html\n" +
                            "" +
                            "\n\n";
            while (true)
            {
                string command = "";
                Console.WriteLine(comm);
                command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case "1":
                        Console.WriteLine(driver.driver.FindElementsByName("body"));
                        break;
                    default:
                        break;
                }

            }

        }
        static void watch_only_in_good_time()
        {
            DateTime time = DateTime.Now;
            DateTime sleep_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, new Random().Next(1, 50), 0);
            DateTime watch_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, new Random().Next(1, 50), 0);

            while (time > sleep_time || time < watch_time)
            {
                Thread.Sleep(1 * 60 * 1000);
                time = DateTime.Now;
                sleep_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, new Random().Next(1, 50), 0);
                watch_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, new Random().Next(1, 50), 0);
            }
        }
        static void init(ref FirefoxDriver driver)
        {
            try
            {
                string url = @"https://www.facebook.com/messages/t/2679528882113434/";
                driver.Navigate().GoToUrl(url);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                //driver.FindElement(By.TagName("button")).Click();
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            }
            catch (Exception exxxx)
            {
                /*
                driver.Close();
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
                service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe -private ";
                driver = new FirefoxDriver(service);
                Thread.Sleep(1 * 60 * 1000);
                driver.Navigate().GoToUrl(@"https://www.youtube.com/");
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                Thread.Sleep(1 * 60 * 1000);
                */
                Console.WriteLine(exxxx);
            }
        }
        static void watch(ref FirefoxDriver driver, string url, int time)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(url);
            for (int j = 0; j < time; j++)
            {
                try
                {
                    By data2 = By.ClassName("ytp-large-play-button");
                    driver.FindElement(data2).Click();
                }
                catch (Exception) { }
                Thread.Sleep(1 * 60 * 1000);
            }
        }
    }
}

//driver.Manage().Window.Maximize();
//driver.get("http://demo.guru99.com/test/login.html");
//data = By.TagName("button");
