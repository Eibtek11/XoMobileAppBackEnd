using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbClaim
    {
        public TbClaim()
        {

            TbClaimLeveOnes = new HashSet<TbClaimLeveOne>();
        }
        public Guid ClaimId { get; set; }
        public string ClaimSyntax { get; set; }
        public Guid? CountryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ClainImage { get; set; }
        public string ClaimPdf { get; set; }
        public string Notes { get; set; }
        public virtual TbCountry Country { get; set; }
        public virtual ICollection<TbClaimLeveOne> TbClaimLeveOnes { get; set; }
    }
}
