using SistemaLojaDeRoupas.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SistemaLojaDeRoupas.Models
{
    public class Devolucao
    {
        private static int _id = 1;
        public int Id { get; set; }
        public int VendaID { get; set; }
        [JsonIgnore]
        public TipoOperacao TipoOperacao { get; set; }
        public string Motivo { get; set; }
        public Dictionary<string, int> ProdutosQuantidade { get; set; }


        public Devolucao(int vendaID, TipoOperacao tipoOperacao, string motivo, Dictionary<string, int> produtosQuantidade)
        {
            Id = _id++;
            VendaID = vendaID;
            TipoOperacao = tipoOperacao;
            Motivo = motivo;
            ProdutosQuantidade = produtosQuantidade;
        }
    }
}
