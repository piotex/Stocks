using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gielda_calc
{
    public class Driver
    {
        public FirefoxDriver driver;

        public Driver()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(".", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe -private ";
            driver = new FirefoxDriver(service);
            string url = @"https://xtb.pl";
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }


    }
}
