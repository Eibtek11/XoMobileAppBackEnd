using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Controllers
{
    public interface IAccountRepository
    {
        Task<List<TbTrUserCountryLaw>> aaRecord(string id);
        Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel);
        Task<ApplicationUser> LLoginAsync(SignInModel signInModel);

        Task<ApplicationUser> EditUsers(EditUserViewModel editModel);
        Task<ApplicationUser> EditUsersImage(EditUserViewModel editModel);
        
        Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel model, IFormFileCollection files);
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user, IFormFileCollection files);
        Task SendForgotPasswordEmail(ApplicationUser user, string token, IFormFileCollection files);
    }
}
