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
    public class ClaimLevelOneController : Controller
    {
        ClaimService claimService;
        ClaimLevelOneService claimLevelOneService;
        LawLevelOneService lawLevelOneService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public ClaimLevelOneController(ClaimService ClaimService,ClaimLevelOneService ClaimLevelOneService,LawLevelOneService LawLevelOneService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            lawLevelOneService = LawLevelOneService;
            claimLevelOneService = ClaimLevelOneService;
            claimService = ClaimService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.TbClaimLeveOnes = claimLevelOneService.getAll();
            foreach (var item in model.TbClaimLeveOnes)
            {
                item.UpdatedBy = ctx.TbClaimLeveOnes.Where(a => a.ClaimLeveOneId == item.ClaimLeveOneId).Count().ToString();
            }
            return View(model);


        }




        public async Task<IActionResult> Save(TbClaimLeveOne ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbLaw oldItem = new TbLaw();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ClaimLeveOneId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.ClaimLeveOnePdf = ImageName;
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

                claimLevelOneService.Edit(ITEM);
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
                        ITEM.ClaimLeveOnePdf = ImageName;
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


                claimLevelOneService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.TbClaimLeveOnes = claimLevelOneService.getAll();


            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbClaimLeveOne oldItem = ctx.TbClaimLeveOnes.Where(a => a.ClaimLeveOneId == id).FirstOrDefault();

            claimLevelOneService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstLawLevelOneS = lawLevelOneService.getAll();
            model.TbClaimLeveOnes = claimLevelOneService.getAll();


            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbLawLevelOne model = new TbLawLevelOne();
            model = ctx.TbLawLevelOnes.Where(a => a.LawLevelOneId == id).FirstOrDefault();
            ViewBag.Countries = claimService.getAll();
            return View(model);


        }
    }
}
