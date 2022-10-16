using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAppDashBoard.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginApiController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public UserLoginApiController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel signUpModel)
        {
            var result = await _accountRepository.SSignUpAsync(signUpModel);

            if (result == null)
            {
                return Unauthorized();
               
            }
            return Ok(result);

        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LLoginAsync(signInModel);

            if (result == null )
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
