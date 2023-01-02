
using TASK8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK8.Services
{
    public class DoctorRepository : IDoctorRepository
    {


        public static Context _db;
        public DoctorRepository(Context db)
        {
            _db = db;
        }

        public IEnumerable<Doctor> GetAllClients()
        {
            var doctors = _db.Doctors;
            return doctors;
        }
    }
}