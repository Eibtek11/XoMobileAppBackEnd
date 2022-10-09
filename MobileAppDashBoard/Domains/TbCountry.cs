using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbCountry
    {
        public TbCountry()
        {
            TbClaims = new HashSet<TbClaim>();
            TbLaws = new HashSet<TbLaw>();
        }

        public Guid CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryImageName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<TbClaim> TbClaims { get; set; }
        public virtual ICollection<TbLaw> TbLaws { get; set; }
    }
}
