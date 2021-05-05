using BuscaImei.Entities;
using BuscaImei.Enum;

namespace BuscaImei.Models
{
    public class Dispositivo
    {
        public int IdDispositivo { get; set; }
        public string Modelo { get; set; }
        public string Imei { get; set; }

        public MarcaEnum Marca { get; set; }
        public StatusEnum Status { get; set; }

        public virtual ApplicationUser Usuario { get; set; }
        public string UsuarioFk { get; set; }


    }
}
