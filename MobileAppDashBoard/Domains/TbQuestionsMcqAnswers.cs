using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbQuestionsMcqAnswers
    {

        public Guid QuestionsMcqAnswerId { get; set; }
       
        public string QuestionsMcqAnswerSytntax { get; set; }
        public string QuestionAnswer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? QuestionId { get; set; }
        public string Notes { get; set; }

        public virtual TbQuestionsMCQ QuestionsMCQ { get; set; }
        
    }
}
