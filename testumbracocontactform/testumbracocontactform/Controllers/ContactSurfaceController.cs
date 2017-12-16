using System.Web.Mvc;
using testumbracocontactform.Bussiness;
using testumbracocontactform.Bussiness.Services.Impl;
using testumbracocontactform.Bussiness.ViewModels;
using Umbraco.Web.Mvc;

namespace testumbracocontactform.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly IContactFormService _contactFormService;
        private readonly ICaptchaService _captchaService;

        public ContactSurfaceController(IContactFormService contactFormService, ICaptchaService capchaService)
        {
            _contactFormService = contactFormService;
            _captchaService = capchaService;
        }

        public ActionResult RenderForm()
        {
            
            return PartialView("ContactPartial", _contactFormService.GetMessage());
        }

        public ActionResult SubmitForm(ContactFormViewModel model)
        {
            var code = Request["g-recaptcha-response"];

            if (!_captchaService.ValidateCode(code))
            {
                ModelState.AddModelError("", "Invalid captcha");
            }
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