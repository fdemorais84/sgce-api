using System;
using System.Collections.Generic;
using SGCE.Domain.StoreContext.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.ValueObjects;
using SGCE.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using SGCE.Domain.StoreContext.Commands.ClienteCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.ClienteCommands.Outputs;

namespace SGCE.Api.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        private readonly ClienteHandler _handler;

        public ClienteController(IClienteRepository repository, ClienteHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("v1/clientes")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListClienteQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        [Route("v1/clientes-get")]
        public GetClienteQueryResult GetById([FromBody] string id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        [Route("v1/clientes-save")]
        public ICommandResult Post([FromBody] CreateClienteCommand command)
        {
            return (CreateClienteCommandResult)_handler.Handle(command);    
        }

        [HttpPost]
        [Route("v1/clientes-update")]
        public ICommandResult Put([FromBody] UpdateClienteCommand command)
        {
            return (UpdateClienteCommandResult)_handler.Handle(command);            
        }

        [HttpPost]
        [Route("v1/clientes-delete")]
        public bool Delete([FromBody] string id)
        {
            return _repository.Delete(id);            
        }

        [HttpPost]
        [Route("v1/clientes-aumentar-saldo")]
        public ICommandResult AcrescentarSaldo([FromBody] UpdateClienteCommand command)
        {
            command.Pagamento = false;
            return (UpdateClienteCommandResult)_handler.HandleSaldo(command);            
        }

        [HttpPost]
        [Route("v1/clientes-diminuir-saldo")]
        public ICommandResult AbaterSaldo([FromBody] UpdateClienteCommand command)
        {
            command.Pagamento = true;
            return (UpdateClienteCommandResult)_handler.HandleSaldo(command);
        }

        [HttpPost]
        [Route("v1/clientes-turma-get")]
        public IEnumerable<ListClientesTurmaQueryResult> GetCLienteTurmaById([FromBody] string id)
        {
            return _repository.GetClientes(id);
        }

    }
}