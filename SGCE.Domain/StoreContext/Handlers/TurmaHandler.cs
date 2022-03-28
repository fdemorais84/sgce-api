using FluentValidator;
using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.TurmaCommands;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.ValueObjects;
using SGCE.Shared.Commands;
using SGCE.Domain.StoreContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using SGCE.Domain.StoreContext.Commands.TurmaCommands.Outputs;

namespace SGCE.Domain.StoreContext.Handlers
{
    public class TurmaHandler :
        Notifiable,
        ICommandHandler<CreateTurmaCommand>,
        ICommandHandler<UpdateTurmaCommand>
    {
        private readonly ITurmaRepository _repository;

        public TurmaHandler(ITurmaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTurmaCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Turma = new Turma(Nome, command.Descricao);

            // Validar entidades e VOs
            AddNotifications(Turma.Notifications);

            if (Invalid)
                return new CreateTurmaCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir a turma
            _repository.Save(Turma);

            // Retornar o resultado para tela
            return new CreateTurmaCommandResult(true, "Turma salva com sucesso");
        }

        public ICommandResult Handle(UpdateTurmaCommand command)
        {
            // Criar os VOs
            var Nome = new Name(command.Nome);

            // Criar a entidade
            var Turma = new Turma(Nome, command.Descricao);

            // Validar entidades e VOs
            AddNotifications(Turma.Notifications);

            if (Invalid)
                return new UpdateTurmaCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir a turma
            _repository.Update(command.Id, Turma);

            // Retornar o resultado para tela
            return new UpdateTurmaCommandResult(true, "Turma Atualizada com sucesso");
        }


        #region PRIVATE AREA
        public ICommandResult Handle(Guid id, UpdateTurmaCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(Guid id, CreateTurmaCommand command)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}


        

