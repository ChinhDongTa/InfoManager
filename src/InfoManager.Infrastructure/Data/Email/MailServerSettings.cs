namespace InfoManager.Infrastructure.Data.Email;

public class MailServerSettings
{
    public string Host { get; set; } ="DongTa";
    public int Port { get; set; } = 25;
    public bool EnableSsl { get; set; }
}
