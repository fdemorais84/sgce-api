using FluentValidator;
using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.ProdutoCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.ProdutoCommands.Outputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCE.Domain.StoreContext.Handlers
{
    public class ProdutoHandler :
        Notifiable,
        ICommandHandler<CreateProdutoCommand>,
        ICommandHandler<UpdateProdutoCommand>
    {
        private readonly IProdutoRepository _repository;

        public ProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateProdutoCommand command)
        {   
            // Criar a entidade
            var Produto = new Product(command.Titulo, command.Valor, command.CategoriaId);

            // Validar entidades e VOs            
            AddNotifications(Produto.Notifications);

            if (Invalid)
                return new CreateProdutoCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir o produto
            _repository.Save(Produto);

            // Retornar o resultado para tela
            return new CreateProdutoCommandResult(true, "Produto salvo com sucesso");
        }

        public ICommandResult Handle(UpdateProdutoCommand command)
        {
            // Criar a entidade
            var Produto = new Product(command.Titulo, command.Valor, command.CategoriaId);

            // Validar entidades e VOs            
            AddNotifications(Produto.Notifications);

            if (Invalid)
                return new UpdateProdutoCommandResult(
                    false,
                    "Por favor, corrija os campos abaixo");

            // Persistir o produto
            _repository.Update(command.Id, Produto);

            // Retornar o resultado para tela
            return new UpdateProdutoCommandResult(true, "Produto Atualizado com sucesso");
        }

        #region PRIVATE AREA

        public ICommandResult Handle(Guid id, CreateProdutoCommand command)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Handle(Guid id, UpdateProdutoCommand command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
