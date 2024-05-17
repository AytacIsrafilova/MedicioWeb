using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IDoctorServices
    {
        void AddDoctor(Doctor doctor);
        void DeleteDoctor(int id);
        void UpdateDoctor(int id, Doctor newDoctor);
        Doctor GetDoctor(Func<Doctor, bool>? func=null);
        List<Doctor> GetAllDoctor(Func<Doctor, bool>? func = null);


    }
}
