using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbLawLevelTwo
    {
        public Guid LawLevelTwoId { get; set; }
        public Guid LawLevelOneId { get; set; }
      
        public string LawLevelTwoName { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string LawLevelTwoDescription { get; set; }
        public string LawLevelTwoPdf { get; set; }
        public string Notes { get; set; }

        public virtual TbLawLevelOne lawOne { get; set; }

    }
}
