using BuscaImei.Entities;
using BuscaImei.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaImei.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;


        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(CadastroViewModel model)
        {
            var novoUsuario = new ApplicationUser()
            {
                Nome = model.Nome,
                Email = model.Email,
                UserName = model.Email
            };

            var resultado = await _userManager.CreateAsync(novoUsuario, model.Senha);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Login", "Home", new { msgSucesso = "Cadastro com sucesso!" });
            }
            else
            {
                //auth/cadastro?msgErro=Ocorreu um erro ao realizar cadastro!
            }

            return RedirectToAction("Cadastro", "Home", new { msgErro = "Ocorreu um erro ao realizar cadastro!" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var resultado = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, true, false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Login", "Home", new { msgErro = "Email ou senha inválidos!" });
        }
    }
}
