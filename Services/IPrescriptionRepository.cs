
using TASK9.Models;

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK9.Services
{
    public interface IPrescriptionRepository
    {



        public Task<PrescriptionDetails> GetPrescriptionDetails(int idPrescription);

        public void PopulateDatabase();





    }
}