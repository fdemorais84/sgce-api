using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Repositories
{
    public interface ITurmaRepository
    {
        void Save(Turma Turma);
        void Update(string id, Turma Turma);
        bool Delete(string id);
        IEnumerable<ListTurmaQueryResult> Get();
        GetTurmaQueryResult Get(string id);

    }
}
