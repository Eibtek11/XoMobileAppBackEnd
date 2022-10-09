using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public partial class VwLevelsAndLawsAndQuestionMCQ
    {
      

        public Guid QuestionId { get; set; }
        public string QestionSyntax { get; set; }
        public string QuestionAnswer { get; set; }
      

        public Guid LevelId { get; set; }
        public string LevelName { get; set; }
       
       
        public Guid LawId { get; set; }
        public string LawName { get; set; }
        
    }
}
