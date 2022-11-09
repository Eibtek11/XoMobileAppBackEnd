using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ClaimLevelTwoService
    {
        List<TbClaimLevelTwo> getAll();
        bool Add(TbClaimLevelTwo client);
        bool Edit(TbClaimLevelTwo client);
        bool Delete(TbClaimLevelTwo client);


    }
    public class ClsClaimLevelTwo : ClaimLevelTwoService
    {
        MobileAppDbContext ctx;
        public ClsClaimLevelTwo(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbClaimLevelTwo> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbClaimLevelTwo> lstClaimsLevelTwo = ctx.TbClaimLevelTwos.ToList();

            return lstClaimsLevelTwo;
        }

        public bool Add(TbClaimLevelTwo item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ClaimLevelTwoId = Guid.NewGuid();
                ctx.TbClaimLevelTwos.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbClaimLevelTwo item)
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

        public bool Delete(TbClaimLevelTwo item)
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
