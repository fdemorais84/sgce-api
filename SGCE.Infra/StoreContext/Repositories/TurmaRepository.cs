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
    public class TurmaRepository : ITurmaRepository
    {
        private readonly SgceDataContext _context;

        public TurmaRepository(SgceDataContext context)
        {
            _context = context;
        }
        public bool Delete(string id)
        {
            return
               _context
               .Connection
               .Query<bool>("DELETE FROM [Turma] WHERE [Id]=@id", new { id = id })
               .FirstOrDefault();
        }

        public IEnumerable<ListTurmaQueryResult> Get()
        {
            return
                _context
                .Connection
                .Query<ListTurmaQueryResult>("SELECT [Id], [Nome], [Descricao] FROM [Turma]", new { });
        }

        public GetTurmaQueryResult Get(string id)
        {
            return
                _context
                .Connection
                .Query<GetTurmaQueryResult>("SELECT [Id], [Nome], [Descricao] FROM [Turma] WHERE [Id]=@id", new { id = id })
                .FirstOrDefault();
        }

        public void Save(Turma Turma)
        {
            _context.Connection.Query<string>("INSERT INTO [Turma] ([Id], [Nome], [Descricao]) VALUES(@id, @nome, @descricao)",
                new { id = Turma.Id, nome = Turma.Name.Nome, descricao = Turma.Descricao })
                .FirstOrDefault();
        }

        public void Update(string id, Turma Turma)
        {
            _context.Connection.Query<string>("UPDATE [Turma] SET [Nome]=@nome, [Descricao]=@descricao WHERE [Id]=@id",
                new { id = id, nome = Turma.Name.Nome, descricao = Turma.Descricao })
                .FirstOrDefault();
        }
    }
}
