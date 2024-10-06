using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3_mail_Belov.UsersСlasses
{
    public class InfoMailRu : InfoEmail
    {
        public InfoMailRu(StringPair emailAdressTo, string subject, string body)
            : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.mail.ru";
            EmailAdressFrom = new StringPair("belovnikita-2403@mail.ru", "Белов Никита");
            EmailPassword = "wwPqRivZbAjJz1s1e83d";
            Port = -1;
        }
    }
}
