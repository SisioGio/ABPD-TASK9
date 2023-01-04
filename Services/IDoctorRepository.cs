
using TASK9.Models;

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK9.Services
{
    public interface IDoctorRepository
    {



        public Task<IEnumerable<Doctor>> GetAllDoctors();

        public Task<Doctor> GetDoctorByID(int idDoctor);

        public Task<Doctor> AddDoctor(DoctorForm form);
        public Task<Doctor> UpdateDoctor(DoctorForm form);
        public Task<IEnumerable<Doctor>> DeleteDoctor(int idDoctor);





    }
}