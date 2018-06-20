using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EbayScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.ebay.com/");

                IWebElement query = driver.FindElement(By.Name("_nkw"));

                query.SendKeys("xbox one");

                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                Console.WriteLine("Page title is: " + driver.Title);
            }
        }
    }
}
