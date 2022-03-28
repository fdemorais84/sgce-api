using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCE.Domain.StoreContext.Commands.CategoriaCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.CategoriaCommands.Outputs;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Shared.Commands;

namespace SGCE.Api.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _repository;
        private readonly CategoriaHandler _handler;

        public CategoriaController(ICategoriaRepository repository, CategoriaHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("v1/categorias")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListCategoriaQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        [Route("v1/categorias-get")]
        public GetCategoriaQueryResult GetById([FromBody] string id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        [Route("v1/categorias-save")]
        public ICommandResult Post([FromBody] CreateCategoriaCommand command)
        {
            return (CreateCategoriaCommandResult)_handler.Handle(command);            
        }

        [HttpPost]
        [Route("v1/categorias-update")]
        public ICommandResult Put([FromBody] UpdateCategoriaCommand command)
        {
            return (UpdateCategoriaCommandResult)_handler.Handle(command);            
        }

        [HttpPost]
        [Route("v1/categorias-delete")]
        public bool Delete([FromBody] string id)
        {
            return _repository.Delete(id);            
        }
    }
}
