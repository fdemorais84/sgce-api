using System;

namespace SGCE.Domain.StoreContext.Queries 
{
    public class ClienteOrdersCountResult 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Document { get; set; }
        public int Orders { get; set; }
    }
}