using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaLojaDeRoupas.Models;

namespace SistemaLojaDeRoupas.Repository
{
    public class VendaRepository : IRepository<Venda>
    {
        private static readonly List<Venda> _vendas = new List<Venda>();

        public Venda Add(Venda entity)
        {
            _vendas.Add(entity);
            return entity;
        }

        public IEnumerable<Venda> GetAll()
        {
            return _vendas;
        }

        public Venda GetById(int id)
        {
            return _vendas.FirstOrDefault(element => element.Id == id);
        }
    }
}
