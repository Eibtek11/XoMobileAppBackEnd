using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface QuestionMCQAnswerService
    {
        List<TbQuestionsMcqAnswers> getAll();
        bool Add(TbQuestionsMcqAnswers client);
        bool Edit(TbQuestionsMcqAnswers client);
        bool Delete(TbQuestionsMcqAnswers client);


    }
    public class ClsQuestionMCQAnswers : QuestionMCQAnswerService
    {
        MobileAppDbContext ctx;
        public ClsQuestionMCQAnswers(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbQuestionsMcqAnswers> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbQuestionsMcqAnswers> lstQuestionMCQAnswers = ctx.TbQuestionsMcqAnswerss.ToList();

            return lstQuestionMCQAnswers;
        }
        public bool Add(TbQuestionsMcqAnswers item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.QuestionsMcqAnswerId = Guid.NewGuid();


                ctx.TbQuestionsMcqAnswerss.Add(item);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbQuestionsMcqAnswers item)
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

        public bool Delete(TbQuestionsMcqAnswers item)
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
