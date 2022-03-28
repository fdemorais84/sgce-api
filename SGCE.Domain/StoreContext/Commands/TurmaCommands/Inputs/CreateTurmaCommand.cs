using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using SGCE.Shared.Commands;

namespace SGCE.Domain.StoreContext.Commands.TurmaCommands
{
    public class CreateTurmaCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }        

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Nome, 2, "Nome", "O nome deve conter pelo menos 2 caracteres")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve conter no máximo 50 caracteres")
                .HasMinLen(Descricao, 3, "Descrição", "A descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Descricao, 100, "Descrição", "A descrição deve conter no máximo 100 caracteres")
            );
            return IsValid;
        }
    }
}
