using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCE.Domain.StoreContext.Commands.TurmaCommands;
using SGCE.Domain.StoreContext.Commands.TurmaCommands.Outputs;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Shared.Commands;

namespace SGCE.Api.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaRepository _repository;
        private readonly TurmaHandler _handler;

        public TurmaController(ITurmaRepository repository, TurmaHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("v1/turmas")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListTurmaQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        [Route("v1/turmas-get")]
        public GetTurmaQueryResult GetById([FromBody] string id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        [Route("v1/turmas-save")]
        public ICommandResult Post([FromBody] CreateTurmaCommand command)
        {
            return (CreateTurmaCommandResult)_handler.Handle(command);
        }

        [HttpPost]
        [Route("v1/turmas-update")]
        public ICommandResult Put([FromBody] UpdateTurmaCommand command)
        {
            return (UpdateTurmaCommandResult)_handler.Handle(command);
        }

        [HttpPost]
        [Route("v1/turmas-delete")]
        public bool Delete([FromBody] string id)
        {
            return _repository.Delete(id);
        }
    }
}
