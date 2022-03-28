using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Repositories
{
    public interface ICategoriaRepository
    {
        void Save(Categoria Categoria);
        void Update(string id, Categoria Categoria);
        bool Delete(string id);
        IEnumerable<ListCategoriaQueryResult> Get();
        GetCategoriaQueryResult Get(string id);
    }
}
