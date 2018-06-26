using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EbayScrape
{
    class Program
    {
        static void Main(string[] args)
        {
            // the driver is the entire page
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.ebay.com/");

                // web element is one of the html elements on the page 
                IWebElement query = driver.FindElement(By.Name("_nkw"));

                query.SendKeys("xbox one");

                query.Submit();

                // Get <ul> element using xpath, back slashes are used to make sure quotes dont interfere
                var item =  driver.FindElement(By.XPath("//*[@id=\"srp-river-results\"]/ul"));
                // After getting list, get all elements in the list with <li> tag
                var listings = item.FindElements(By.TagName("li"));

                //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                // Just getting a list element directly
                var item2 = driver.FindElement(By.XPath("//*[@id='srp-river-results-listing1']"));

                // Print the text for each list element
                foreach (var ting in listings)
                {
                    Console.WriteLine(ting.Text);
                }

            }
        }
    }
}
