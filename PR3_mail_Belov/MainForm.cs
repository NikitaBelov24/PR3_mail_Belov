using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PR3_mail_Belov.UsersСlasses;
using static PR3_mail_Belov.UsersСlasses.InfoEmail;

namespace PR3_mail_Belov
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxMail.Text = "task_code_development@list.ru";
            textBoxName.Text = "Белов Никита";
            comboBoxService.SelectedIndex = 0;
        }

        private bool IsNullOrWhiteSpaceTextBox()
        {
            if (string.IsNullOrWhiteSpace(textBoxMail.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return true;
            }
            return false;
        }

        private void TextBoxIsCleaning()
        {
            DialogResult result = MessageBox.Show("Очистить поля ввода?", "Сообщение",
                MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
                foreach (TextBox textBox in Controls.OfType<TextBox>())
                    textBox.Text = "";
            
        }

        private InfoEmail SetInfoEmail(EmailsTypes type)
        {
            StringPair toInfo = new StringPair(textBoxMail.Text, textBoxName.Text);
            string subject = textBox2.Text;
            string body = $"{DateTime.Now} \n" + 
                $"{Dns.GetHostName()} \n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                $"{textBox4.Text}";
            if (type == EmailsTypes.GMail)
                return new InfoGMail(toInfo, subject, body);
            else
                return new InfoMailRu(toInfo, subject, body);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsNullOrWhiteSpaceTextBox())
                return;
            try
            {
                SendingEmail sendingEmail = new SendingEmail(
                    SetInfoEmail(
                        comboBoxService.SelectedItem.ToString() == "GMail" ?
                        EmailsTypes.GMail :
                        EmailsTypes.MailRu));
                sendingEmail.Send();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Письмо отправлено!");
            TextBoxIsCleaning();
        }
    }
}
