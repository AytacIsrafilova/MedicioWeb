using Business.Services.Abstracts;
using Core.Model;
using Medicio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Medicio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoctorServices _doctorService;

        public HomeController(IDoctorServices doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            List<Doctor>doctors= _doctorService.GetAllDoctor();
            return View(doctors);


        }

        
    }
}