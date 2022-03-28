using SGCE.Domain.StoreContext.Enums;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using SGCE.Shared.Entities;

namespace SGCE.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        public Order(string cliente)
        {
            Cliente = cliente;
            _items = new List<OrderItem>();
        }

        public string Cliente { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();


        public void AddItem(string product, decimal quantity, decimal valor)
        {            
            var item = new OrderItem(product, quantity, valor);
            _items.Add(item);            
        }      

    }
}