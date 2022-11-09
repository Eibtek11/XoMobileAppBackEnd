using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbClaimLevelTwo
    {
        public Guid ClaimLevelTwoId { get; set; }

        public Guid ClaimLeveOneId { get; set; }
        
        public string ClaimLevelTwoSyntax { get; set; }


        public string ClaimLevelTwoDescription { get; set; }
        public Guid? CountryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ClainLevelTwoImage { get; set; }
        public string ClaimLevelTwoPdf { get; set; }
        public string Notes { get; set; }

        public virtual TbClaimLeveOne claimOne { get; set; }
    }
}
