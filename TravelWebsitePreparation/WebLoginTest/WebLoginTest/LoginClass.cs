using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLoginTest
{
    public class LoginClass
    {
        public ChromeWebdriver chromewebDriver = new ChromeWebdriver();
        public IWebDriver webDriver;
        public List<string> languagesread = new List<string>();

        public string langDropdown = @"/html/body/div[1]/div[2]/section/div/div[2]/section/div/div[1]/span";
        public string English = @"ui-select-choices-row-1-0";
        public string Dutch = @"//div[@id='ui-select-choices-row-1-1']";
        public string userNametextboxID = "name";
        public string organizationTextBoxID = "orgName";
        public string emailTextBoxID = "singUpEmail";
        public string agreeCheckBox = @"/html/body/div[1]/div[2]/section/div/div[3]/div/section/div[1]/form/fieldset/div[4]/label/span";
        public string signUpButtonXpath = @"/html/body/div[1]/div[2]/section/div/div[3]/div/section/div[1]/form/fieldset/div[5]";
        public string signupMessageXpath = @"/html/body/div[1]/div[2]/section/div/div[3]/div/section/div[1]/form/div/span";

        public IWebElement langdropdownbutton => webDriver.FindElement(By.XPath(langDropdown));
        public IWebElement LangEnglish => webDriver.FindElement(By.Id(English));
        public IWebElement langDutch => webDriver.FindElement(By.XPath(Dutch));

        public IWebElement userNameTextBox => webDriver.FindElement(By.Id(userNametextboxID));
        public IWebElement emailTextBox => webDriver.FindElement(By.Id(emailTextBoxID));
        public IWebElement organizationTextBox => webDriver.FindElement(By.Id(organizationTextBoxID));
        public IWebElement agreeCheck => webDriver.FindElement(By.XPath(agreeCheckBox));

        public IWebElement signUpButton => webDriver.FindElement(By.XPath(signUpButtonXpath));

        public IWebElement signUpMessage => webDriver.FindElement(By.XPath(signupMessageXpath));



       // Method to Launch the browser and intitalize the wedDriver element
        public void launchBrowser()

        {
            webDriver = chromewebDriver.webdriverInitialization();
        }

        //Method to Navigate to URL specified
        public void NaviatetoUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        // Method to select language in the web page
        public void LanguageSelection()
        {
            ////select = new SelectElement(langdropdownbutton);
            langdropdownbutton.Click();

        }

        // Method to return list of languages available in the drop down
        public List<string> GetLanguages()
        {

            languagesread.Add(langDutch.GetAttribute("innerText"));
            languagesread.Add(LangEnglish.GetAttribute("innerText"));
            return languagesread;
        }

        // Method to sign up to the web page
        public void SignUp(string UserName, string organizationName, string email)
        {
            userNameTextBox.Click();
            userNameTextBox.SendKeys(UserName);
            organizationTextBox.Click();
            organizationTextBox.SendKeys(organizationName);
            emailTextBox.Click();
            emailTextBox.SendKeys(email);
            agreeCheck.Click();
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(signUpButtonXpath)));
            signUpButton.Click();
        }

        // Method to get the Signup message
        public string SignUpMessage()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(signupMessageXpath)));
            var test = signUpMessage.GetAttribute("innerText");
            return test;
        }
    }
}
