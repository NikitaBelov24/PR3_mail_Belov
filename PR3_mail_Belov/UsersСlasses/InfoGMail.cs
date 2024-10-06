using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR3_mail_Belov.UsersСlasses;

namespace PR3_mail_Belov.UsersСlasses
{
    public class InfoGMail : InfoEmail
    {
        public InfoGMail(StringPair emailAdressTo, string subject, string body) 
            : base(emailAdressTo, subject, body)
        { 
            SmtpClientAdress = "smtp.gmail.com";
            EmailAdressFrom = new StringPair("is25belovnv@artcollege.ru", "Белов Никита");
            EmailPassword = "xiwh zpcy bbwd gqln";
            Port = 587;
        }
    }
}
