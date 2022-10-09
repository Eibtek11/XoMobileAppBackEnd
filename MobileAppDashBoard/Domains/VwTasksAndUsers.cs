using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwTasksAndUsers
    {
        public Guid TaskId { get; set; }
        public string TaskSyntax { get; set; }
        public Guid? LawId { get; set; }
       
        public string TaskPoints { get; set; }
        public string TaskDescription { get; set; }

        public string Id { get; set; }

        public string UserName { get; set; }

    }
}
