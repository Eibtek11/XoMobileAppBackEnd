using BL;
using EmailService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MobileAppDashBoard.Controllers;
using MobileAppDashBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppDashBoard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddControllersWithViews();
            services.AddScoped<CountryService, ClsCountry>();
            services.AddScoped<LawService, ClsLaws>();
            services.AddScoped<LevelService, ClsLevels>();
            services.AddScoped<QuestionService, ClsQuestions>();
            services.AddScoped<ClaimService, ClsClaims>();
            services.AddScoped<taskService, ClsTasks>();
            services.AddScoped<QuestionMCQService, ClsQuestionMCQ>();
            services.AddScoped<QuestionMCQAnswerService, ClsQuestionMCQAnswers>();
            services.AddScoped<ClaimService, ClsClaims>();
            services.AddScoped<questionUserAnswerService, ClsQuestionUserAnswer>();
            services.AddScoped<logInHistoryService, ClsLoginHistory>();
            services.AddScoped<replyToCommentService, ClsReplyToComments>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<UserQuestionAnswerService, ClsUserQuestionAnswer>();
            services.AddScoped<UserCountryLawService, ClsUserCountryLaw>();
            services.AddScoped<CommentsService, ClsComments>();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder => {
                    //URLs are from the front-end (note that they changed
                    //since posting my original question due to scrapping
                    //the original projects and starting over)
                    builder.WithOrigins("https://localhost:44398/", "https://bookecommerce.com/" , "https://lawcity.app/")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod()
                                     .AllowCredentials();
                });
            });
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDbContext<MobileAppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;

            }).AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<MobileAppDbContext>().AddDefaultTokenProviders();

          //  services.AddAuthentication(option =>
          //  {
          //      option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          //      option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          //      option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
          //  })
          //      .AddCookie("Cookies", options =>
          //      {
          //          options.LoginPath = "/login";
          //          options.ExpireTimeSpan = TimeSpan.FromDays(1);
          //      })
          //.AddJwtBearer(option =>
          //option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
          //{

          //    ValidateIssuer = true,
          //    ValidateAudience = true,
          //    ValidAudience = Configuration["JWT:ValidAudience"],
          //    ValidIssuer = Configuration["JWT:ValidIssuer"],
          //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))

          //});





            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/User/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/User/LogIn";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;


            });
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
