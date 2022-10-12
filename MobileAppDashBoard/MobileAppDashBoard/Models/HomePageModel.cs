using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Domains;
namespace MobileAppDashBoard.Models
{
    public class HomePageModel
    {
        #region Declaration
       

        public IEnumerable<ApplicationUser> UserData { get; set; }
        

        public UserModel user { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

        
        public ApplicationUser OneUser { get; set; }

        public IEnumerable<TbCountry> lstCountries { get; set; }
        public TbCountry item { get; set; }

        public IEnumerable<TbLaw> lstLaws { get; set; }
        public TbLaw element { get; set; }

        public IEnumerable<TbLevel> lstLevels { get; set; }
        public TbLevel el { get; set; }


        public IEnumerable<VwLevelsAndLaws> lstLevelsAndLaws { get; set; }
        public IEnumerable<TbQuestion> lstQuestions { get; set; }
        public IEnumerable<VwLevelsAndLawsAndQuestions> lstLevelsAndLawsAndQuestions { get; set; }

        public IEnumerable<TbClaim> lstClaims { get; set; }

        public IEnumerable<TbTask> lstTasks { get; set; }
        public TbTask ele { get; set; }
        public IEnumerable<VwTasksAndUsers> lstTasksAndUses { get; set; }


        public IEnumerable<TbQuestionsMCQ> lstQuestionMCQs { get; set; }

        public IEnumerable<TbQuestionsMcqAnswers> lstQuestionMCQsAnswers { get; set; }

        public IEnumerable<TbUserQestionAnswer> lstquestionUserAnswer { get; set; }

        public IEnumerable<TbReplyToComment> lstReplyToComments { get; set; }

        public IEnumerable<TbUserQestionAnswer> lstUserQestionAnswers { get; set; }

        public IEnumerable<TbLoginHistory> lstLogInHistories { get; set; }
        public IEnumerable<ApplicationUser> lstUsers { get; set; }
        public IEnumerable<VwLevelsAndLawsAndQuestionMCQ> lstLevelsAndLawsAndQuestionMCQ { get; set; }

        
        #endregion

    }
}
