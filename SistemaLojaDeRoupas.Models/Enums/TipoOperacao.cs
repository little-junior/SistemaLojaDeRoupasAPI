using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLojaDeRoupas.Models.Enums
{
    public enum TipoOperacao
    {
        [Description("Troca")]
        Troca = 1,
        [Description("Reembolso")]
        Reembolso
    }
}
