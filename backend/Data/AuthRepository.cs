using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._context = context;
        }

        public async Task<ServiceResponse<int>> Register(Player user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await PlayerExists(user.Login))
            {
                response.Success = false;
                response.Message = "Nick já existe.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Players.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            response.Message = "Jogador Cadastrado!";
            return response;
        }

        public async Task<ServiceResponse<string>> Login(string login, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            Player player = await _context.Players.FirstOrDefaultAsync(x => x.Login.ToLower().Equals(login.ToLower()));
            if (player == null)
            {
                response.Success = false;
                response.Message = "Jogador não encontrado.";
            }
            else if (!VerifyPasswordHash(password, player.PasswordHash, player.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Senha incorreta.";
            }
            else
            {
                response.Data = response.Data = CreateToken(player);
                response.Message = ""+player.Id;
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

        private string CreateToken(Player player)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, player.Id.ToString()),
                new Claim(ClaimTypes.Name, player.Login)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}