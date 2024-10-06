using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using PR3_mail_Belov.UsersСlasses;


namespace PR3_mail_Belov.UsersСlasses
{
    public class SendingEmail
    {
        private InfoEmail InfoEmail { get; set; }

        public SendingEmail(InfoEmail infoEmail)
        {
            InfoEmail = infoEmail
            ?? throw new ArgumentNullException(nameof(infoEmail));
        }

        public void Send()
        {
            // Добавляем обработку исключений 
            try
            {
                //Вносим адрес SMTP сервера
                SmtpClient mySmtpClient =
                    new SmtpClient(InfoEmail.SmtpClientAdress);

                // Задаём учётные данные пользователя
                mySmtpClient.UseDefaultCredentials = false;
                // Включаем ипользование портокола SSl
                mySmtpClient.EnableSsl = true;

                //Добавляем порт
                if (InfoEmail.Port != -1)
                    mySmtpClient.Port = InfoEmail.Port;

                // Задаём учётные данные пользователя
                NetworkCredential basicAuthenticationInfo = new
                   NetworkCredential(
                   InfoEmail.EmailAdressFrom.EmailAdress,
                   InfoEmail.EmailPassword);

                mySmtpClient.Credentials = basicAuthenticationInfo;

                // Добавляем адрес откуда отправлнено сообщение 
                MailAddress from = new MailAddress(
                InfoEmail.EmailAdressFrom.EmailAdress,
                InfoEmail.EmailAdressFrom.Name);
                // Добавляем адрес куда будет отправлнено сообщение 
                MailAddress to = new MailAddress(
                InfoEmail.EmailAdressTo.EmailAdress,
                InfoEmail.EmailAdressTo.Name);

                MailMessage myMail = new MailMessage(from, to);

                // Добавляем наш адрес в список адресов для ответа 
                MailAddress replyTo =
                    new MailAddress(InfoEmail.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);

                //Выбираем кодировку символов в письме
                //В нашем случае UTF8
                Encoding encoding = Encoding.UTF8;
                //Задаём значение Заголовка и его кодировку 
                myMail.Subject = InfoEmail.Subject;
                myMail.SubjectEncoding = encoding;

                // Задаём значение Сообщения и его кодировку 
                myMail.Body = InfoEmail.Body;
                myMail.BodyEncoding = encoding;

                // Отправляем письмо
                mySmtpClient.Send(myMail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
