using BL;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClaimsController : Controller
    {
        ClaimService claimService;
        LawService lawService;
        MobileAppDbContext ctx;
        CountryService countryService;
        public ClaimsController(ClaimService ClaimService, LawService Lawservice, MobileAppDbContext context, CountryService CountryService)
        {
            lawService = Lawservice;
            ctx = context;
            countryService = CountryService;
            claimService = ClaimService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();
           
            return View(model);


        }




        public async Task<IActionResult> Save(TbClaim ITEM, int id, List<IFormFile> files, List<IFormFile> filesImages)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

           
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.ClaimId != Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.ClaimPdf = ImageName;
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
                        ITEM.ClainImage = ImageName;
                    }
                }
                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                claimService.Edit(ITEM);
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
                        ITEM.ClaimPdf = ImageName;
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
                        ITEM.ClainImage = ImageName;
                    }
                }


                claimService.Add(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();

            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbClaim oldItem = ctx.TbClaims.Where(a => a.ClaimId == id).FirstOrDefault();

            claimService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lstLaws = lawService.getAll();
            model.lstClaims = claimService.getAll();

            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbClaim model = new TbClaim();
            model = ctx.TbClaims.Where(a => a.ClaimId == id).FirstOrDefault();
            ViewBag.Countries = countryService.getAll();
            return View(model);


        }

    }
}
