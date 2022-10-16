using BL;
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
        Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel);
        Task<ApplicationUser> LLoginAsync(SignInModel signInModel);
    }
}
