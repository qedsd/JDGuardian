using System.Net;
using System.Net.Mail;
using System.Text;

namespace JDGuardian.Helpers
{
    public static class MailHelper
    {
        /// <summary>
        /// 邮件发送通知
        /// </summary>
        /// <param name="str"></param>
        public static void SendMail(string to, string str)
        {
            MailMessage mailMsg = new MailMessage();//实例化对象
            mailMsg.From = new MailAddress("2116805395@qq.com", "QEDSD_bot");//源邮件地址和发件人
            mailMsg.To.Add(new MailAddress(to));//收件人地址
            mailMsg.Subject = "JDGuardian";//发送邮件的标题
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            mailMsg.Body = sb.ToString();//发送邮件的内容
            //指定smtp服务地址（根据发件人邮箱指定对应SMTP服务器地址）
            SmtpClient client = new SmtpClient();//格式：smtp.126.com  smtp.164.com
            client.Host = "smtp.qq.com";
            //要用587端口
            client.Port = 587;//端口
            //加密
            client.EnableSsl = true;
            //通过用户名和密码验证发件人身份
            client.Credentials = new NetworkCredential("2116805395@qq.com", "bcbydpgwikaybfgc"); // 
            //发送邮件
            try
            {
                client.Send(mailMsg);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
