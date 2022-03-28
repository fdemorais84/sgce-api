using System;
using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.Services;
using SGCE.Domain.StoreContext.ValueObjects;
using SGCE.Shared.Commands;
using FluentValidator;
using SGCE.Domain.StoreContext.Commands.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.ClienteCommands.Outputs;

namespace SGCE.Domain.StoreContext.Handlers
{
    public class ClienteHandler :
        Notifiable,
        ICommandHandler<CreateClienteCommand>,
        ICommandHandler<UpdateClienteCommand>
    {
        private readonly IClienteRepository _repository;

        public ClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateClienteCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Cliente = new Cliente(Nome, command.Observacao, 0, command.TurmaId);

            // Validar entidades e VOs
            AddNotifications(Nome.Notifications);            
            AddNotifications(Cliente.Notifications);

            if (Invalid)
                return new CreateClienteCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir o cliente
            _repository.Save(Cliente);

            // Retornar o resultado para tela
            return new CreateClienteCommandResult(true, "Cliente salvo com sucesso");
        }

        public ICommandResult Handle(UpdateClienteCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Cliente = new Cliente(Nome, command.Observacao, command.Saldo, command.TurmaId);

            // Validar entidades e VOs
            AddNotifications(Nome.Notifications);
            AddNotifications(Cliente.Notifications);

            if (Invalid)
                return new UpdateClienteCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir o cliente
            _repository.Update(command.Id, Cliente);

            // Retornar o resultado para tela
            return new UpdateClienteCommandResult(true, "Cliente Atualizado com sucesso");
        }

        public ICommandResult HandleSaldo(UpdateClienteCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Cliente = new Cliente(Nome, command.Observacao, command.Saldo, command.TurmaId);

            // Validar entidades e VOs
            AddNotifications(Nome.Notifications);
            AddNotifications(Cliente.Notifications);

            if (Invalid)
                return new UpdateClienteCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir o cliente
            if(command.Pagamento)
            _repository.UpdatePagar(command.Id, Cliente);
            else _repository.UpdateAcrescentar(command.Id, Cliente);

            // Retornar o resultado para tela
            return new UpdateClienteCommandResult(true, "Saldo Atualizado com sucesso");
        }

        #region PRIVATE AREA

        public ICommandResult Handle(Guid id, CreateClienteCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(Guid id, UpdateClienteCommand command)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
