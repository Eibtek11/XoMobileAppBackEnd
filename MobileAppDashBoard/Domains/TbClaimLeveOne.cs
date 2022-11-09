using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class TbClaimLeveOne
    {
        public TbClaimLeveOne()
        {
            TbClaimLevelTwos = new HashSet<TbClaimLevelTwo>();
        }
        public Guid ClaimLeveOneId { get; set; }

        public Guid ClaimId { get; set; }
        public string ClaimLeveOneSyntax { get; set; }

        public string ClaimLevelOneDescription { get; set; }
        public Guid? CountryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ClainLeveOneImage { get; set; }
        public string ClaimLeveOnePdf { get; set; }
        public string Notes { get; set; }

        public virtual TbClaim claim { get; set; }

        public virtual ICollection<TbClaimLevelTwo> TbClaimLevelTwos { get; set; }
    }
}
