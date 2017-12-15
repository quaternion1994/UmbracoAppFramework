using System.Net.Mail;

namespace testumbracocontactform.Bussiness.Services.Impl
{
    public class SendMessageProvider : ISendMessageProvider
    {
        public SmtpStatusCode SendEmail(string message, string address, string subject)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    MailMessage email = new MailMessage();

                    email.Subject = subject;
                    email.Body = message;
                    email.IsBodyHtml = true;
                    email.To.Add(address);

                    client.Send(email);
                }
            }
            catch (SmtpFailedRecipientsException e)
            {
                return e.StatusCode;
            }

            return SmtpStatusCode.Ok;
        }
    }
}