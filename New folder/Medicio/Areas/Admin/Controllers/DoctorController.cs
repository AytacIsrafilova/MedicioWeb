using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorServices _doctorServices;

        public DoctorController(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }

        public IActionResult Index()
        {
            var doctors = _doctorServices.GetAllDoctor();
            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if(!ModelState.IsValid)
                return View();
            try
            {
                _doctorServices.AddDoctor(doctor);
            }
            catch (DublicateDoctorException ex)
            {

                ModelState.AddModelError(ex.PropertyName,ex.Message);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");

        }
    }
}
