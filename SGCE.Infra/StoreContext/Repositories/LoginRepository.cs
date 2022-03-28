using Dapper;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Infra.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGCE.Infra.StoreContext.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SgceDataContext _context;

        public LoginRepository(SgceDataContext context)
        {
            _context = context;
        }
        public bool Get(Login Login)
        {
            return
               _context
               .Connection
               .Query<bool>("SELECT CASE WHEN EXISTS (SELECT [Id] FROM [Login] WHERE [Email]=@email AND [Senha]=@senha) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END", new { email = Login.Email, senha = Login.Senha })
               .FirstOrDefault();
        }

        public void Save(Login Login)
        {
            _context.Connection.Query<string>("INSERT INTO [Login] ([Id], [Email], [Senha]) VALUES(@id, @email, @senha)",
                new { id = Login.Id, email = Login.Email, senha = Login.Senha })
                .FirstOrDefault();

        }
    }
}
