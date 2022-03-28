namespace SGCE.Domain.StoreContext.Queries
{
    public class ListClienteOrdersQueryResult
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public decimal Total { get; set; }
    }
}