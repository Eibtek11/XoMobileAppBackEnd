using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface UserCountryLawService
    {
        List<TbTrUserCountryLaw> getAll();
        bool Add(TbTrUserCountryLaw client);
        bool Edit(TbTrUserCountryLaw client);
        bool Delete(TbTrUserCountryLaw client);


    }
    public class ClsUserCountryLaw : UserCountryLawService
    {
        MobileAppDbContext ctx;
        public ClsUserCountryLaw(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbTrUserCountryLaw> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTrUserCountryLaw> lstTbTrUserCountryLaw = ctx.TbTrUserCountryLaws.ToList();

            return lstTbTrUserCountryLaw;
        }

        public bool Add(TbTrUserCountryLaw item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.UserCountryLawId = Guid.NewGuid();
                ctx.TbTrUserCountryLaws.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTrUserCountryLaw item)
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

        public bool Delete(TbTrUserCountryLaw item)
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
