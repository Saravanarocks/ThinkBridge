using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebLoginTest.Utilities;

namespace WebLoginTest
{
    [TestClass]
    public class UnitTest1
    {
        public LoginClass login = new LoginClass();
        List<String> Languages = new List<string> { "English", "Dutch" };
        List<String> LanguagesRead = new List<string>();
        public string signupMessage = @"A welcome email has been sent. Please check your email.";
        public Mailcheck mailcheckutilities = new Mailcheck();
        [TestMethod]
        public void Login_Verify_Languages()
        {
            login.launchBrowser();
            login.NaviatetoUrl("http://jt-dev.azurewebsites.net/#/SignUp");
            login.LanguageSelection();
            LanguagesRead = login.GetLanguages();
            var test = IsLanguagesAvailable(LanguagesRead);
            Assert.IsTrue(IsLanguagesAvailable(LanguagesRead), "Language is not available");
        }

        [TestMethod]
        public void SignUp_Validate_Email()
        {
            login.launchBrowser();
            login.NaviatetoUrl("http://jt-dev.azurewebsites.net/#/SignUp");
            login.SignUp("Saravana", "Saravana", "saravanarocks@gmail.com");           
            Assert.IsTrue(IsMailSent(signupMessage), "Mail is not sent to the mai ID");
            // At present the mail id and password is hardcorded to verify the mail. Third party mock shall be used to verify this scenario.
            Assert.IsTrue(mailcheckutilities.Mailavailable(), "Mail is received in the gmail");

        }

        [TestCleanup]
        public void testClean()
        {
            if (login.webDriver != null)
            {
                login.webDriver.Close();
                login.webDriver.Quit();
            }

        }
        private bool IsLanguagesAvailable(List<string> languagesread)
        {
            int count = 0;
            foreach (var lang in Languages)
            {
                foreach (var lang1 in languagesread)
                {
                    if (lang.ToString() == lang1.ToString())
                    {
                        count = count + 1;
                    }
                }

            }
            return (count == 2) ? true : false;
        }

        private bool IsMailSent(string signupMessage)
        {
            var test = login.SignUpMessage();
            if( String.Equals(signupMessage,test))
            {
                return true;
            }
            return false;
        }
    }
}
