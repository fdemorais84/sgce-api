using FluentValidator;
using SGCE.Domain.StoreContext.Commands.VendaCommands;
using SGCE.Domain.StoreContext.Commands.VendaCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.VendaCommands.Outputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Handlers
{
    public class VendaHandler :
        Notifiable,
        ICommandHandler<CreateVendaCommand>,
        ICommandHandler<AddItemCommand>
    {
        private readonly IVendaRepository _repository;

        public VendaHandler(IVendaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateVendaCommand command)
        {
            // Criar a entidade
            var Order = new Order(command.ClienteId);
            var OrderItem = new OrderItem(command.ProdutoId, command.Quantidade, command.Valor);

            if (Invalid)
                return new CreateVendaCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir a venda
            _repository.Save(Order, OrderItem);
            _repository.Update(Order, OrderItem.Valor);

            // Retornar o resultado para tela
            return new CreateVendaCommandResult(true, "Venda salva com sucesso");
        }

        #region PRIVATE AREA

        public ICommandResult Handle(AddItemCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(Guid id, CreateVendaCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(Guid id, AddItemCommand command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
