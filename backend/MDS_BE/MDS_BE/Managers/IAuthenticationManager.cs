using MDS_BE.Models;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public interface IAuthenticationManager
    {
        Task Register(RegisterUserModel registerUserModel);
        Task<TokenModel> Login(LoginUserModel loginUserModel);
    }
}
