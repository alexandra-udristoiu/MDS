using MDS_BE.Entities;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}