using BL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MobileAppDbContext ctx;
        public HomeController(ILogger<HomeController> logger , MobileAppDbContext context)
        {
            _logger = logger;
            ctx = context;
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult IndexCountries()
        {
            HomePageModel model = new HomePageModel();
            model.lstCountries = ctx.TbCountries.ToList();
            ViewBag.Countries = ctx.TbCountries.ToList();
            return View(model);
        }
        public IActionResult LawPages(Guid id)
        {

            HomePageModel model = new HomePageModel();
            model.lstLaws = ctx.TbLaws.ToList().Where(a=>a.CountryId == id);
            model.lstLevels = ctx.TbLevels.ToList();
            return View(model);
        }
        public IActionResult Levels(Guid id)
        {

            HomePageModel model = new HomePageModel();
            model.lstQuestions = ctx.TbQuestions.ToList().Where(a => a.LevelId == id);
            model.lstQuestionMCQs = ctx.TbQuestionsMCQS.ToList().Where(a => a.LevelId == id);
            
            return View(model);
        }


        [Authorize]
        public IActionResult Privacyy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("google-login")]
        public IActionResult gLogin()
        {
            //await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            //{
            //    RedirectUri = Url.Action("GoogleResponse")
            //});
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });



            return RedirectToAction("Privacy", "account");
        }
       
        public async Task<IActionResult> gLogoutt()
        {
            if (HttpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                foreach (var cookie in siteCookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }

            await HttpContext.SignOutAsync(
CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
