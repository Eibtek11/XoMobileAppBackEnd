using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public interface CountryService
    {
        List<TbCountry> getAll();
        bool Add(TbCountry client);
        bool Edit(TbCountry client);
        bool Delete(TbCountry client);


    }
    public class ClsCountry : CountryService
    {
        MobileAppDbContext ctx;
        public ClsCountry(MobileAppDbContext context)
        {
            ctx = context;
        }

        public List<TbCountry> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbCountry> lstCountries = ctx.TbCountries.ToList();

            return lstCountries;
        }

        public bool Add(TbCountry item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CountryId = Guid.NewGuid();
                ctx.TbCountries.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbCountry item)
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

        public bool Delete(TbCountry item)
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
