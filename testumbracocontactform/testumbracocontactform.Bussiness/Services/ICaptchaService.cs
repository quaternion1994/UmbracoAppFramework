namespace testumbracocontactform.Bussiness.Services.Impl
{
    public interface ICaptchaService
    {
        bool ValidateCode(string code);
    }
}
