using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbReplyToComment
    {
        public Guid CommentReplyId { get; set; }
        public Guid? CommentId { get; set; }
        public string ReplySyntax { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }

        public virtual TbComment Comment { get; set; }
    }
}
