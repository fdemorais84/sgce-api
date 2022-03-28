using FluentValidator;
using SGCE.Domain.StoreContext.Commands.LoginCommands.Inputs;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.Commands.LoginCommands.Outputs;

namespace SGCE.Domain.StoreContext.Handlers
{
    public class LoginHandler :
        Notifiable,
        ICommandHandler<CreateLoginCommand>
    {
        private readonly ILoginRepository _repository;

        public LoginHandler(ILoginRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateLoginCommand command)
        {
            // Criar a entidade
            var Login = new Login(command.Email, command.Senha);

            // Validar entidades e VOs
            AddNotifications(Login.Notifications);

            if (Invalid)
                return new CreateLoginCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");
                    //,
                    //Notifications);

            // Persistir o login
            _repository.Save(Login);

            // Retornar o resultado para tela
            return new CreateLoginCommandResult(true, "Dados cadastrados com sucesso");
            //, new
            //{
            //    Id = Login.Id,
            //    Email = Login.Email.ToString()
            //});
        }


        #region PRIVATE AREA

        public ICommandResult Handle(Guid id, CreateLoginCommand command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
