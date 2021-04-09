using BuscaImei.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public string Nome { get; set; }

        [Column(TypeName = "int")]
        public int Tipo { get; set; }
    }

}
