using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TbTrUserCountryLawController : Controller
    {
        UserManager<ApplicationUser> Usermanager;
        UserCountryLawService userCountryLawService;
        ClaimService claimService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public TbTrUserCountryLawController(UserManager<ApplicationUser> usermanager,UserCountryLawService UserCountryLawService,ClaimService ClaimService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            claimService = ClaimService;
            userCountryLawService = UserCountryLawService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstTbTrUserCountryLaw = userCountryLawService.getAll();
            model.lstUsers = Usermanager.Users.ToList();

            return View(model);


        }




        public async Task<IActionResult> Save(TbTrUserCountryLaw ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();


            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.UserCountryLawId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


                
                
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                userCountryLawService.Edit(ITEM);
            }
            else
            {


              


                userCountryLawService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstTbTrUserCountryLaw = userCountryLawService.getAll();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbTrUserCountryLaw oldItem = ctx.TbTrUserCountryLaws.Where(a => a.UserCountryLawId == id).FirstOrDefault();

            userCountryLawService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstTbTrUserCountryLaw = userCountryLawService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbTrUserCountryLaw model = new TbTrUserCountryLaw();
            model = ctx.TbTrUserCountryLaws.Where(a => a.UserCountryLawId == id).FirstOrDefault();
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }
    }
}
