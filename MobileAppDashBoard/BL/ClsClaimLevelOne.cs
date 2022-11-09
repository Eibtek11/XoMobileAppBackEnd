using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ClaimLevelOneService
    {
        List<TbClaimLeveOne> getAll();
        bool Add(TbClaimLeveOne client);
        bool Edit(TbClaimLeveOne client);
        bool Delete(TbClaimLeveOne client);


    }
    public class ClsClaimLevelOne : ClaimLevelOneService
    {
        MobileAppDbContext ctx;
        public ClsClaimLevelOne(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbClaimLeveOne> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbClaimLeveOne> lstClaimsLeveOne = ctx.TbClaimLeveOnes.ToList();

            return lstClaimsLeveOne;
        }

        public bool Add(TbClaimLeveOne item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ClaimLeveOneId = Guid.NewGuid();
                ctx.TbClaimLeveOnes.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbClaimLeveOne item)
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

        public bool Delete(TbClaimLeveOne item)
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
