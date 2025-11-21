using System.Net;
using System.Net.Mail;

namespace Assignment.PL.Utilities
{
    public static class EmailSettings
    {
        public static bool SendEmail(Email email)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("xxxxx@gmail.com", "xxxx xxxx xxxx xxxx");
                client.Send("xxxxx@gmail.com", email.To, email.Subject, email.Body);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
