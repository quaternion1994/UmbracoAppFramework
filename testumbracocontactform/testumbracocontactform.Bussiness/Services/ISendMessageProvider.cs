using System.Net.Mail;
using System.Threading.Tasks;
using testumbracocontactform.Bussiness.ViewModels;

namespace testumbracocontactform.Bussiness.Services
{
    public interface ISendMessageProvider
    {
        SmtpStatusCode SendEmail(string message, string address, string subject);
    }
}
