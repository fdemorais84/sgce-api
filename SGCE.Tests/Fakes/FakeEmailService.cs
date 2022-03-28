using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Services;

namespace SGCE.Tests
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}
