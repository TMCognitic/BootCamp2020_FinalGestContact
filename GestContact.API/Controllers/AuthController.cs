using GestContact.API.Models.Client.Entities;
using GestContact.Models.Forms;
using GestContact.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository<Customer> _repository;
        private readonly ILogger _logger;

        public AuthController(ILogger<AuthController> logger, IAuthRepository<Customer> repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm form)
        {
            if(ModelState.IsValid)
            {
                Customer customer = null;
                try
                {
                    customer = _repository.Login(form.Email, form.Passwd);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }


                if (customer is not null)
                    return Ok(customer);
                else
                    return Unauthorized();
            }

            return BadRequest();
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Register(new Customer(form.LastName, form.FirstName, form.Email, form.Passwd));
                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public LoginForm Get()
        {
            return new LoginForm() { Email = "test@test.be", Passwd = "Test1234=" };
        }
    }
}
