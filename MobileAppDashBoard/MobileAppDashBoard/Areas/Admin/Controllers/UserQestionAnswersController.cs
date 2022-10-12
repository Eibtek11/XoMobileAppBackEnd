using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserQestionAnswersController : Controller
    {
        UserQuestionAnswerService userQuestionAnswerService;
        ClaimService claimService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public UserQestionAnswersController(UserQuestionAnswerService UserQuestionAnswerService,ClaimService ClaimService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            claimService = ClaimService;
            userQuestionAnswerService = UserQuestionAnswerService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstUserQestionAnswers = userQuestionAnswerService.getAll();

            return View(model);


        }




        public async Task<IActionResult> Save(TbUserQestionAnswer ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();


            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.UserQuestionAnswerId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


               
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                userQuestionAnswerService.Edit(ITEM);
            }
            else
            {


               


                userQuestionAnswerService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstUserQestionAnswers = userQuestionAnswerService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbUserQestionAnswer oldItem = ctx.TbUserQestionAnswers.Where(a => a.UserQuestionAnswerId == id).FirstOrDefault();

            userQuestionAnswerService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
            model.lstUserQestionAnswers = userQuestionAnswerService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbUserQestionAnswer model = new TbUserQestionAnswer();
            model = ctx.TbUserQestionAnswers.Where(a => a.UserQuestionAnswerId == id).FirstOrDefault();
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }
    }
}
