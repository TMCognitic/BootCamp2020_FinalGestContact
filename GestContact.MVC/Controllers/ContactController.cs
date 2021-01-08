using GestContact.Models.Forms;
using GestContact.Models.Repositories;
using GestContact.MVC.Inftrastructure;
using GestContact.MVC.Models;
using GestContact.MVC.Models.Client.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace GestContact.MVC.Controllers
{
    [AuthRequired]
    public class ContactController : Controller
    {
        private readonly IContactRepository<Contact> _contactRepository;
        private readonly ISessionManager _sessionManager;

        public ContactController(IContactRepository<Contact> contactRepository, ISessionManager sessionManager)
        {
            _contactRepository = contactRepository;
            _sessionManager = sessionManager;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            return View(_contactRepository.Get(_sessionManager.Customer.Id));
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            Contact contact = _contactRepository.Get(_sessionManager.Customer.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateContactForm form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Insert(new Contact(form.LastName, form.FirstName, form.Email, form.Phone, form.BirthDate, _sessionManager.Customer.Id));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //ViewBag.Error = ex.Message;
            }

            return View(form);
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {            
            Contact contact = _contactRepository.Get(_sessionManager.Customer.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(new UpdateContactForm() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName, Email = contact.Email, Phone = contact.Phone, BirthDate = contact.BirthDate });
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateContactForm form)
        {
            if (id != form.Id)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                try
                {
                    _contactRepository.Update(id, new Contact(form.LastName, form.FirstName, form.Email, form.Phone, form.BirthDate, _sessionManager.Customer.Id));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    //ViewBag.Error = ex.Message;
                }
            }

            return View(form);
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = _contactRepository.Get(_sessionManager.Customer.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact);
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _contactRepository.Delete(_sessionManager.Customer.Id, id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //ViewBag.Error = ex.Message;
            }

            return View(collection);
        }
    }
}
