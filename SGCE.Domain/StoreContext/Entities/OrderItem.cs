using FluentValidator;
using System.Collections;
using System.Collections.Generic;
using SGCE.Shared.Entities;
using SGCE.Domain.StoreContext.Handlers;
using System;

namespace SGCE.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(string product, decimal quantity, decimal valor)
        {
            Product = product;
            Quantity = quantity;
            Valor = valor;
        }

        public string Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Valor { get; private set; }

    }
}