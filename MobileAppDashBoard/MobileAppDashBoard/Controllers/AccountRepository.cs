using BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Controllers
{
    public class AccountRepository : IAccountRepository
    {
        MobileAppDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        private readonly IConfiguration _configuration;
        public AccountRepository(IConfiguration configuration, MobileAppDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            _configuration = configuration;


        }



        public async Task<IdentityResult> SSignUpAsync(SignUpModel signUpModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email,
                
            };

            return await Usermanager.CreateAsync(user, signUpModel.Password);
        }

        public async Task<string> LLoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, true, true);

            if (!result.Succeeded)
            {
                return null;
            }
            else
            {

                var res2 =Usermanager.Users.Where(a => a.UserName == signInModel.Email).FirstOrDefault().Id.ToString();

                return res2;
            }

            //var authClaims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, signInModel.Email),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};
            //var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            //var token = new JwtSecurityToken(
            //    issuer: _configuration["JWT:ValidIssuer"],
            //    audience: _configuration["JWT:ValidAudience"],
            //    expires: DateTime.Now.AddDays(1),
            //    claims: authClaims,
            //    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            //    );

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
