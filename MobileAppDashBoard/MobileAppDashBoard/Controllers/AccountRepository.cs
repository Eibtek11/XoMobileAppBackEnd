using BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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



        public async Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel)
        {
            
                if (signUpModel.PersonalImage != null)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await signUpModel.PersonalImage.CopyToAsync(stream);
                    }
                signUpModel.image = ImageName;
                }
         
            var user = new ApplicationUser()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.image,
                Email = signUpModel.Email,
                UserName = signUpModel.Email,
                
            };
            await Usermanager.CreateAsync(user, signUpModel.Password);
            var res2 = Usermanager.Users.Where(a => a.UserName == user.Email).FirstOrDefault();
            return res2;
        }

        public async Task<ApplicationUser> LLoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, true, true);

            if (!result.Succeeded)
            {
                return null;
            }
            else
            {

                var res2 =Usermanager.Users.Where(a => a.UserName == signInModel.Email).FirstOrDefault();

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
