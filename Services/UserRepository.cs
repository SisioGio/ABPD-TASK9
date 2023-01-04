
using TASK9.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace TASK9.Services
{
    public class UserRepository : IUserRepository
    {


        public static MainDbContext _db;
        public UserRepository(MainDbContext db)
        {
            _db = db;
        }

        public async Task<User> AddUser(UserDTO userDTO)
        {

            string HashedPassword = HashPasword(userDTO.Password, out var salt);
            User user = new User
            {
                Username = userDTO.Username,
                Password = HashedPassword,
                Salt = Convert.ToHexString(salt)

            };
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByUsername(string username)
        {

            return await _db.User.SingleOrDefaultAsync(c => c.Username == username);
        }
        public bool CheckIfUserExists(UserDTO userDTO)
        {

            return _db.User.Any(c => c.Username == userDTO.Username);
        }

        public bool CheckCredentials(UserDTO userDTO)
        {

            return _db.User.Any(c => c.Username == userDTO.Username && c.Password == userDTO.Password);
        }

        public async Task<User> Login(UserDTO userDTO)
        {

            User user = _db.User.Where(c => c.Username == userDTO.Username).Single();
            Console.WriteLine("Veryfing credentials...");
            if (!VerifyPassword(userDTO.Password, user.Password, Convert.FromHexString(user.Salt)))
            {
                Console.WriteLine("Password is not correct");
                return null;
            }

            return user;

        }

        public async Task<User> AssignRefreshTokenDat(User user, string RefreshToken)
        {

            user.RefreshToken = RefreshToken;
            user.RefreshTokenExpirationDate = DateTime.Now.AddDays(7);
            await _db.SaveChangesAsync();
            return user;
        }

        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(64);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                100000,
                HashAlgorithmName.SHA512,
                64);
            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            Console.WriteLine("Salt is: " + Convert.ToHexString(salt));
            Console.WriteLine("Hash is " + hash);
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA512, 64);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}