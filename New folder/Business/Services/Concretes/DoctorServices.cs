using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Model;
using Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorServices(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null) throw new NullReferenceException("doctor null ola bilmez!");
            if (!_doctorRepository.GetAll().Any(x => x.Fullname == doctor.Fullname))
            {
                _doctorRepository.Add(doctor);
                _doctorRepository.Commit();
            }
            else
            {
                throw new DublicateDoctorException("Fullname", "Fullname eyni ola bilmez");
            }

        }

        public void DeleteDoctor(int id)
        {
            var existDoctor=_doctorRepository.Get(x => x.Id == id);
            if (existDoctor == null) throw new NullReferenceException("Doctor yoxdu!");
            _doctorRepository.Delete(existDoctor);
            _doctorRepository.Commit();
        }

        public List<Doctor> GetAllDoctor(Func<Doctor, bool>? func = null)
        {
           return _doctorRepository.GetAll(func);
        }

        public Doctor GetDoctor(Func<Doctor, bool>? func = null)
        {
            return _doctorRepository.Get(func);
        }

        public void UpdateDoctor(int id, Doctor newDoctor)
        {
            var existDoctor = _doctorRepository.Get(x => x.Id == id);
            if (existDoctor == null) throw new NullReferenceException("Doctor yoxdu!");
            if (!_doctorRepository.GetAll().Any(x => x.Fullname == newDoctor.Fullname))
            {
               existDoctor = newDoctor;
                _doctorRepository.Commit();
            }
            else
            {
                throw new DublicateDoctorException("Fullname", "Fullname eyni ola bilmez");
            }

        }
    }
}
