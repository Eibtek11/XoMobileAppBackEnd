using BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MobileAppDashBoard.Models.GoogleViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobileAppDashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAPIController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly JwtHandler _jwtHandler;
        private readonly UserManager<ApplicationUser> _userManager;
        public GoogleAPIController(UserManager<ApplicationUser> userManager , JwtHandler jwtHandler,IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _jwtHandler = jwtHandler;
            _userManager = userManager;
        }
        // GET: api/<GoogleAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GoogleAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GoogleAPIController>

        [HttpPost("google")]
        public async Task<IActionResult> google([FromForm] GoogleViewModel o)
        {
            var result = await _accountRepository.ExternalLoginCallbackApi(o.Provider, o.IdToken);

            if (result == null)
            {
                return Unauthorized();

            }
            return Ok(result);

        }
        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin([FromForm] ExternalAuthDto externalAuth)
        {
            var payload = await _jwtHandler.VerifyGoogleToken(externalAuth);
            if (payload == null)
                return BadRequest("Invalid External Authentication.");

            var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new ApplicationUser { Email = payload.Email, UserName = payload.Email };
                    await _userManager.CreateAsync(user);

                    //prepare and send an email for the email confirmation

                    await _userManager.AddToRoleAsync(user, "Viewer");
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    await _userManager.AddLoginAsync(user, info);
                }
            }

            if (user == null)
                return BadRequest("Invalid External Authentication.");

            //check for the Locked out account

            var token = await _jwtHandler.GenerateToken(user);
            return Ok(new AuthResponseDto { Token = token, IsAuthSuccessful = true });
        }

        // PUT api/<GoogleAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GoogleAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
