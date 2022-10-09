using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbLevel
    {
        public TbLevel()
        {
            TbQuestions = new HashSet<TbQuestion>();
            TbQuestionsMCQ = new HashSet<TbQuestionsMCQ>();
        }

        public Guid LevelId { get; set; }
        public string LevelName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? LawId { get; set; }
        public string Notes { get; set; }

        public virtual TbLaw Law { get; set; }
        public virtual ICollection<TbQuestion> TbQuestions { get; set; }
        public virtual ICollection<TbQuestionsMCQ> TbQuestionsMCQ { get; set; }
    }
}
