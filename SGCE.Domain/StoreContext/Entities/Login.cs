using SGCE.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Entities
{
    public class Login : Entity
    {
        public Login(
            string email,
            string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }
    }
}
