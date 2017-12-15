using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace testumbracocontactform.Bussiness.ViewModels
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Message { get; set; }

        public SmtpStatusCode MessageStatus { get; set; }

        public IEnumerable<string> Recepients { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
