// See https://aka.ms/new-console-template for more information
using System;
using System.Net;
using System.Net.Mail;

var s = new Sender();
s.CreateMessageWithAttachment("smtp.gmail.com");

Console.WriteLine("End program.");
Console.WriteLine("End program.");
public class Sender
{
    public async void CreateMessageWithAttachment(string server)
    {
        // Create a message and set up the recipients
        MailMessage message = new MailMessage(
            "developermykyta@gmail.com",
            "neyton61@gmail.com",
            "Quarterly data report",
            "See the attached spreadsheet.");

        // Configure SMTP client
        SmtpClient client = new SmtpClient(server, 587); // Use port 587 for Gmail
        client.EnableSsl = true; // Gmail requires SSL
        client.Credentials = new NetworkCredential("developermykyta@gmail.com", "byiq pxlu vxjl emfm"); // Replace with your email and password

        try
        {
            client.Send(message);
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", ex.ToString());
        }
    }
}
/*
var mailSettings = new MailSettings
{
    Domen = "smtp.gmail.com",
    MailAddress = "developermykyta@gmail.com",
    MailPassword = "6W4i-52jz-9r3q",
    SmtpAddress = "developermykyta@gmail.com",
    SmtpPort = 587,
    SslOrTls = false,
    EnableWorking = true
};
var smtpSender = new SmtpSender(mailSettings);

smtpSender.SendEmail("neyton61@gmail.com", "Тест", "Це тестовий лист");


public class MailSettings
{
    public string SmtpAddress { get; set; }
    public int SmtpPort { get; set; }
    public string MailAddress { get; set; }
    public string MailPassword { get; set; }
    public string Domen { get; set; }
    public bool SslOrTls { get; set; }
    public bool EnableWorking { get; set; }
}
public class SmtpSender
{
    private readonly MailSettings Settings;
    private readonly MailAddress From;
    private readonly SmtpClient Smtp;

    public SmtpSender(MailSettings mailSettings)
    {
        Settings = mailSettings;
        Smtp = new SmtpClient(Settings.SmtpAddress, Settings.SmtpPort)
        {
            Credentials = new NetworkCredential(Settings.MailAddress, Settings.MailPassword)
        };
        From = new MailAddress(Settings.MailAddress, Settings.Domen);
        Smtp.EnableSsl = true;
        Smtp.UseDefaultCredentials = true;
    }
    public void SendEmail(string email, string subject, string text)
    {
        var to = new MailAddress(email);
        var message = new MailMessage(From, to)
        {
            Subject = subject,
            Body = text,
            IsBodyHtml = true
        };
        try
        {
            if (Settings.EnableWorking)
            {
                Smtp.Send(message);
            }
            Console.WriteLine($"Був відправиленний лист на адресу={email}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Сервер не може відправити листа по адресі={email}");
            Console.WriteLine($"Виключення={e.Message}");
            Console.WriteLine($"Внутрішне виключення={e.InnerException?.Message}");
        }
    }
*/