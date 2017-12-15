using System.Web.Mvc;
using testumbracocontactform.Bussiness;
using testumbracocontactform.Bussiness.ViewModels;
using Umbraco.Web.Mvc;

namespace testumbracocontactform.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly IContactFormService _contactFormService;

        public ContactSurfaceController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        public ActionResult RenderForm()
        {
            return PartialView("ContactPartial", _contactFormService.GetMessage());
        }

        public ActionResult SubmitForm(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                _contactFormService.AddMessage(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }
    }
}