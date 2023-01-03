
using TASK8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK8.Services
{
    public class PrescriptionRepository : IPrescriptionRepository
    {


        public static MainDbContext _db;
        public PrescriptionRepository(MainDbContext db)
        {
            _db = db;
        }

        public async Task<PrescriptionDetails> GetPrescriptionDetails(int idPrescription)
        {
            PrescriptionDetails prescription = await _db.Prescription.Where(p => p.IdPrescription == 1).Select(p => new PrescriptionDetails
            {
                Patient = p.Patient,
                Doctor = p.Doctor,
                Medicaments = p.PrescriptionMedicaments.Select(x => new
                {
                    Name = x.Medicament.Name,
                    Description = x.Medicament.Description,
                    Type = x.Medicament.Type,
                    Dose = x.Dose,
                    Details = x.Details
                }).ToArray()
            }).SingleAsync();

            return prescription;
        }
    }
}