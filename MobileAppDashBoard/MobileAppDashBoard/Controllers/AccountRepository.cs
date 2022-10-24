﻿using BL;
using Domains;
using EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Controllers
{
    public class AccountRepository : IAccountRepository
    {
        UserCountryLawService userCountryLawService;
        MobileAppDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        private readonly IConfiguration _configuration;
        IEmailSender _emailSender;
        public AccountRepository(UserCountryLawService UserCountryLawService,IEmailSender emailSender,IConfiguration configuration, MobileAppDbContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            _configuration = configuration;
            _emailSender = emailSender;

            userCountryLawService = UserCountryLawService;
        }


        public async Task <List<TbTrUserCountryLaw>> aaRecord( string id )
        {
            
            
            List<CalculateUserGrade> list = Ctx.CalculateUserGrades.ToList();
            foreach (var i in Usermanager.Users)
            {
                int grade = 0;
                foreach (var ii in list.Where(a => a.Id == i.Id))
                {
                    if (ii.CreatedBy == ii.UserAnswer)
                    {
                        grade += 100;
                    }

                   
                }
                if(grade>0)
                {
                    TbTrUserCountryLaw record = new TbTrUserCountryLaw();
                    record.UserCountryLawId = Guid.NewGuid();
                    record.Id = i.Id;
                    record.CreatedBy = grade.ToString();
                    record.CreatedDate = DateTime.Now;
                    Ctx.TbTrUserCountryLaws.Add(record);

                }
               


            }
            Ctx.SaveChanges();
            var res2 = Ctx.TbTrUserCountryLaws.ToList();
            foreach (var i in Ctx.TbTrUserCountryLaws)
            {
                Ctx.TbTrUserCountryLaws.Remove(i);
               
            }
            Ctx.SaveChanges();
            return res2;
        }
        public async Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel)
        {
            
                if (signUpModel.PersonalImage != null)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await signUpModel.PersonalImage.CopyToAsync(stream);
                    }
                    signUpModel.image = ImageName;
                }
                else
                {
                signUpModel.image = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

                }
         
            var user = new ApplicationUser()
            {
                FirstName = signUpModel.FirstName,
                image = signUpModel.image,
                Email = signUpModel.Email,
                UserName = signUpModel.Email,
                LastName = signUpModel.LastName

                
            };
            await Usermanager.CreateAsync(user, signUpModel.Password);
            var res2 = Usermanager.Users.Where(a => a.UserName == user.Email).FirstOrDefault();
            return res2;
        }

        public async Task<ApplicationUser> LLoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, true, true);

            if (!result.Succeeded)
            {
                return null;
            }
            else
            {

                var res2 =Usermanager.Users.Where(a => a.UserName == signInModel.Email).FirstOrDefault();

                return res2;
            }

            //var authClaims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, signInModel.Email),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};
            //var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            //var token = new JwtSecurityToken(
            //    issuer: _configuration["JWT:ValidIssuer"],
            //    audience: _configuration["JWT:ValidAudience"],
            //    expires: DateTime.Now.AddDays(1),
            //    claims: authClaims,
            //    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            //    );

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }




        [HttpPost]
        public async Task<ApplicationUser> EditUsers(EditUserViewModel model)
        {
           
            model.UserName = model.Email;
            var user = await Usermanager.FindByIdAsync(model.Id);
          
                user.Id = model.Id;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
               
               
               
              
                
                

              

                var result = await Usermanager.UpdateAsync(user);
               







                    return user;
               

                
            }



        [HttpPost]
        public async Task<ApplicationUser> EditUsersImage(EditUserViewModel model)
        {
            if (model.PersonalImage != null)
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await model.PersonalImage.CopyToAsync(stream);
                }
                model.image = ImageName;
            }
            else
            {
                model.image = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

            }
            model.UserName = model.Email;
            var user = await Usermanager.FindByIdAsync(model.Id);


            user.image = model.image;








            var result = await Usermanager.UpdateAsync(user);








            return user;



        }



        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<ApplicationUser> ForgotPassword(ForgotPasswordViewModel model, IFormFileCollection files)
        {

            //if (user != null && await Usermanager.IsEmailConfirmedAsync(user))
            //{
            //    var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            //    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
            //    logger.Log(LogLevel.Warning, passwordResetLink);
            //    return View("ForgotPasswordConfirmation");

            //}
           
                var user = await Usermanager.FindByEmailAsync(model.Email);
                
                model.emailSent = true;
                if (user != null)
                {
                    await GenerateForgotPasswordTokenAsync(user, files);
                }




           
            return user;


        }
        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user, IFormFileCollection files)
        {
            var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token, files);
            }



        }

        public async Task SendForgotPasswordEmail(ApplicationUser user, string token, IFormFileCollection files)
        {
            var userEmail = user.Email;

            //var messages = new Message(new string[] { "ahmedmostafa706@gmail.com"}, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n" + " His phone is " + phone + "\n" + "He needs to book " + "hotel name " +  HotelName + "\n" + "Check in date " +  " " + checkin + "\n" + "Check out date" + " " + checkout + "\n" + "No of rooms " + noofrooms + "\n" + "Room type " + roomtype + "\n" + "No of guests " + noofadults + "\n" + "H needs a car " + car, "This is the content from our async email. i am happy", files);
            var messages = new Message(new string[] { user.Email }, "Email From Customer " + "His name is " + user.UserName + "\n" + " His Email Is " + user.Email + "\n", "This is the content from our async email. i am happy", files, user.Id);
            //var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
            //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            await _emailSender.SendEmailAsync(messages, token, user.Id , user.Email);
        }



    }
}
