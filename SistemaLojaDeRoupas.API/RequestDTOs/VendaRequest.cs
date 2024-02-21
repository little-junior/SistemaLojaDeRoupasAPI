using System.ComponentModel.DataAnnotations;

namespace SistemaLojaDeRoupas.API.RequestDTOs
{
    public class VendaRequest
    {
        [Required]
        public decimal Preco { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string CpfCliente { get; set; }
        [Required]
        public Dictionary<string, int> ProdutosQuantidade { get; set; }
    }
}
