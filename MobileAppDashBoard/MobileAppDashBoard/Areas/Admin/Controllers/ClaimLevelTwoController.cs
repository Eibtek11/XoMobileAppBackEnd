using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClaimLevelTwoController : Controller
    {
        ClaimLevelTwoService claimLevelTwoService;
        ClaimLevelOneService claimLevelOneService;
        LawLevelOneService lawLevelOneService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public ClaimLevelTwoController(ClaimLevelTwoService ClaimLevelTwoService,ClaimLevelOneService ClaimLevelOneService, LawLevelOneService LawLevelOneService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            lawLevelOneService = LawLevelOneService;
            claimLevelOneService = ClaimLevelOneService;
            claimLevelTwoService = ClaimLevelTwoService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.TbClaimLevelTwos = claimLevelTwoService.getAll();

            return View(model);


        }




        public async Task<IActionResult> Save(TbClaimLevelTwo ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbLaw oldItem = new TbLaw();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ClaimLevelTwoId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".pdf";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClaimLevelTwoPdf = ImageName;
                    }
                }
                foreach (var file in filesImages)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.CreatedBy = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                claimLevelTwoService.Edit(ITEM);
            }
            else
            {


                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".pdf";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ClaimLevelTwoPdf = ImageName;
                    }
                }
                foreach (var file in filesImages)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.CreatedBy = ImageName;
                    }
                }


                claimLevelTwoService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.TbClaimLevelTwos = claimLevelTwoService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbClaimLevelTwo oldItem = ctx.TbClaimLevelTwos.Where(a => a.ClaimLevelTwoId == id).FirstOrDefault();

            claimLevelTwoService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.TbClaimLevelTwos = claimLevelTwoService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbClaimLevelTwo model = new TbClaimLevelTwo();
            model = ctx.TbClaimLevelTwos.Where(a => a.ClaimLevelTwoId == id).FirstOrDefault();
            ViewBag.Countries = claimLevelOneService.getAll();
            return View(model);


        }
        public IActionResult Form2(Guid id)
        {
            TbClaimLevelTwo model = new TbClaimLevelTwo();
            model.ClaimLeveOneId = id;
            ViewBag.Countries = claimLevelOneService.getAll();

            return View(model);


        }
    }
}
