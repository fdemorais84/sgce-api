using SGCE.Domain.StoreContext.ValueObjects;
using FluentValidator;
using System.Collections.Generic;
using System.Linq;
using SGCE.Shared.Entities;
using System;

namespace SGCE.Domain.StoreContext.Entities
{
    public class Cliente : Entity
    {        
        public Cliente(
            Name nome,
            string observacao,
            decimal saldo,
            string turma)
        {
            Name = nome;
            Observacao = observacao;
            Saldo = saldo;
            Turma = turma;
        }

        public Name Name { get; private set; }
        public string Observacao { get; private set; }
        public decimal Saldo { get; private set; }
        public string Turma { get; private set; }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}