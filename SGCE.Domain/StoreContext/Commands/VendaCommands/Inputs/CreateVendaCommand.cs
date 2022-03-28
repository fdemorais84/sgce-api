using FluentValidator;
using FluentValidator.Validation;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.VendaCommands
{
    public class CreateVendaCommand : Notifiable, ICommand
    {

        public string ClienteId { get; set; }
        public string ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }

        //public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(ClienteId, 3, "CLiente", "A descrição deve conter pelo menos 3 caracteres")
            );
            return IsValid;
        }


    }
}
