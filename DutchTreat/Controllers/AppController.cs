using System;
using Microsoft.AspNetCore.Mvc;
using DutchTreat.Models;
using DutchTreat.Contracts;
using DutchTreat.Data;
using System.Linq;
using DutchTreat.Data.Interfaces;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repo;
        public AppController(IMailService mailService, IDutchRepository repo)
        {
            _mailService = mailService;
            _repo = repo;
        }

        [HttpGet("Index")]
        public IActionResult Index() 
        {
            var result = _repo.GetAllProducts();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(model.Name, model.Subject, model.Message);
                ViewBag.userMessage = "Mail Sent";
                ModelState.Clear();
            }
            return View();
            
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.title = "About us";
            return View();
        }
        
        [HttpGet("shop")]
        public IActionResult Shop()
        {
            return View(_repo.GetAllProducts());
        }
    }
}

