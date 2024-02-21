using SistemaLojaDeRoupas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLojaDeRoupas.Repository
{
    public class DevolucaoRepository : IRepository<Devolucao>
    {
        private static readonly List<Devolucao> _devolucoes = new List<Devolucao>();
        public Devolucao Add(Devolucao entity)
        {
            _devolucoes.Add(entity);
            return entity;
        }

        public IEnumerable<Devolucao> GetAll()
        {
            return _devolucoes;
        }

        public Devolucao GetById(int id)
        {
            return _devolucoes.FirstOrDefault(entity => entity.Id == id);
        }
    }
}
