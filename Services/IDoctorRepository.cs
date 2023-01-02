
using TASK7.Models;

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK7.Services
{
    public interface ITripRepository
    {



        public IEnumerable<Client> GetAllClients();
        // public bool ClientAlreadyExist(string Pesel);

        public Task<Client> AddNewClient(InputForm InputForm);

        public bool IsDuplicateBooking(int idClient, int IdTrip);
        public bool TripExists(int IdTrip);
        public Task<ClientTrip> AddClientToTrip(int clientId, InputForm inputForm);

        public Task<IEnumerable<object>> GetAllTrips();
        public bool ClientHasTrips(int idClient);
        public bool ClientExists(int idClient);
        public Task DeleteClientyID(int idClient);

    }
}