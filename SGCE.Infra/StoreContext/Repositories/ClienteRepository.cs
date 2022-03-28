using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Infra.DataContexts;
using Dapper;

namespace SGCE.Infra.StoreContext.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SgceDataContext _context;

        public ClienteRepository(SgceDataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<ListClienteQueryResult> Get()
        {
            return
                _context
                .Connection
                .Query<ListClienteQueryResult>("SELECT C.*, T.Nome Sigla FROM [Cliente] AS C INNER JOIN [Turma] AS T ON C.TurmaId = T.Id", new { });
        }

        public GetClienteQueryResult Get(string id)
        {
            return
                _context
                .Connection
                .Query<GetClienteQueryResult>("SELECT C.*, T.Nome Sigla FROM [Cliente] AS C INNER JOIN [Turma] AS T ON C.TurmaId = T.Id WHERE C.Id=@id", new { id = id })
                .FirstOrDefault();
        }        

        public IEnumerable<ListClienteOrdersQueryResult> GetOrders(Guid id)
        {
            return
                _context
                .Connection
                .Query<ListClienteOrdersQueryResult>("", new { id = id });
        }

        public void Save(Cliente Cliente)
        {
            _context.Connection.Query<string>("INSERT INTO [Cliente] ([Id], [Nome], [Observacao], [Saldo], [TurmaId]) VALUES(@id, @nome, @observacao, @saldo, @turma)",
                new { id = Cliente.Id, nome = Cliente.Name.Nome, observacao = Cliente.Observacao, saldo = Cliente.Saldo, turma = Cliente.Turma })
                .FirstOrDefault();            
        }

        public void Update(string id, Cliente Cliente)
        {
            _context.Connection.Query<string>("UPDATE [Cliente] SET [Nome]=@nome, [Observacao]=@observacao, [TurmaId]=@turma WHERE [Id]=@id", 
                new { id = id, nome = Cliente.Name.Nome, observacao = Cliente.Observacao, turma = Cliente.Turma })
                .FirstOrDefault();
        }

        public bool Delete(string id)
        {
            return
                _context
                .Connection
                .Query<bool>("DELETE FROM [Cliente] WHERE [Id]=@id", new { id = id })
                .FirstOrDefault();
        }

        public IEnumerable<ListClientesTurmaQueryResult> GetClientes(string id)
        {
            return
                _context
                .Connection
                .Query<ListClientesTurmaQueryResult>("SELECT [Id], [Nome] FROM [Cliente] WHERE [TurmaId]=@id", new { id = id });
        }

        public void UpdatePagar(string id, Cliente Cliente)
        {
            _context.Connection.Query<string>("UPDATE [Cliente] SET [Saldo]=[Saldo] - @saldo WHERE [Id]=@id",
                new { id = id, saldo = Cliente.Saldo })
                .FirstOrDefault();          
        }

        public void UpdateAcrescentar(string id, Cliente Cliente)
        {
            _context.Connection.Query<string>("UPDATE [Cliente] SET [Saldo]=[Saldo] + @saldo WHERE [Id]=@id",
                new { id = id, saldo = Cliente.Saldo })
                .FirstOrDefault();
        }

    }
}