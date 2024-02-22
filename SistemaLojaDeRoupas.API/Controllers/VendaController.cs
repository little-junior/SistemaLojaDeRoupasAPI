using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaLojaDeRoupas.Repository;
using SistemaLojaDeRoupas.Models;
using SistemaLojaDeRoupas.API.RequestDTOs;
using SistemaLojaDeRoupas.API.CustomExceptions;
using SistemaLojaDeRoupas.API.BusinessLayers;
using System.Diagnostics;

namespace SistemaLojaDeRoupas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ShopPolicy")]

    public class VendaController : ControllerBase
    {
        private readonly IRepository<Venda> _vendasRepository;
        private readonly VendaBL _vendaBL;

        public VendaController(IRepository<Venda> vendasRepository, VendaBL vendaBL)
        {
            _vendasRepository = vendasRepository;
            _vendaBL = vendaBL;
        }

        [HttpGet]
        public IActionResult GetVendas()
        {
            return Ok(_vendasRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetVendaById([FromRoute] int id)
        {
            var venda = _vendasRepository.GetById(id);

            if (venda == null)
                throw new CustomException("Object not found", StatusCodes.Status404NotFound);

            return Ok(_vendasRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult PostVenda([FromBody] VendaRequest vendaRequest)
        {
            var validCpf = _vendaBL.ValidateCpfCliente(vendaRequest);

            if (!validCpf)
            {
                throw new CustomException("The field 'clienteCpf' is not valid", StatusCodes.Status400BadRequest);
            }

            var venda = new Venda(vendaRequest.Preco, vendaRequest.CpfCliente, vendaRequest.ProdutosQuantidade);

            _vendasRepository.Add(venda);

            return Created($"/api/Venda", venda);
        }
    }
}
