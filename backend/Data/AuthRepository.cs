using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<ServiceResponse<int>> Register(Player user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await PlayerExists(user.Login))
            {
                response.Success = false;
                response.Message = "Player already exists.";
                return response;
            }
            
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Players.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<ServiceResponse<string>> Login(string login, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Player user = await _context.Players.FirstOrDefaultAsync(x => x.Login.ToLower().Equals(login.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "Player not found.";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = user.Id.ToString();
            }

            return response;
        }

        public async Task<bool> PlayerExists(string login)
        {
            if (await _context.Players.AnyAsync(x => x.Login.ToLower() == login.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}