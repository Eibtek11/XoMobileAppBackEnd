using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbQuestion
    {
        public TbQuestion()
        {
            TbUserQestionAnswers = new HashSet<TbUserQestionAnswer>();
        }

        public Guid QuestionId { get; set; }
        public string QestionSyntax { get; set; }
        public string QuestionAnswer { get; set; }
        public Guid? LevelId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbLevel Level { get; set; }
        public virtual ICollection<TbUserQestionAnswer> TbUserQestionAnswers { get; set; }
    }
}
