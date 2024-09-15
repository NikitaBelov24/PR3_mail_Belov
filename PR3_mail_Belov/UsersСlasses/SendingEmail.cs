using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace PR3_mail_Belov.UsersСlasses
{
    internal class SendingEmail
    {
        private InfoEmailSending InfoEmailSending {  get; set; }

        private SendingEmail(InfoEmailSending infoEmailSending)
        {
            InfoEmailSending = infoEmailSending
            ?? throw new ArgumentNullException(nameof(infoEmailSending));
        }
        public void Send()
        {
            try
            {
                SmtpClient mySmntClient = new SmtpClient(InfoEmailSending.SmtpClientAdress);
                mySmntClient.UseDefaultCredentials = false;
                mySmntClient.EnableSsl = true;

                NetworkCredential basicAuthenticationInfo = new NetworkCredential(InfoEmailSending.EmailAdressFrom.EmailAdress, InfoEmailSending.EmailPassword);

                mySmntClient.Credentials = basicAuthenticationInfo;

                MailAddress from = new MailAddress(InfoEmailSending.EmailAdressFrom.EmailAdress, InfoEmailSending.EmailAdressTo.Name);
                MailAddress to = new MailAddress(InfoEmailSending.EmailAdressFrom.EmailAdress, InfoEmailSending.EmailAdressTo.Name);

                MailMessage myMail = new MailMessage(from, to);

                MailAddress replyto = new MailAddress(InfoEmailSending.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyto);

                Encoding encoding = Encoding.UTF8;
                myMail.Subject = InfoEmailSending.Subject;
                myMail.SubjectEncoding = encoding;

                myMail.Body = InfoEmailSending.Body;
                myMail.BodyEncoding = encoding;

                mySmntClient.Send(myMail);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);

            }
        }
    }
}
