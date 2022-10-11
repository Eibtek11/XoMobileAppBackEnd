using BL;
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

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
