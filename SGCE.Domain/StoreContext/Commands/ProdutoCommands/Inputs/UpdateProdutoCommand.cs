using FluentValidator;
using FluentValidator.Validation;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.ProdutoCommands.Inputs
{
    public class UpdateProdutoCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public string CategoriaId { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Titulo, 2, "Nome", "O nome deve conter pelo menos 2 caracteres")
                .HasMaxLen(Titulo, 50, "Nome", "O nome deve conter no máximo 50 caracteres")
            );
            return IsValid;
        }
    }
}
