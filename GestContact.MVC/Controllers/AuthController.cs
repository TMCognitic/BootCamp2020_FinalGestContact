using GestContact.Models.Forms;
using GestContact.Models.Repositories;
using GestContact.MVC.Inftrastructure;
using GestContact.MVC.Models;
using GestContact.MVC.Models.Client.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository<Customer> _authRepository;
        private readonly ISessionManager _sessionManager;
        private readonly ILogger _logger;

        public AuthController(IAuthRepository<Customer> authRepository, ISessionManager sessionManager, ILogger<AuthController> logger)
        {           
            _authRepository = authRepository;
            _sessionManager = sessionManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customer = _authRepository.Login(form.Email, form.Passwd);

                    if (customer is not null)
                    {
                        _sessionManager.Customer = new SessionCustomer() { Id = customer.Id, LastName = customer.LastName, FirstName = customer.FirstName };
                        return RedirectToAction("Index", "Contact");
                    }

                    ModelState.AddModelError("", "Email ou mot de passe invalide...");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ModelState.AddModelError("", "Une erreur est survenue");
                //ViewBag.Error = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _authRepository.Register(new Customer(form.LastName, form.FirstName, form.Email, form.Passwd));                    
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //ViewBag.Error = ex.Message;
            }

            return View();
        }

        [HttpGet]
        [AuthRequired]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
