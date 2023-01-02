
using TASK8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK8.Services
{
    public class DoctorRepository : IDoctorRepository
    {


        public static MainDbContext _db;
        public DoctorRepository(MainDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            var doctors = await _db.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> GetDoctorByID(int idDoctor)
        {
            var doctor = await _db.Doctors.Where(d => d.IdDoctor == idDoctor).ToListAsync();
            return doctor[0];
        }

        public async Task<Doctor> AddDoctor(DoctorForm form)
        {
            Doctor doctor = new Doctor
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email
            };

            _db.Add(doctor);
            await _db.SaveChangesAsync();


            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(DoctorForm form)
        {
            Doctor doctor;
            try
            {
                doctor = await _db.Doctors.SingleAsync(d => d.IdDoctor == form.IdDoctor);
            }
            catch
            {
                throw new Exception($"Doctor with ID = {form.IdDoctor} does not exist");
            }

            doctor.FirstName = form.FirstName;
            doctor.LastName = form.LastName;
            doctor.Email = form.Email;

            _db.SaveChangesAsync();



            return doctor;
        }
        public async Task<IEnumerable<Doctor>> DeleteDoctor(int idDoctor)
        {
            Doctor doctor;
            try
            {
                doctor = await _db.Doctors.SingleAsync(d => d.IdDoctor == idDoctor);
            }
            catch
            {
                throw new Exception($"Doctor with ID = {idDoctor} does not exist");
            }

            _db.Remove(doctor);
            await _db.SaveChangesAsync();
            return await _db.Doctors.ToListAsync();
        }
    }
}