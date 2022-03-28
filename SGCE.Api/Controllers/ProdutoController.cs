using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCE.Domain.StoreContext.Commands.ProdutoCommands.Inputs;
using SGCE.Domain.StoreContext.Commands.ProdutoCommands.Outputs;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Shared.Commands;

namespace SGCE.Api.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _repository;
        private readonly ProdutoHandler _handler;

        public ProdutoController(IProdutoRepository repository, ProdutoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("v1/produtos")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListProdutoQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpPost]
        [Route("v1/produtos-get")]
        public GetProdutoQueryResult GetById([FromBody] string id)
        {
            return _repository.Get(id);
        }

        [HttpPost]
        [Route("v1/produtos-save")]
        public ICommandResult Post([FromBody] CreateProdutoCommand command)
        {
            return (CreateProdutoCommandResult)_handler.Handle(command);
        }

        [HttpPost]
        [Route("v1/produtos-update")]
        public ICommandResult Put([FromBody] UpdateProdutoCommand command)
        {
            return (UpdateProdutoCommandResult)_handler.Handle(command);
        }

        [HttpPost]
        [Route("v1/produtos-delete")]
        public bool Delete([FromBody] string id)
        {
            return _repository.Delete(id);
        }

        [HttpPost]
        [Route("v1/produtos-categoria-get")]
        public IEnumerable<ListProdutosCategoriaQueryResult> GetProdutosCategoriaById([FromBody] string id)
        {
            return _repository.GetProdutos(id);
        }
    }
}
