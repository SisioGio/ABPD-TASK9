
using TASK9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK9.Services
{
    public class PrescriptionRepository : IPrescriptionRepository
    {

        // Methods to work with the Prescription  table
        public static MainDbContext _db;
        public PrescriptionRepository(MainDbContext db)
        {
            _db = db;
        }

        public async void PopulateDatabase()
        {


            // API for adding new entries into DB

            // Remove all data
            foreach (PrescriptionMedicament pmed in _db.PrescriptionMedicament)
            {
                _db.Remove(pmed);

            }

            foreach (Prescription pres in _db.Prescription)
            {
                _db.Remove(pres);

            }
            foreach (Doctor doc in _db.Doctors)
            {
                _db.Remove(doc);

            }
            foreach (Patient pt in _db.Patient)
            {
                _db.Remove(pt);

            }

            foreach (Medicament med in _db.Medicament)
            {
                _db.Remove(med);

            }


            await _db.SaveChangesAsync();

            // Enter new data
            Doctor doc1 = new Doctor { FirstName = "Doc_Name_1", LastName = "Doc_Surname_1", Email = "Doc_Email_1@gmail.com" };
            _db.Add(doc1);
            Doctor doc2 = new Doctor { FirstName = "Doc_Name_2", LastName = "Doc_Surname_2", Email = "Doc_Email_2@gmail.com" };
            _db.Add(doc2);
            Doctor doc3 = new Doctor { FirstName = "Doc_Name_3", LastName = "Doc_Surname_3", Email = "Doc_Email_3@gmail.com" };
            _db.Add(doc3);
            Doctor doc4 = new Doctor { FirstName = "Doc_Name_4", LastName = "Doc_Surname_4", Email = "Doc_Email_4@gmail.com" };
            _db.Add(doc4);
            await _db.SaveChangesAsync();

            Patient pat1 = new Patient { FirstName = "Pat_Name_1", LastName = "Pat_Surname_1", Birthdate = DateTime.Now };
            Patient pat2 = new Patient { FirstName = "Pat_Name_2", LastName = "Pat_Surname_2", Birthdate = DateTime.Now };
            Patient pat3 = new Patient { FirstName = "Pat_Name_3", LastName = "Pat_Surname_3", Birthdate = DateTime.Now };
            _db.Add(pat1);
            _db.Add(pat2);
            _db.Add(pat3);

            await _db.SaveChangesAsync();
            Medicament med1 = new Medicament { Name = "Med1", Description = "Med1_Desc", Type = "Type1" };
            Medicament med2 = new Medicament { Name = "Med2", Description = "Med2_Desc", Type = "Type2" };
            Medicament med3 = new Medicament { Name = "Med3", Description = "Med3_Desc", Type = "Type3" };
            _db.Add(med1);
            _db.Add(med2);
            _db.Add(med3);
            await _db.SaveChangesAsync();
            Prescription prescr1 = new Prescription { IdDoctor = doc1.IdDoctor, IdPatient = pat1.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(10) };
            Prescription prescr2 = new Prescription { IdDoctor = doc1.IdDoctor, IdPatient = pat2.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(20) };
            Prescription prescr3 = new Prescription { IdDoctor = doc2.IdDoctor, IdPatient = pat1.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(30) };
            Prescription prescr4 = new Prescription { IdDoctor = doc2.IdDoctor, IdPatient = pat2.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(40) };
            Prescription prescr5 = new Prescription { IdDoctor = doc2.IdDoctor, IdPatient = pat3.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(50) };
            Prescription prescr6 = new Prescription { IdDoctor = doc3.IdDoctor, IdPatient = pat1.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(60) };
            Prescription prescr7 = new Prescription { IdDoctor = doc3.IdDoctor, IdPatient = pat2.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(70) };
            Prescription prescr8 = new Prescription { IdDoctor = doc3.IdDoctor, IdPatient = pat3.IdPatient, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(80) };
            _db.Add(prescr1);
            _db.Add(prescr2);
            _db.Add(prescr3);
            _db.Add(prescr4);
            _db.Add(prescr5);
            _db.Add(prescr6);
            _db.Add(prescr7);
            _db.Add(prescr8);
            await _db.SaveChangesAsync();

            PrescriptionMedicament pr_med_1 = new PrescriptionMedicament { IdPrescription = prescr1.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 1, Details = "sdfsdfsdf" };
            PrescriptionMedicament pr_med_2 = new PrescriptionMedicament { IdPrescription = prescr1.IdPrescription, IdMedicament = med2.IdMedicament, Dose = 2, Details = "Detail 2" };
            PrescriptionMedicament pr_med_3 = new PrescriptionMedicament { IdPrescription = prescr2.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 3, Details = "Detail 3" };
            PrescriptionMedicament pr_med_4 = new PrescriptionMedicament { IdPrescription = prescr2.IdPrescription, IdMedicament = med2.IdMedicament, Dose = 1, Details = "Detail 4" };
            PrescriptionMedicament pr_med_5 = new PrescriptionMedicament { IdPrescription = prescr2.IdPrescription, IdMedicament = med3.IdMedicament, Dose = 2, Details = "Detail 5" };
            PrescriptionMedicament pr_med_6 = new PrescriptionMedicament { IdPrescription = prescr3.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 3, Details = "Detail 6" };
            PrescriptionMedicament pr_med_7 = new PrescriptionMedicament { IdPrescription = prescr4.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 1, Details = "Detail 7" };
            PrescriptionMedicament pr_med_8 = new PrescriptionMedicament { IdPrescription = prescr4.IdPrescription, IdMedicament = med2.IdMedicament, Dose = 2, Details = "Detail 8" };
            PrescriptionMedicament pr_med_9 = new PrescriptionMedicament { IdPrescription = prescr5.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 3, Details = "Detail 9" };
            PrescriptionMedicament pr_med_10 = new PrescriptionMedicament { IdPrescription = prescr5.IdPrescription, IdMedicament = med2.IdMedicament, Dose = 10, Details = "sdfsdfsdf0" };
            PrescriptionMedicament pr_med_11 = new PrescriptionMedicament { IdPrescription = prescr5.IdPrescription, IdMedicament = med3.IdMedicament, Dose = 11, Details = "sdfsdfsdf1" };
            PrescriptionMedicament pr_med_12 = new PrescriptionMedicament { IdPrescription = prescr6.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 12, Details = "sdfsdfsdf2" };
            PrescriptionMedicament pr_med_13 = new PrescriptionMedicament { IdPrescription = prescr7.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 13, Details = "sdfsdfsdf3" };
            PrescriptionMedicament pr_med_14 = new PrescriptionMedicament { IdPrescription = prescr7.IdPrescription, IdMedicament = med2.IdMedicament, Dose = 1, Details = "sdfsdfsdf" };
            PrescriptionMedicament pr_med_15 = new PrescriptionMedicament { IdPrescription = prescr8.IdPrescription, IdMedicament = med1.IdMedicament, Dose = 1, Details = "sdfsdfsdf" };
            PrescriptionMedicament pr_med_16 = new PrescriptionMedicament { IdPrescription = prescr8.IdPrescription, IdMedicament = med2.IdMedicament, Dose = 1, Details = "sdfsdfsdf" };
            PrescriptionMedicament pr_med_17 = new PrescriptionMedicament { IdPrescription = prescr8.IdPrescription, IdMedicament = med3.IdMedicament, Dose = 1, Details = "sdfsdfsdf" };

            _db.Add(pr_med_1);
            _db.Add(pr_med_2);
            _db.Add(pr_med_3);
            _db.Add(pr_med_3);
            _db.Add(pr_med_4);
            _db.Add(pr_med_5);
            _db.Add(pr_med_6);
            _db.Add(pr_med_7);
            _db.Add(pr_med_8);
            _db.Add(pr_med_9);
            _db.Add(pr_med_10);
            _db.Add(pr_med_11);
            _db.Add(pr_med_12);
            _db.Add(pr_med_13);
            _db.Add(pr_med_14);
            _db.Add(pr_med_15);
            _db.Add(pr_med_16);
            _db.Add(pr_med_17);

            await _db.SaveChangesAsync();








        }
        public async Task<PrescriptionDetails> GetPrescriptionDetails(int idPrescription)
        {

            // Getting prescription details by using the class PrescriptionDetails as output model
            PrescriptionDetails prescription = await _db.Prescription.Where(p => p.IdPrescription == idPrescription).Select(p => new PrescriptionDetails
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