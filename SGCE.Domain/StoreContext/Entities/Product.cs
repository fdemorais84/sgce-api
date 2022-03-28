using SGCE.Shared.Entities;
using FluentValidator;
using System;

namespace SGCE.Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        public Product(
            string titulo,            
            decimal valor,
            string categoria)            
        {
            Titulo = titulo;            
            Valor = valor;
            Categoria = categoria;
        }

        public string Titulo { get; private set; }        
        public decimal Valor { get; private set; }
        public string Categoria { get; private set; }

        public override string ToString()
        {
            return Titulo;
        }       
    }
}