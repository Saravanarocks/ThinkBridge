using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebLoginTest
{
    public class ChromeWebdriver
    {
        public IWebDriver chromeWebDriver;
        public IWebDriver webdriverInitialization()
        {
            // Chrome driver initialization
            chromeWebDriver = new ChromeDriver();
            chromeWebDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(20);
            return chromeWebDriver;
        }


    }
}
