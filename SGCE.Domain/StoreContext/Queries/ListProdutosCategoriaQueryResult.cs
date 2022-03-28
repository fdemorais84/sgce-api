using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Queries
{
    public class ListProdutosCategoriaQueryResult
    {
        public System.Guid Id { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
    }
}
