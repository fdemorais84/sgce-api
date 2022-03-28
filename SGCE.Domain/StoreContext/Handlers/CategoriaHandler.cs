using FluentValidator;
using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.CategoriaCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.CategoriaCommands.Outputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.ValueObjects;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Handlers
{
    public class CategoriaHandler :
        Notifiable,
        ICommandHandler<CreateCategoriaCommand>,
        ICommandHandler<UpdateCategoriaCommand>
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCategoriaCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Categoria = new Categoria(Nome, command.Descricao);

            // Validar entidades e VOs
            AddNotifications(Nome.Notifications);
            AddNotifications(Categoria.Notifications);

            if (Invalid)
                return new CreateCategoriaCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir a categoria 
            _repository.Save(Categoria);            

            // Retornar o resultado para tela
            return new CreateCategoriaCommandResult(true, "Categoria salva com sucesso");
        }

        public ICommandResult Handle(UpdateCategoriaCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Categoria = new Categoria(Nome, command.Descricao);

            // Validar entidades e VOs
            AddNotifications(Nome.Notifications);
            AddNotifications(Categoria.Notifications);

            if (Invalid)
                return new UpdateCategoriaCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir a categoria
            _repository.Update(command.Id, Categoria);

            // Retornar o resultado para tela
            return new UpdateCategoriaCommandResult(true, "Categoria Atualizada com sucesso");
        }

        #region PRIVATE AREA

        public ICommandResult Handle(Guid id, CreateCategoriaCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(Guid id, UpdateCategoriaCommand command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
