using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaLojaDeRoupas.Repository;
using SistemaLojaDeRoupas.Models;
using SistemaLojaDeRoupas.Models.Enums;
using SistemaLojaDeRoupas.API.RequestDTOs;
using System;
using EnumsNET;

namespace SistemaLojaDeRoupas.API.Controllers
{
    [EnableCors("ShopPolicy")]
    [ApiController]
    [Route("/api/Devolucao")]

    public class DevolucaoController : ControllerBase
    {
        private readonly IRepository<Devolucao> _devolucaoRepository;

        public DevolucaoController(IRepository<Devolucao> devolucaoRepository)
        {
            _devolucaoRepository = devolucaoRepository;
        }

        [HttpGet]

        public IActionResult GetDevolucoes()
        {
            var devolucoes = _devolucaoRepository.GetAll();

            List<object> list = new List<object>();

            foreach(var devolucao in devolucoes)
            {
                list.Add(new
                {
                    devolucao.Id,
                    VendaId = devolucao.VendaID,
                    TipoOperacao = devolucao.TipoOperacao.AsString(EnumFormat.Description),
                    devolucao.Motivo
                });
            }

            return Ok(list);
        }

        [HttpGet("Troca")]
        public IActionResult GetTroca()
        {
            return Ok(_devolucaoRepository.GetAll().Where(entity => entity.TipoOperacao == TipoOperacao.Troca));
        }

        [HttpGet("Reembolso")]
        public IActionResult GetReembolso()
        {
            return Ok(_devolucaoRepository.GetAll().Where(entity => entity.TipoOperacao == TipoOperacao.Reembolso));
        }

        [HttpGet("Troca/{id}")]
        public IActionResult GetTrocaByID(int id)
        {
            return Ok(_devolucaoRepository.GetAll().FirstOrDefault(entity => entity.Id == id && entity.TipoOperacao == TipoOperacao.Troca));
        }


        [HttpGet("Reembolso/{id}")]
        public IActionResult GetReembolsoByID(int id)
        {
            return Ok(_devolucaoRepository.GetAll().Where(entity => entity.Id == id && entity.TipoOperacao == TipoOperacao.Reembolso));
        }

        [HttpPost("Troca")]
        public IActionResult PostTroca([FromBody] DevolucaoRequest devolucaoDTO)
        {
            var devolucao = new Devolucao(devolucaoDTO.VendaId, TipoOperacao.Troca, devolucaoDTO.Motivo, devolucaoDTO.ProdutosQuantidade);
            return Ok(_devolucaoRepository.Add(devolucao));
        }

        [HttpPost("Reembolso")]
        public IActionResult PostReembolso([FromBody] DevolucaoRequest devolucaoDTO)
        {
            var devolucao = new Devolucao(devolucaoDTO.VendaId, TipoOperacao.Reembolso, devolucaoDTO.Motivo, devolucaoDTO.ProdutosQuantidade);
            return Ok(_devolucaoRepository.Add(devolucao));
        }
    }
}
