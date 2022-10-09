using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface QuestionMCQService
    {
        List<TbQuestionsMCQ> getAll();
        bool Add(TbQuestionsMCQ client);
        bool Edit(TbQuestionsMCQ client);
        bool Delete(TbQuestionsMCQ client);


    }
    public class ClsQuestionMCQ : QuestionMCQService
    {
        MobileAppDbContext ctx;
        public ClsQuestionMCQ(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbQuestionsMCQ> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbQuestionsMCQ> lstQuestionMCQ = ctx.TbQuestionsMCQS.ToList();

            return lstQuestionMCQ;
        }

        public bool Add(TbQuestionsMCQ item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.QuestionId = Guid.NewGuid();


                ctx.TbQuestionsMCQS.Add(item);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbQuestionsMCQ item)
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

        public bool Delete(TbQuestionsMCQ item)
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
