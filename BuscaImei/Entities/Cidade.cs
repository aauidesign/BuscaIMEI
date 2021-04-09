using BuscaImei.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Models
{
    public class Cidade
    {

        public int IdCidade { get; set; }
        public string Nome { get; set; }

        public Estado Estado { get; set; }
        public int EstadoFk { get; set; }

    }
}
