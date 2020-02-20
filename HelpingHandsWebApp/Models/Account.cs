using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        [Display(Name = "Account ID")]
        public int AccID { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Username must be atleast 8 character which contain 1 Uppercase character and 1 number")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }
        public string Category { get; set; }

    public static void BuildEmailTemplate(string sendto, string status)
    {
        string from, to, bcc, cc, subject, body;
        from = "helpinghandsorg69@gmail.com";
        to = sendto.Trim();
        bcc = "";
        cc = "";
        subject = "Welcome Customer";
        StringBuilder sb = new StringBuilder();
        sb.Append("You have been registered as a " + status+" at Helping Hands");
        body = sb.ToString();
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.From = new MailAddress(from);
        mail.To.Add(new MailAddress(to));
        if (!string.IsNullOrEmpty(bcc))
        {
            mail.Bcc.Add(new MailAddress(bcc));
        }
        if (!string.IsNullOrEmpty(cc))
        {
            mail.CC.Add(new MailAddress(cc));
        }
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;
        SendEmail(mail);
    }

    public static void SendEmail(MailMessage mail)
    {

        SmtpClient client = new SmtpClient();
        client.UseDefaultCredentials = true;
        client.Host = "smtp.gmail.com";
        client.Port = 25;
        client.EnableSsl = true;
        //client.UseDefaultCredentials = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new System.Net.NetworkCredential("Farmworks69@gmail.com", "farmerbrown1");
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    }
}
