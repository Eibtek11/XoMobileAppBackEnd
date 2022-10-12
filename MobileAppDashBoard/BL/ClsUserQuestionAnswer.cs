using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface UserQuestionAnswerService
    {
        List<TbUserQestionAnswer> getAll();
        bool Add(TbUserQestionAnswer client);
        bool Edit(TbUserQestionAnswer client);
        bool Delete(TbUserQestionAnswer client);


    }
    public class ClsUserQuestionAnswer : UserQuestionAnswerService
    {
        MobileAppDbContext ctx;
        public ClsUserQuestionAnswer(MobileAppDbContext context)
        {
            ctx = context;
        }

        public List<TbUserQestionAnswer> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbUserQestionAnswer> lstClaims = ctx.TbUserQestionAnswers.ToList();

            return lstClaims;
        }

        public bool Add(TbUserQestionAnswer item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.UserQuestionAnswerId = Guid.NewGuid();
                ctx.TbUserQestionAnswers.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbUserQestionAnswer item)
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

        public bool Delete(TbUserQestionAnswer item)
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
