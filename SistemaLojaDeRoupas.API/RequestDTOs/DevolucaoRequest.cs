using SistemaLojaDeRoupas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaLojaDeRoupas.API.RequestDTOs
{
    public class DevolucaoRequest
    {
        [Required]
        public int VendaId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Motivo { get; set; }
        [Required]
        public Dictionary<string, int> ProdutosQuantidade { get; set; }
    }
}
