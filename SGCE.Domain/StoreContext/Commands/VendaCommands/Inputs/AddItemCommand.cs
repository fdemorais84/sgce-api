using FluentValidator;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Commands.VendaCommands.Inputs
{
    public class AddItemCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }        

        bool ICommand.Valid()
        {
            return IsValid;
        }
    }
}
