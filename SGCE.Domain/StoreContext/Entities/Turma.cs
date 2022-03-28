using SGCE.Domain.StoreContext.ValueObjects;
using SGCE.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Entities
{
    public class Turma : Entity
    {
        public Turma(
            Name nome,
            string descricao)
            
        {
            Name = nome;
            Descricao = descricao;            
        }

        public Name Name { get; private set; }
        public string Descricao { get; private set; }       
    }
}
