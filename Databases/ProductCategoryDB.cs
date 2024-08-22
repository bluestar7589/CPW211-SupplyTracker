using SupplyTracker.Models;
using SupplyTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyTracker.Databases
{
    public class ProductCategoryDB
    {
        /// <summary>
        /// This method to get all the category from product category
        /// </summary>
        /// <returns></returns>
        public static List<ProductCategory> GetAllProductCategories()
        {
            using SupplyTrackerContext context = new SupplyTrackerContext();
            List<ProductCategory> lstProductCategories = (from category in context.ProductCategories select category).ToList();
            return lstProductCategories;
        }
    }
}
