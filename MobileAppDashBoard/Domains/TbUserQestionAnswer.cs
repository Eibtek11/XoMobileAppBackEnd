using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbUserQestionAnswer
    {
        public Guid UserQuestionAnswerId { get; set; }
        public string Id { get; set; }
        public Guid? QuestionId { get; set; }
        public string UserAnswer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbQuestion Question { get; set; }
        public virtual TbQuestionsMCQ QuestionMCQ { get; set; }
    }
}
