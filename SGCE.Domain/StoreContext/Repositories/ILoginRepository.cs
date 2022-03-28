using SGCE.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Repositories
{
    public interface ILoginRepository
    {
        void Save(Login Login);
        bool Get(Login Login);
    }
}
