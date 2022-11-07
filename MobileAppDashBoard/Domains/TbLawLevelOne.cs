using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbLawLevelOne
    {
        public TbLawLevelOne()
        {
            TbLawLevelTwos = new HashSet<TbLawLevelTwo>();
        }
        public Guid LawLevelOneId { get; set; }
        public Guid LawId { get; set; }
        public string LawLevelOneName { get; set; }
       
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string LawLevelOneDescription { get; set; }
        public string LawLevelOnePdf { get; set; }
        public string Notes { get; set; }

        public virtual TbLaw law { get; set; }

        public virtual ICollection<TbLawLevelTwo> TbLawLevelTwos { get; set; }
    }
}
