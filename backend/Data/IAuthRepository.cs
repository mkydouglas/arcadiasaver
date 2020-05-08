using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Player player, string password);
        Task<ServiceResponse<string>> Login(string playername, string password);
        Task<bool> PlayerExists(string playername);
    }
}