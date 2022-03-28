using FluentValidator;
using FluentValidator.Validation;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.LoginCommands.Inputs
{
    public class CreateLoginCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Email, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Email, 50, "Nome", "O nome deve conter no máximo 50 caracteres")
                .HasMinLen(Senha, 3, "Descrição", "A descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Senha, 100, "Descrição", "A descrição deve conter no máximo 100 caracteres")
            );
            return IsValid;
        }
    }
}
