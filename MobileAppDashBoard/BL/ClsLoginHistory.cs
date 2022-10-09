using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface logInHistoryService
    {
        List<TbLoginHistory> getAll();
        bool Add(TbLoginHistory client);
        bool Edit(TbLoginHistory client);
        bool Delete(TbLoginHistory client);


    }
    public class ClsLoginHistory : logInHistoryService
    {
        MobileAppDbContext ctx;
        public ClsLoginHistory(MobileAppDbContext context)
        {
            ctx = context;
        }
        public List<TbLoginHistory> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbLoginHistory> lstReplyToComments = ctx.TbLoginHistories.ToList();

            return lstReplyToComments;
        }

        public bool Add(TbLoginHistory item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.LogInId = Guid.NewGuid();
                ctx.TbLoginHistories.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbLoginHistory item)
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

        public bool Delete(TbLoginHistory item)
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
