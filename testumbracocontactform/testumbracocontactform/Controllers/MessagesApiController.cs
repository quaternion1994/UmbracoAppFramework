using System.Collections.Generic;
using System.Web.Mvc;
using testumbracocontactform.Bussiness;
using testumbracocontactform.Bussiness.ViewModels;
using Umbraco.Web.WebApi;

namespace testumbracocontactform.Controllers
{
    public class MessagesApiController : UmbracoAuthorizedApiController
    {
        private readonly IContactFormService _contactFormService;

        public MessagesApiController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        // GET: Messages
        // /umbraco/backoffice/api/MessagesApi/GetList

        [HttpGet]
        public IEnumerable<ContactFormViewModel> GetList()
        {
            return _contactFormService.GetContactModels();
        }
    }
}