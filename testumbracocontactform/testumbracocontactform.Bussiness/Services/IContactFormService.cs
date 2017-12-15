using System.Collections.Generic;
using testumbracocontactform.Bussiness.ViewModels;

namespace testumbracocontactform.Bussiness
{
    public interface IContactFormService
    {
        IEnumerable<ContactFormViewModel> GetContactModels();
        void AddMessage(ContactFormViewModel model);
        void SaveMessage(ContactFormViewModel model);
        ContactFormViewModel GetMessage();
        ContactFormViewModel GetMessage(int id);
    }
}
