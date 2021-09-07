
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CNC12.ViewModels
{
    public class VMContactWindow : BaseVM
    {

        private string _MailUserName;
        public string MailUserName { get => _MailUserName; set { _MailUserName = value; OnPropertyChanged(); } }

        private string _MailPassword;
        public string MailPassword { get => _MailPassword; set { _MailPassword = value; OnPropertyChanged(); } }

        private string _MailTitle;
        public string MailTitle { get => _MailTitle; set { _MailTitle = value; OnPropertyChanged(); } }

        private string _MailContent;
        public string MailContent { get => _MailContent; set { _MailContent = value; OnPropertyChanged(); } }

        public ICommand MailSendCommand { get; set; }
        public ICommand PasswordMailCommand { get; set; }
        public VMContactWindow()
        {
            MailSendCommand = new RelayCommand<object>((p) => { return true; }, (p) => { MailSend();  });
            PasswordMailCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => {  MailPassword = p.Password; });
        }
        void MailSend()
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(MailUserName, MailPassword);
                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(MailUserName, "tuannguyen1997bn@gmail.com", MailTitle.ToString(), MailContent.ToString());
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;
                client.Send(mm);
                MessageBox.Show("Send Email Successfully"); 
                MailTitle = null;
                MailUserName = null;
                MailPassword = null;
                MailContent = null;
            }
            catch 
            {
                MessageBox.Show("Wrong password or less secure apps access function is not allowed", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
