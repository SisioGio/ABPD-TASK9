
using TASK8.Models;

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK8.Services
{
    public interface IPrescriptionRepository
    {



        public Task<PrescriptionDetails> GetPrescriptionDetails(int idPrescription);

        public void PopulateDatabase();





    }
}