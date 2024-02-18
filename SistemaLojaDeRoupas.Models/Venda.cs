namespace SistemaLojaDeRoupas.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public string CpfCliente { get; set; }
        public string NotaFiscal { get; set; }
    }
}
