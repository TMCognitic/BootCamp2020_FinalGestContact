using GestContact.API.Models.Client.Entities;
using GestContact.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestContact.Models.Forms;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository<Contact> _repository;

        public ContactController(IContactRepository<Contact> repository)
        {
            _repository = repository;
        }

        // GET: api/<ContactController>
        [HttpGet("{customerId}")]
        public IActionResult Get(int customerId)
        {
            try
            {
                IEnumerable<Contact> contacts = _repository.Get(customerId).ToList();
                return Ok(contacts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<ContactController>/5
        [HttpGet("{customerId}/{id}")]
        public IActionResult Get(int customerId, int id)
        {
            try
            {
                return Ok(_repository.Get(customerId, id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<ContactController>
        [HttpPost("{customerId}")]
        public IActionResult Post(int customerId, [FromBody] CreateContactForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Insert(new Contact(form.LastName, form.FirstName, form.Email, form.Phone, form.BirthDate, customerId));
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut("{customerId}/{id}")]
        public IActionResult Put(int customerId, int id, [FromBody] UpdateContactForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(id, new Contact(form.LastName, form.FirstName, form.Email, form.Phone, form.BirthDate, customerId));
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{customerId}/{id}")]
        public IActionResult Delete(int customerId, int id)
        {
            try
            {
                _repository.Delete(customerId, id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
