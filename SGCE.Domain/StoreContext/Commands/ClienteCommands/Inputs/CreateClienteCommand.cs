using SGCE.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using SGCE.Domain.StoreContext.Entities;

namespace SGCE.Domain.StoreContext.Commands.ClienteCommands.Inputs
{
    public class CreateClienteCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public string TurmaId { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Nome, 3, "Nome", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve conter no máximo 50 caracteres")
                .HasMinLen(Observacao, 3, "Observacao", "A observação deve conter pelo menos 3 caracteres")
                .HasMaxLen(Observacao, 100, "Observacao", "A observação deve conter no máximo 100 caracteres")             
            );
            return IsValid;
        }    
    }
}