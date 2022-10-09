using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface replyToCommentService
    {
        List<TbReplyToComment> getAll();
        bool Add(TbReplyToComment client);
        bool Edit(TbReplyToComment client);
        bool Delete(TbReplyToComment client);


    }
    public class ClsReplyToComments : replyToCommentService
    {
        MobileAppDbContext ctx;
        public ClsReplyToComments(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbReplyToComment> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbReplyToComment> lstReplyToComments = ctx.TbReplyToComments.ToList();

            return lstReplyToComments;
        }

        public bool Add(TbReplyToComment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CommentReplyId = Guid.NewGuid();
                ctx.TbReplyToComments.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbReplyToComment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbReplyToComment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
