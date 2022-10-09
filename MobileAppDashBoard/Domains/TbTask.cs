using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbTask
    {
        public Guid TaskId { get; set; }
        public string TaskSyntax { get; set; }
        public Guid? LawId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TaskPoints { get; set; }
        public string TaskDescription { get; set; }
        public string Notes { get; set; }
    }
}
