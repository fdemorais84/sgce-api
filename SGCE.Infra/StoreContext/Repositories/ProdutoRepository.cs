using Dapper;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGCE.Infra.StoreContext.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SgceDataContext _context;

        public ProdutoRepository(SgceDataContext context)
        {
            _context = context;
        }
        public bool Delete(string id)
        {
            return
               _context
               .Connection
               .Query<bool>("DELETE FROM [Produto] WHERE [Id]=@id", new { id = id })
               .FirstOrDefault();
        }

        public IEnumerable<ListProdutoQueryResult> Get()
        {
            return
                _context
                .Connection
                .Query<ListProdutoQueryResult>("SELECT P.*, C.Nome FROM [Produto] AS P INNER JOIN [Categoria] AS C ON P.CategoriaId = C.Id", new { });
        }

        public GetProdutoQueryResult Get(string id)
        {
            return
                _context
                .Connection
                .Query<GetProdutoQueryResult>("SELECT P.*, C.Nome FROM [Produto] AS P INNER JOIN [Categoria] AS C ON P.CategoriaId = C.Id WHERE P.Id=@id", new { id = id })
                .FirstOrDefault();
        }

        public void Save(Product Produto)
        {
            _context.Connection.Query<string>("INSERT INTO [Produto] ([Id], [Titulo], [Valor], [CategoriaId]) VALUES(@id, @titulo, @valor, @categoria)",
                new { id = Produto.Id, titulo = Produto.Titulo, valor = Produto.Valor, categoria = Produto.Categoria })
                .FirstOrDefault();
        }

        public void Update(string id, Product Produto)
        {
            _context.Connection.Query<string>("UPDATE [Produto] SET [Titulo]=@titulo, [Valor]=@valor, [CategoriaId]=@categoria WHERE [Id]=@id",
                new { id = id, titulo = Produto.Titulo, valor = Produto.Valor, categoria = Produto.Categoria })
                .FirstOrDefault();
        }

        public IEnumerable<ListProdutosCategoriaQueryResult> GetProdutos(string id)
        {
            return
                _context
                .Connection
                .Query<ListProdutosCategoriaQueryResult>("SELECT [Id], [Titulo], [Valor] FROM [Produto] WHERE [CategoriaId]=@id", new { id = id });
        }
    }
}
