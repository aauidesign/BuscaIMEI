using BuscaImei.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Models
{
    public class CadastroDispositivoEncontradoViewModel
    {
        public string Imei { get; set; }
        public MarcaEnum Marca { get; set; }

        public string Telefone { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }


    }
}
