using BuscaImei.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Models
{
    public class CadastroDispositivoViewModel
    {
        [Required(ErrorMessage ="Campo Model é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo Imei é obrigatório")]
        public string Imei { get; set; }
        
        [Required(ErrorMessage = "Campo Marca é obrigatório")]
        public MarcaEnum Marca { get; set; }
        
        [Required(ErrorMessage = "Campo Status é obrigatório")]
        public StatusEnum Status { get; set; }
    }
}
