using AE.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLoginTest.Utilities
{
    public class Mailcheck
    {
        public string YourUserName = "Saravanarocks@gmail.com";
        public string Password = "kyllimrrbmpogtxb";
        public ImapClient IC;
        // Method to connect to the gmail account to verify whether mail is received. Subject is verified 
        public bool Mailavailable()
        {
            try
            {
                IC = new ImapClient("imap.gmail.com", YourUserName, Password, AuthMethods.Login, 993, false);
                IC.SelectMailbox("INBOX");
                var Email = IC.GetMessage(0);
                var searchresult = IC.Search(SearchCondition.Subject("Hello Saravana"));
                if (searchresult.Count() > 0)
                {
                    return true;
                }
            }

            catch (Exception e)
            {

            }
            return false;
        }

    }
}