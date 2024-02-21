namespace SistemaLojaDeRoupas.Models
{
    public class Venda
    {
        private static int _id = 1;
        public int Id { get; set; }
        public Dictionary<string, int> ProdutosQuantidade { get; set; } 
        public decimal Preco { get; set; }
        public string CpfCliente { get; set; }
        public Guid NotaFiscal { get; set; }

        public Venda (decimal preco, string cpfCliente, Dictionary<string, int> produtosQuantidade)
        {
            Id = _id++;
            Preco = preco;
            CpfCliente = cpfCliente;
            NotaFiscal = Guid.NewGuid();
            ProdutosQuantidade = produtosQuantidade;
        }
    }
}
