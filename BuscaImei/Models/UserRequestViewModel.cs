using BuscaImei.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Models
{
    public class UserRequestViewModel
    {
        [Required(ErrorMessage = "Campo Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Telefone é Obrigatório")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Somente Números")]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; }

        [Column(TypeName = "int")]
        public int Tipo { get; set; }

        [Required(ErrorMessage = "Campo Endereço é Obrigatório")]
        [Display(Name ="Endereço")]
        [Column(TypeName = "varchar(200)")]
        [StringLength(200, MinimumLength = 3, ErrorMessage =" Campo Endereço precisar ter no mínimo 3 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Bairro é Obrigatório")]
        [Column(TypeName = "varchar(50)")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Número é Obrigatório")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage ="Somente Números")]
        [Column(TypeName = "int")]
        public int Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo CEP é Obrigatório")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Somente Números")]
        [Column(TypeName = "varchar(15)")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Selecione uma Marca")]
        public MarcaEnum Marca { get; set; }

        [Required(ErrorMessage = "Selecione uma Cidade")]
        public int IdCidade { get; set; }
        [Required(ErrorMessage = "Selecione um Estado")]
        public int IdEstado { get; set; }

        //[Required(ErrorMessage = "Escolha uma Cidade")]
        //public int CidadeId { get; set; }
    }
}
