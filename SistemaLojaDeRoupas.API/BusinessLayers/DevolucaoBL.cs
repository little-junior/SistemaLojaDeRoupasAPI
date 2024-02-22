using SistemaLojaDeRoupas.API.CustomExceptions;
using SistemaLojaDeRoupas.API.RequestDTOs;
using SistemaLojaDeRoupas.Models;
using SistemaLojaDeRoupas.Repository;

namespace SistemaLojaDeRoupas.API.BusinessLayers
{
    public class DevolucaoBL
    {
        private readonly IRepository<Venda> _vendaRepository;

        public DevolucaoBL(IRepository<Venda> vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public void ValidateRequestProdutosQuantidade(DevolucaoRequest devolucaoRequest)
        {
            if (devolucaoRequest.ProdutosQuantidade.Count == 0)
            {
                throw new CustomException("The 'produtosQuantidade' field can't be empty", 400);
            }
        }

        public void ValidateRequestMotivo(DevolucaoRequest devolucaoRequest)
        {

            if (String.IsNullOrEmpty(devolucaoRequest.Motivo))
            {
                throw new CustomException("The 'motivo' field can't be empty", 400);
            }
        }

        public void ValidateRequestVendaId(DevolucaoRequest devolucaoRequest)
        {
            var vendaSearch = _vendaRepository.GetById(devolucaoRequest.VendaId);

            if (vendaSearch == null)
            {
                throw new CustomException("There is not a 'venda' with the specified id", StatusCodes.Status400BadRequest);
            }
        }
    }
}
