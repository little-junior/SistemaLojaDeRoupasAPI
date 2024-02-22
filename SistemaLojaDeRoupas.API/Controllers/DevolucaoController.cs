using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaLojaDeRoupas.Repository;
using SistemaLojaDeRoupas.Models;
using SistemaLojaDeRoupas.Models.Enums;
using SistemaLojaDeRoupas.API.RequestDTOs;
using System;
using EnumsNET;
using SistemaLojaDeRoupas.API.CustomExceptions;
using SistemaLojaDeRoupas.API.BusinessLayers;

namespace SistemaLojaDeRoupas.API.Controllers
{
    [EnableCors("ShopPolicy")]
    [ApiController]
    [Route("/api/Devolucao")]

    public class DevolucaoController : ControllerBase
    {
        private readonly IRepository<Devolucao> _devolucaoRepository;
        private readonly DevolucaoBL _devolucaoBL;

        public DevolucaoController(IRepository<Devolucao> devolucaoRepository, DevolucaoBL devolucaoBL)
        {
            _devolucaoRepository = devolucaoRepository;
            _devolucaoBL = devolucaoBL;
        }

        [HttpGet]

        public IActionResult GetDevolucoes()
        {
            var devolucoes = _devolucaoRepository.GetAll();

            var list = new List<object>();

            foreach (var devolucao in devolucoes)
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
        public IActionResult GetTrocas()
        {
            var trocas = _devolucaoRepository.GetAll().Where(entity => entity.TipoOperacao == TipoOperacao.Troca);

            return Ok(trocas);
        }

        [HttpGet("Reembolso")]
        public IActionResult GetReembolsos()
        {
            var reembolsos = _devolucaoRepository.GetAll().Where(entity => entity.TipoOperacao == TipoOperacao.Troca);

            return Ok(reembolsos);
        }

        [HttpGet("Troca/{id}")]
        public IActionResult GetTrocaByID(int id)
        {
            var troca = _devolucaoRepository.GetAll().FirstOrDefault(entity => entity.Id == id && entity.TipoOperacao == TipoOperacao.Troca);

            if (troca == null)
                throw new CustomException("Object not found", StatusCodes.Status404NotFound);

            return Ok(troca);
        }


        [HttpGet("Reembolso/{id}")]
        public IActionResult GetReembolsoByVendaID(int id)
        {
            var reembolso = _devolucaoRepository.GetAll().Where(entity => entity.Id == id && entity.TipoOperacao == TipoOperacao.Reembolso);

            if (reembolso == null)
                throw new CustomException("Object not found", StatusCodes.Status404NotFound);

            return Ok(reembolso);
        }

        [HttpPost("Troca")]
        public IActionResult PostTroca([FromBody] DevolucaoRequest devolucaoRequest)
        {
            _devolucaoBL.ValidateRequestProdutosQuantidade(devolucaoRequest);
            _devolucaoBL.ValidateRequestMotivo(devolucaoRequest);
            _devolucaoBL.ValidateRequestVendaId(devolucaoRequest);

            var troca = new Devolucao(devolucaoRequest.VendaId, TipoOperacao.Troca, devolucaoRequest.Motivo, devolucaoRequest.ProdutosQuantidade);
            _devolucaoRepository.Add(troca);

            return Created($"/api/Devolucao/Troca", troca);
        }

        [HttpPost("Reembolso")]
        public IActionResult PostReembolso([FromBody] DevolucaoRequest devolucaoRequest)
        {
            _devolucaoBL.ValidateRequestProdutosQuantidade(devolucaoRequest);
            _devolucaoBL.ValidateRequestMotivo(devolucaoRequest);
            _devolucaoBL.ValidateRequestVendaId(devolucaoRequest);

            var reembolso = new Devolucao(devolucaoRequest.VendaId, TipoOperacao.Reembolso, devolucaoRequest.Motivo, devolucaoRequest.ProdutosQuantidade);
            _devolucaoRepository.Add(reembolso);

            return Created($"/api/Devolucao/Reembolso", reembolso);
        }
    }
}
