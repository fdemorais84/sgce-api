using SGCE.Domain.StoreContext.Entities;

namespace SGCE.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}