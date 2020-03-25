using OnlineCourses.Interfaces;
using System.Net;
using System.Net.Mail;

namespace OnlineCourses.Implementation.Helper
{
    public class EmailService : IEmailProvider
    {

        public void Send(string email, string name)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("onlinecourses.backoffice@gmail.com", "projectcsharp"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var msg = new MailMessage("onlinecourses.backoffice@gmail.com", $"{email}")//backoffice.onlinecourses C#projects123
            {
                Body = $"Dear {name} welcome in OnlineCourses Education platform",
                Subject = "Online Courses Registration"
            };

            client.Send(msg);
        }
    }
}
