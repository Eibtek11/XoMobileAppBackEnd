using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using MobileAppDashBoard.Models;
using BL;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Domains;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using EmailService;

namespace MobileAppDashBoard.Controllers
{
    public class UserController : Controller
    {
        logInHistoryService lgHistory;
        MobileAppDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        private readonly IConfiguration _configuration;
        IEmailSender _emailSender;
        public UserController(IEmailSender emailSender, logInHistoryService LgHistory,IConfiguration configuration,MobileAppDbContext ctx ,UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            _configuration = configuration;
            lgHistory = LgHistory;
            _emailSender = emailSender;

        }
        

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel,List<IFormFile> files)
        {
            try 
            {

                //if (ModelState.IsValid)
                //{
                //    var user = new ApplicationUser()
                //    {
                //        Email = oHomePageModel.Email,
                //        UserName = oHomePageModel.Email

                //    };
                //    var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                //    if (result.Succeeded)
                //    {





                //        result.ToString();

                //        return Redirect("~/");
                //    }
                //    else
                //    {
                //        var error = result.Errors.ToList();
                //        string erresult = "";
                //        string erresult2 = "";
                //        foreach (var er in error)
                //        {
                //            erresult = string.Format("{0}\t\t{1}", erresult, er.Description);



                //        }

                //        this.ModelState.AddModelError("Password", erresult);
                //        this.ModelState.AddModelError("Email", erresult2);
                //        return View("LogIn", oHomePageModel);
                //    }
                //}
                //else
                //{
                //    return View("LogIn", oHomePageModel);
                //}
               
                var user = new ApplicationUser()
                    {
                        Email = oHomePageModel.Email,
                        UserName = oHomePageModel.Email,
             

                };
                    var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                    if (result.Succeeded)
                    {





                        result.ToString();

                        return Redirect("~/");
                    }
                    else
                    {
                       
                        return View("LogIn", oHomePageModel);
                    }
              
            }
            catch (Exception ex)
            {
               

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }






        }
        [HttpPost]
        public async Task<IActionResult> LogInn(HomePageModel oHomePageModel)
        {
            try 
            {
              
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {
                    string id =  Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().Id;
                    TbLoginHistory item = new TbLoginHistory();
                    item.Id = id;
                    item.CreatedDate = DateTime.Now;
                    item.LogInId = new Guid();
                    
                    lgHistory.Add(item);

                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {
                

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }




        public async Task<IActionResult> SignIn(HomePageModel oHomePageModel)
        {
            try 
            {
              

                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {



                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {
               

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();


            return Redirect("~/");

        }
        public IActionResult LogIn(string ReturnUrl)
        {
            try 
            {
                HomePageModel oHomePageModel = new HomePageModel();
               
                oHomePageModel.user = new UserModel()
                {
                    ReturnUrl = ReturnUrl
                };


                return View(oHomePageModel);

            }
            catch (Exception ex)
            {
              
                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }





        }
        public IActionResult AccessDenied()
        {
            try 
            {
                HomePageModel oHomePageModel = new HomePageModel();
               
                return View(oHomePageModel);
            }
            catch (Exception ex)
            {
               

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }


        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model, IFormFileCollection files)
        {

            //if (user != null && await Usermanager.IsEmailConfirmedAsync(user))
            //{
            //    var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            //    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
            //    logger.Log(LogLevel.Warning, passwordResetLink);
            //    return View("ForgotPasswordConfirmation");

            //}
            if (ModelState.IsValid)
            {
                var user = await Usermanager.FindByEmailAsync(model.Email);
                ModelState.Clear();
                model.emailSent = true;
                if (user != null)
                {
                    await GenerateForgotPasswordTokenAsync(user, files);
                }




            }
            return View(model);


        }
        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user, IFormFileCollection files)
        {
            var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token, files);
            }



        }

        private async Task SendForgotPasswordEmail(ApplicationUser user, string token, IFormFileCollection files)
        {
            var userEmail = user.Email;

            //var messages = new Message(new string[] { "ahmedmostafa706@gmail.com"}, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n" + " His phone is " + phone + "\n" + "He needs to book " + "hotel name " +  HotelName + "\n" + "Check in date " +  " " + checkin + "\n" + "Check out date" + " " + checkout + "\n" + "No of rooms " + noofrooms + "\n" + "Room type " + roomtype + "\n" + "No of guests " + noofadults + "\n" + "H needs a car " + car, "This is the content from our async email. i am happy", files);
            var messages = new Message(new string[] { user.Email }, "Email From Customer " + "His name is " + user.UserName + "\n" + " His Email Is " + user.Email + "\n", "This is the content from our async email. i am happy", files, user.Id);
            //var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
            //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            await _emailSender.SendEmailAsync(messages, token, user.Id , user.Email);
        }



        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = uid
            };
            return View(resetPasswordModel);
        }
        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await Usermanager.ResetPasswordAsync(await Usermanager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
