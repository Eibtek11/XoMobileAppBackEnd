using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface LawLevelOneService
    {
        List<TbLawLevelOne> getAll();
        bool Add(TbLawLevelOne client);
        bool Edit(TbLawLevelOne client);
        bool Delete(TbLawLevelOne client);


    }
    public class ClsLawsLevelOne : LawLevelOneService
    {
        MobileAppDbContext ctx;
        public ClsLawsLevelOne(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbLawLevelOne> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbLawLevelOne> lstLawLevelOne = ctx.TbLawLevelOnes.ToList();

            return lstLawLevelOne;
        }

        public bool Add(TbLawLevelOne item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.LawLevelOneId = Guid.NewGuid();
                ctx.TbLawLevelOnes.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbLawLevelOne item)
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

        public bool Delete(TbLawLevelOne item)
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
