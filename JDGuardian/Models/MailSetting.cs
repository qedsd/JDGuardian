namespace JDGuardian.Models
{
    /// <summary>
    /// 发送通知邮件的发件人邮箱设置
    /// </summary>
    public class MailSetting
    {
        public string Address { get; set; }
        public string DisplayName { get; set; } = "JDGuardian";
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; } = true;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsVaild()
        {
            return !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(Host) && Port != 0 && !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }
    }
}
