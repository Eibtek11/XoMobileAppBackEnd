using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwOneApiCollectQuestions
    {
        public Guid QuestionId { get; set; }
        public string QestionSyntax { get; set; }
        public string QuestionAnswer { get; set; }
        public Guid? LevelId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
    }
}
