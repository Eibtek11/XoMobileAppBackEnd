using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbLaw
    {
        public TbLaw()
        {
            TbLevels = new HashSet<TbLevel>();
        }

        public Guid LawId { get; set; }
        public string LawName { get; set; }
        public Guid? CountryId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string LawDescription { get; set; }
        public string LawPdf { get; set; }
        public string Notes { get; set; }

        public virtual TbCountry Country { get; set; }
        public virtual ICollection<TbLevel> TbLevels { get; set; }
    }
}
