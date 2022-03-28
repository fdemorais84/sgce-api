using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Queries
{
    public class GetCategoriaQueryResult
    {
        public System.Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
