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
        Task<IdentityResult> SSignUpAsync(SignUpModel signUpModel);
        Task<string> LLoginAsync(SignInModel signInModel);
    }
}
