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
    public class VendaRepository : IVendaRepository
    {
        private readonly SgceDataContext _context;

        public VendaRepository(SgceDataContext context)
        {
            _context = context;
        }

        public void Save(Order Order, OrderItem OrderItem)
        {
            _context.Connection.Query<string>("INSERT INTO [Comanda] ([Id], [ClienteId]) VALUES(@id, @cliente)",
                new { id = Order.Id, cliente = Order.Cliente })
                .FirstOrDefault();


            _context.Connection.Query<string>("INSERT INTO [ItemComanda] ([Id], [ComandaId], [ProdutoId], [Quantidade], [Valor]) VALUES(@id, @comanda, @produto, @quantidade, @valor)",
            new { id = OrderItem.Id, comanda = Order.Id, produto = OrderItem.Product, quantidade = OrderItem.Quantity, valor = OrderItem.Valor })
            .FirstOrDefault();
        }

        public void Update(Order Order, decimal Saldo)
        {
            _context.Connection.Query<string>("UPDATE [Cliente] SET [Saldo]=[Saldo] + @saldo WHERE [Id]=@id",
                new { id = Order.Cliente, saldo = Saldo })
                .FirstOrDefault();
        }
    }
}
