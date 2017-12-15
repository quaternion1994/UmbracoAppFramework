using System.Collections.Generic;
using System.Net.Mail;

namespace testumbracocontactform.Bussiness.ViewModels
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public SmtpStatusCode MessageStatus { get; set; }

        public IEnumerable<string> Recepients { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
