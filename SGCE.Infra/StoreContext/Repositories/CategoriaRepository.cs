using Dapper;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SGCE.Infra.StoreContext.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SgceDataContext _context;

        public CategoriaRepository(SgceDataContext context)
        {
            _context = context;
        }
        public bool Delete(string id)
        {
            return
               _context
               .Connection
               .Query<bool>("DELETE FROM [Categoria] WHERE [Id]=@id", new { id = id })
               .FirstOrDefault();
        }

        public IEnumerable<ListCategoriaQueryResult> Get()
        {
            return
                _context
                .Connection
                .Query<ListCategoriaQueryResult>("SELECT [Id], [Nome], [Descricao] FROM [Categoria]", new { });
        }

        public GetCategoriaQueryResult Get(string id)
        {
            return
                _context
                .Connection
                .Query<GetCategoriaQueryResult>("SELECT [Id], [Nome], [Descricao] FROM [Categoria] WHERE [Id]=@id", new { id = id })
                .FirstOrDefault();
        }

        public void Save(Categoria Categoria)
        {
            _context.Connection.Query<string>("INSERT INTO [Categoria] ([Id], [Nome], [Descricao]) VALUES(@id, @nome, @descricao)",
                new { id = Categoria.Id, nome = Categoria.Name.Nome, descricao = Categoria.Descricao })
                .FirstOrDefault();
        }

        public void Update(string id, Categoria Categoria)
        {
            _context.Connection.Query<string>("UPDATE [Categoria] SET [Nome]=@nome, [Descricao]=@descricao WHERE [Id]=@id",
                new { id = id, nome = Categoria.Name.Nome, descricao = Categoria.Descricao })
                .FirstOrDefault();
        }
    }
}
