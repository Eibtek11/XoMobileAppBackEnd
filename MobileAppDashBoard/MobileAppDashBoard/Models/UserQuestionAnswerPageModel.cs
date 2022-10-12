using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAppDashBoard.Models
{
    public class UserQuestionAnswerPageModel
    {
        public Guid UserQuestionAnswerId { get; set; }
        public string Id { get; set; }
        public Guid? QuestionId { get; set; }
        public string UserAnswer { get; set; }
        
        public Guid? QuestionMCQQuestionId { get; set; }
       
    }
}
