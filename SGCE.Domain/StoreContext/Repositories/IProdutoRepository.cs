using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Repositories
{
    public interface IProdutoRepository
    {
        void Save(Product Produto);
        void Update(string id, Product Produto);
        bool Delete(string id);
        IEnumerable<ListProdutoQueryResult> Get();
        GetProdutoQueryResult Get(string id);
        IEnumerable<ListProdutosCategoriaQueryResult> GetProdutos(string id);
    }
}
