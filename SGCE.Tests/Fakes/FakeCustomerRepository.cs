using System;
using System.Collections.Generic;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;

namespace SGCE.Tests
{
    public class FakeClienteRepository : IClienteRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListClienteQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public GetClienteQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public GetClienteQueryResult Get(string id)
        {
            throw new NotImplementedException();
        }

        public ClienteOrdersCountResult GetClienteOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListClienteQueryResult> GetClientes(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListClienteQueryResult> GetClientes(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListClienteOrdersQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Cliente Cliente)
        {
            
        }

        public void Update(Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdateAcrescentar(Guid id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdateAcrescentar(string id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdatePagar(Guid id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdatePagar(string id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdateSaldo(Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        public void UpdateSaldo(Guid id, Cliente Cliente)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ListClientesTurmaQueryResult> IClienteRepository.GetClientes(string id)
        {
            throw new NotImplementedException();
        }
    }
}
