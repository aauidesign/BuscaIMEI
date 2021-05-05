using BuscaImei.Data;
using BuscaImei.Entities;
using BuscaImei.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BuscaImei.Controllers

{

    public class DispositivoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;


        public DispositivoController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public IActionResult Cadastro(int id)
        {
            var dispositivo = new Dispositivo();

            if (id > 0)
            {
                dispositivo = _context.Dispositivos.Find(id);
            }

            return View(dispositivo);
        }

        [HttpPost]
        public IActionResult Cadastro(int id, CadastroDispositivoViewModel model)
        {
            if (id > 0)
            {
                var dispositivo = _context.Dispositivos.Find(id);
                dispositivo.Imei = model.Imei;
                dispositivo.Marca = model.Marca;
                dispositivo.Modelo = model.Modelo;
                dispositivo.Status = model.Status;

                _context.Dispositivos.Update(dispositivo);
                _context.SaveChanges();

                return RedirectToAction("Index", "Dashboard", new { msgSucesso = "Dispositivo atualizado com sucesso!" });
            }
            else
            {
                var usuarioLogadoId = _userManager.GetUserId(User);

                var dispositivo = new Dispositivo
                {
                    Imei = model.Imei,
                    Marca = model.Marca,
                    Modelo = model.Modelo,
                    Status = model.Status,
                    UsuarioFk = usuarioLogadoId
                };


                _context.Dispositivos.Add(dispositivo);
                _context.SaveChanges();

                return RedirectToAction("Index", "Dashboard", new { msgSucesso = "Dispositivo cadastrodo com sucesso!" });
            }
        }

        public IActionResult RemoverDispostivo(int id)
        {
            var dispositivo = _context.Dispositivos.Find(id);

            _context.Dispositivos.Remove(dispositivo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Dashboard", new { msgSucesso = "Dispositivo Excluido com sucesso!" });
        }

        public async Task<IActionResult> Detalhe(int? id, DispositivoAuxViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivos
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.IdDispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }


            return View(dispositivo);
        }

        [HttpGet]
        public IActionResult Busca()
        {
            var search = Request.Query["Search"].ToString();

            var dispositivos = _context.Dispositivos.Where(x => x.Imei.Contains(search));

            ViewBag.Search = search;
            return View(dispositivos);
        }

    } 
}
