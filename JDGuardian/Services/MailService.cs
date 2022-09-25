using JDGuardian.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace JDGuardian.Services
{
    public static class MailService
    {
        public static MailSetting MailSetting { get; set; }
        private static SmtpClient smtpClient;
        private static SmtpClient SmtpClient
        {
            get
            {
                if(smtpClient == null)
                {
                    //指定smtp服务地址（根据发件人邮箱指定对应SMTP服务器地址）
                    SmtpClient client = new SmtpClient();//格式：smtp.126.com  smtp.164.com
                    smtpClient = client;
                    client.Host = MailSetting.Host;
                    //要用587端口
                    client.Port = 587;//端口
                                      //加密
                    client.EnableSsl = true;
                    //通过用户名和密码验证发件人身份
                    client.Credentials = new NetworkCredential(MailSetting.UserName, MailSetting.Password);
                }
                return smtpClient;
            }
        }

        public static bool SendMail(string to, string subject,string str)
        {
            if (MailSetting != null)
            {
                MailMessage mailMsg = new MailMessage();//实例化对象
                mailMsg.From = new MailAddress(MailSetting.Address, MailSetting.DisplayName);//源邮件地址和发件人
                mailMsg.To.Add(new MailAddress(to));//收件人地址
                mailMsg.Subject = subject;//发送邮件的标题
                mailMsg.Body = str;//发送邮件的内容
                try
                {
                    SmtpClient.Send(mailMsg);
                    return true;
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Console.WriteLine("未配置邮箱");
            }
            return false;
        }
    }
}
