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
                client.Credentials = new NetworkCredential("hossammohamedbit@gmail.com", "sdfn adsd adid oiem");
                client.Send("hossammohamedbit@gmail.com", email.To, email.Subject, email.Body);

                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

    }
}
