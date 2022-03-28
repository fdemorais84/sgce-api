using FluentValidator;
using FluentValidator.Validation;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.ClienteCommands.Inputs
{
    public class UpdateClienteCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public decimal Saldo { get; set; }
        public string TurmaId { get; set; }
        public bool Pagamento { get; set; }

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
