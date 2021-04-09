using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BuscaImei.Models;
using BuscaImei.Entities;
using Microsoft.AspNetCore.Authorization;
using BuscaImei.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BuscaImei.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {

        //Instanciando o db com Entity
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;



        public DashboardController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioLogadoId = _userManager.GetUserId(User);
            var listaFK = await _context.Dispositivos.Where(x => x.UsuarioFk == usuarioLogadoId).ToListAsync();

            return View(listaFK);
        }

        public ActionResult Configuracao()
        {
            return View();
        }
    }
}
