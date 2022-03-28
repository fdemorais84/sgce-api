using SGCE.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Repositories
{
    public interface IVendaRepository
    {
        void Save(Order Order, OrderItem OrderItem);
        void Update(Order Order, decimal Saldo);
    }
}
