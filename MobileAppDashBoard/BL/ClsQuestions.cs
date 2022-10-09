using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface QuestionService
    {
        List<TbQuestion> getAll();
        bool Add(TbQuestion client);
        bool Edit(TbQuestion client);
        bool Delete(TbQuestion client);


    }
    public class ClsQuestions : QuestionService
    {
        MobileAppDbContext ctx;
        public ClsQuestions(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbQuestion> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbQuestion> lstQuestion = ctx.TbQuestions.ToList();

            return lstQuestion;
        }

        public bool Add(TbQuestion item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.QuestionId = Guid.NewGuid();
               

                ctx.TbQuestions.Add(item);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbQuestion item)
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

        public bool Delete(TbQuestion item)
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
