using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface LawLevelTwoService
    {
        List<TbLawLevelTwo> getAll();
        bool Add(TbLawLevelTwo client);
        bool Edit(TbLawLevelTwo client);
        bool Delete(TbLawLevelTwo client);


    }
    public class ClsLawsLevelTwo : LawLevelTwoService
    {
        MobileAppDbContext ctx;
        public ClsLawsLevelTwo(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbLawLevelTwo> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbLawLevelTwo> lstLawLevelTwo = ctx.TbLawLevelTwos.ToList();

            return lstLawLevelTwo;
        }

        public bool Add(TbLawLevelTwo item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.LawLevelTwoId = Guid.NewGuid();
                ctx.TbLawLevelTwos.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbLawLevelTwo item)
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

        public bool Delete(TbLawLevelTwo item)
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
