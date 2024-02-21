using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaLojaDeRoupas.Repository;
using SistemaLojaDeRoupas.Models;
using SistemaLojaDeRoupas.API.RequestDTOs;

namespace SistemaLojaDeRoupas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ShopPolicy")]

    public class VendaController : ControllerBase
    {
        private readonly IRepository<Venda> _vendasRepository;

        public VendaController(IRepository<Venda> vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        [HttpGet]
        public IActionResult GetVenda()
        {
            return Ok(_vendasRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetVendaById([FromRoute] int id)
        {
            return Ok(_vendasRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult PostVenda([FromBody] VendaRequest vendaRequest)
        {
            var venda = new Venda(vendaRequest.Preco, vendaRequest.CpfCliente, vendaRequest.ProdutosQuantidade);

            return Ok(_vendasRepository.Add(venda));
        }
    }
}
