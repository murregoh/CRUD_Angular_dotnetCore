using System;
using Microsoft.AspNetCore.Mvc;
using DutchTreat.Models;
using DutchTreat.Contracts;
using DutchTreat.Data;
using System.Linq;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly DutchContext _context;
        public AppController(IMailService mailService, DutchContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index() 
        {
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
        public IActionResult Shop(){
            var result = from p in _context.Products
                            orderby p.Category
                            select p;

            return View(result.ToList());
        }
    }
}

