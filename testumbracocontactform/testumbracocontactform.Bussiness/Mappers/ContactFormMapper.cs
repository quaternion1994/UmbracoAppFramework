using System.Net.Mail;
using testumbracocontactform.Bussiness.ViewModels;
using testumbracocontactform.DataAccess.Entities;

namespace testumbracocontactform.Bussiness.Mappers
{
    public static class ContactFormMapper
    {
        public static ContactFormViewModel ToContactFormViewModel(this MessageDto entity)
        {
            return new ContactFormViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Message = entity.Message,
                Subject = entity.Subject,
                Phone = entity.Phone,
                MessageStatus = (SmtpStatusCode)entity.MessageStatus
            };
        }

        public static MessageDto ToContactFormEntity(this ContactFormViewModel viewModel)
        {
            return new MessageDto()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Email = viewModel.Email,
                Message = viewModel.Message,
                Subject = viewModel.Subject,
                Phone = viewModel.Phone,
                MessageStatus = (int)viewModel.MessageStatus
            };
        }
    }
}
