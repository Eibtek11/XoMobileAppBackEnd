using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface LevelService
    {
        List<TbLevel> getAll();
        bool Add(TbLevel client);
        bool Edit(TbLevel client);
        bool Delete(TbLevel client);


    }
    public class ClsLevels : LevelService
    {
        MobileAppDbContext ctx;
        public ClsLevels(MobileAppDbContext context)
        {
            ctx = context;
        }




        public List<TbLevel> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbLevel> lstLevels = ctx.TbLevels.ToList();

            return lstLevels;
        }

        public bool Add(TbLevel item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.LevelId = Guid.NewGuid();
                TbLaw el = new TbLaw();
              
                ctx.TbLevels.Add(item);
               
                ctx.SaveChanges();
             
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbLevel item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                TbLaw el = new TbLaw();
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbLevel item)
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
