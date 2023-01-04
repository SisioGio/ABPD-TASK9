
using TASK9.Models;

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TASK9.Services
{
    public interface IUserRepository
    {


        public Task<User> AddUser(UserDTO userDTO);
        public bool CheckIfUserExists(UserDTO userDTO);

        public bool CheckCredentials(UserDTO userDTO);

        public Task<User> Login(UserDTO userDTO);
        public Task<User> AssignRefreshTokenDat(User user, string RefreshToken);

        public Task<User> GetUserByUsername(string username);



    }
}