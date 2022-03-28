using System;
using System.Collections.Generic;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;

namespace SGCE.Domain.StoreContext.Repositories
{
    public interface IClienteRepository
    {
        void Save(Cliente Cliente);
        void Update(string id, Cliente Cliente);
        bool Delete(string id);
        void UpdatePagar(string id, Cliente Cliente);
        void UpdateAcrescentar(string id, Cliente Cliente);
        IEnumerable<ListClienteQueryResult> Get();
        GetClienteQueryResult Get(string id);
        IEnumerable<ListClienteOrdersQueryResult> GetOrders(Guid id);
        IEnumerable<ListClientesTurmaQueryResult> GetClientes(string id);

    }
}