using MDS_BE.Entities;
using MDS_BE.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MDS_BE.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> registerManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> registerManager, ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.registerManager = registerManager;
            this.tokenManager = tokenManager;

        }

        public async Task Register(RegisterUserModel registerUserModel)
        {
            var user = new User
            {
                Email = registerUserModel.Email,
                UserName = registerUserModel.Email
            };

            // Parola va fi hash-uita si salvata in forma respectiva in DB
            var result = await userManager.CreateAsync(user, registerUserModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerUserModel.RoleId);
            }
        }

        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user != null)
            {
                var result = await registerManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if (result.Succeeded)
                {
                    //Create token
                    var token = await tokenManager.CreateToken(user); //new manager responsible with creating the token
                    var userData = new UserModel
                    {
                        Id = user.Id,
                        Name = user.UserName,
                    };
                    return new TokenModel
                    {
                        Token = token,
                        User = userData
                    };
                }
            }

            return null;
        }
    }
}