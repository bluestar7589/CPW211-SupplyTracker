using SupplyTracker.Data;
using SupplyTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyTracker.Databases
{
    internal class VendorDB
    {
        /// <summary>
        /// This method to get all the vendor from database
        /// </summary>
        /// <returns></returns>
        public static List<Vendor> GetAllVendors()
        {
            using SupplyTrackerContext context = new SupplyTrackerContext();
            List<Vendor> lstVendors = (from v in context.Vendors select v).ToList();
            return lstVendors;
        }
    }
}
