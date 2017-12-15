using System.Linq;
using System.Collections.Generic;
using testumbracocontactform.Bussiness.ViewModels;
using testumbracocontactform.DataAccess.Repositories;
using testumbracocontactform.Bussiness.Mappers;
using testumbracocontactform.Bussiness.Services;
using System;

namespace testumbracocontactform.Bussiness.Impl
{
    public class ContactFormService : IContactFormService
    {
        private readonly IUnitOfWorkFactory _uowFactory;
        private readonly ISettingsService _settingService;
        private readonly ISendMessageProvider _sendMessageProvider;

        public ContactFormService(IUnitOfWorkFactory unitOfWorkFactory, ISendMessageProvider sendMessageProvider, ISettingsService settingService)
        {
            _uowFactory = unitOfWorkFactory;
            _sendMessageProvider = sendMessageProvider;
            _settingService = settingService;
        }

        public IEnumerable<ContactFormViewModel> GetContactModels()
        {
            using (var uow = _uowFactory.Create())
            {
                return uow.MessageRepository.GetAll().Select(x => x.ToContactFormViewModel());
            }
        }

        public ContactFormViewModel GetMessage()
        {
            return new ContactFormViewModel()
            {
                Subjects = _settingService.Subjects,
                Recepients = _settingService.Recipients
            };
        }

        public ContactFormViewModel GetMessage(int id)
        {
            using (var uow = _uowFactory.Create())
            {
                return uow.MessageRepository.GetById(id).ToContactFormViewModel();
            }
        }

        public void SaveMessage(ContactFormViewModel model)
        {
            using (var uow = _uowFactory.Create())
            {
                uow.MessageRepository.Update(model.ToContactFormEntity());
            }
        }

        public void AddMessage(ContactFormViewModel model)
        {
            using (var uow = _uowFactory.Create())
            {
                model.MessageStatus = _sendMessageProvider.SendEmail($"{model.Message} (Name: {model.Name}, Phone: {model.Phone})", model.Email, "new contact message");

                var entity = model.ToContactFormEntity();
                entity.Date = DateTime.Now;
                uow.MessageRepository.Add(entity);
            }
        }
    }
}
