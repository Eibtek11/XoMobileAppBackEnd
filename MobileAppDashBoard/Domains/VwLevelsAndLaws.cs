using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwLevelsAndLaws
    {
        public Guid LevelId { get; set; }
        public string LevelName { get; set; }
       
        public Guid? LawId { get; set; }
       
        public string LawName { get; set; }
        public Guid? CountryId { get; set; }
       
       
    }
}
