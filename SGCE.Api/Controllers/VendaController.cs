using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCE.Domain.StoreContext.Commands.VendaCommands;
using SGCE.Domain.StoreContext.Commands.VendaCommands.Outputs;
using SGCE.Domain.StoreContext.Handlers;
using SGCE.Domain.StoreContext.Queries;
using SGCE.Domain.StoreContext.Repositories;
using SGCE.Shared.Commands;

namespace SGCE.Api.Controllers
{
    public class VendaController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly VendaHandler _handler;        

        public VendaController(IClienteRepository clienteRepository, ITurmaRepository turmaRepository, ICategoriaRepository categoriaRepository, 
                               IProdutoRepository produtoRepository, VendaHandler handler)
        {
            _clienteRepository = clienteRepository;
            _turmaRepository = turmaRepository;
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _handler = handler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("v1/turmas-venda")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListTurmaQueryResult> Get()
        {
            return _turmaRepository.Get();
        }

        [HttpPost]
        [Route("v1/clientes-venda")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListClientesTurmaQueryResult> GetClientByIdTurma([FromBody] string id)
        {
            return _clienteRepository.GetClientes(id);
        }

        [HttpGet]
        [Route("v1/categorias-venda")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListCategoriaQueryResult> GetCategoria()
        {
            return _categoriaRepository.Get();
        }

        [HttpPost]
        [Route("v1/produtos-venda")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListProdutosCategoriaQueryResult> GetProdutoByIdCategoria([FromBody] string id)
        {
            return _produtoRepository.GetProdutos(id);
        }

        [HttpPost]
        [Route("v1/venda-save")]
        public ICommandResult Post([FromBody] CreateVendaCommand command)
        {
            return (CreateVendaCommandResult)_handler.Handle(command);            
        }
    }
}
