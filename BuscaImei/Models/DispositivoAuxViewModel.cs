using BuscaImei.Entities;
using BuscaImei.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Models
{
    public class DispositivoAuxViewModel
    {
        //Dispositivo
        public int Id { get; set; }
        public int IdDispositivo { get; set; }
        public string Modelo { get; set; }
        public string Imei { get; set; }
        public MarcaEnum Marca { get; set; }
        public StatusEnum Status { get; set; }
        public string UsuarioFk { get; set; }

        //DispositivoEncontrado
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }

        public int CidadeFK { get; set; }


        //virtual
        public virtual Cidade Cidade { get; set; }

        //Virtual
        public virtual ApplicationUser Usuario { get; set; }
        public virtual Dispositivo Dispositivo { get; set; }
        public virtual DispositivoEncontrado DispositivoEncontrado { get; set; }

    }
}
