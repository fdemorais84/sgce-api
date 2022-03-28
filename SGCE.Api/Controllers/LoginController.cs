using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCE.Domain.StoreContext.Commands.LoginCommands.Inputs;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Domain.StoreContext.Entities;
using SGCE.Domain.StoreContext.Commands.LoginCommands.Outputs;
using SGCE.Shared.Commands;

namespace SGCE.Api.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;
        private readonly LoginHandler _handler;

        public LoginController(ILoginRepository repository, LoginHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("v1/login")]
        public bool Login([FromBody] GetLoginCommand command)
        {
            var Login = new Login(command.Email, command.Senha);
            return _repository.Get(Login);
        }

        [HttpPost]
        [Route("v1/login-cadastro")]
        public ICommandResult Post([FromBody] CreateLoginCommand command)
        {
            return (CreateLoginCommandResult)_handler.Handle(command);            
        }
    }
}
