using FluentValidator;
using FluentValidator.Validation;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.CategoriaCommands.Inputs
{
    public class UpdateCategoriaCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Nome, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve conter no máximo 50 caracteres")
                .HasMinLen(Descricao, 3, "LastName", "A descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 100, "LastName", "A descrição deve conter no máximo 100 caracteres")
            );
            return IsValid;
        }
    }
}
