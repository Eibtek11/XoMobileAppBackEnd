using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class CalculateUserGrade
    {
        public Guid QuestionId { get; set; }
        public string QestionSyntax { get; set; }
        public string QuestionAnswer { get; set; }
        public Guid? LevelId { get; set; }
        public string CreatedBy { get; set; }
        public string Id { get; set; }
        public string UserAnswer { get; set; }


    }
}
