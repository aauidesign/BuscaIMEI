using BuscaImei.Data;
using BuscaImei.Entities;
using BuscaImei.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BuscaImei.Controllers
{
    public class DispositivoEncontradoController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;


        public DispositivoEncontradoController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {

            var usuárioLocado = _userManager.GetUserId(User);
            var listaDispositivosEncontrados =  _context.DispositivoEncontrados.Where(x => x.UsuarioFk == usuárioLocado).ToList();

            return View(listaDispositivosEncontrados);
        }

        [HttpGet]
        public IActionResult CadastroDispositivoEncontrado()
        {
            List<Cidade> cidades = new List<Cidade>();
            cidades = (from c in _context.Cidades select c).ToList();
            ViewBag.cidade = cidades;

            List<Estado> estados = new List<Estado>();
            estados = (from e in _context.Estados select e).ToList();
            ViewBag.estado = estados;

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastroDispositivoEncontradoViewModel model)
        {

            var usuarioLogadoId = _userManager.GetUserId(User);
            var dispositivoEncontrado = new DispositivoEncontrado
            {
                Imei = model.Imei,
                Telefone = model.Telefone,
                Marca = model.Marca,
                Logradouro = model.Logradouro,
                Bairro = model.Bairro,
                Complemento = model.Complemento,
                Numero = model.Numero,
                Cep = model.Cep,
                CidadeFK = model.IdCidade,
                UsuarioFk = usuarioLogadoId
            };


            _context.DispositivoEncontrados.Add(dispositivoEncontrado);
            _context.SaveChanges();

            return RedirectToAction("Index", "Dashboard", new { msgSucesso = "Dispositivo cadastrodo com sucesso!" });
        }

        public IActionResult AparelhoEncontrado()
        {
            return View();
        }
    }
}
