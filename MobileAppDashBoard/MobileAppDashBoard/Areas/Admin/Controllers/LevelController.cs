using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LevelController : Controller
    {
        LevelService levelService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public LevelController(LawService Lawservice, MobileAppDbContext context, CountryService CountryService , LevelService LevelService )
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            levelService = LevelService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();
            return View(model);


        }




        public async Task<IActionResult> Save(TbLevel ITEM, int id)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            TbLevel oldItem = new TbLevel();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.LevelId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


                

                levelService.Edit(ITEM);
            }
            else
            {





                levelService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLaws = lawService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbLevel oldItem = ctx.TbLevels.Where(a => a.LevelId == id).FirstOrDefault();

            levelService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLevels = levelService.getAll();
            model.lstLevelsAndLaws = ctx.VwLevelsAndLawss.ToList();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLevel model = new TbLevel();
            model.LawId = id;
            ViewBag.Countries = id;
            return View(model);


        }
        public IActionResult FormEdit(Guid? id , Guid? lawid)
        {
            TbLevel model = new TbLevel();
            model = ctx.TbLevels.Where(a => a.LevelId == id).FirstOrDefault();
            model.LawId = lawid;
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }

    }
}
