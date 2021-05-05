using BuscaImei.Entities;
using BuscaImei.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Models
{
    public class DispositivoEncontrado
    {
        public int IdDispositivoEncontrado { get; set; }
        public string Imei { get; set; }
        public MarcaEnum Marca { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int CidadeFK { get; set; }
        public string UsuarioFk { get; set; }


        //virtual
        public virtual Cidade Cidade { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

    }
}
