using SupplyTracker.Data;
using SupplyTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyTracker.Databases
{
    public class ProductDB
    {
        /// <summary>
        /// Create the ProductDTO class to store the product information with join condition
        /// </summary>
        public class ProductDTO
        {
            [DisplayName("Product ID")]
            public  int ProductID { get; set; }

            [DisplayName("Product Name")]
            public string ProductName { get; set; }

            [DisplayName("Lot Number")]
            public  string LotNumber { get; set; }

            public decimal Price { get; set; }
            [DisplayName("Unit of Supply")]
            public string UnitOfSupply { get; set; }

            [DisplayName("Production's Date")]
            public DateOnly ProductionDate { get; set; }

            [DisplayName("Expiration's Date")]
            public DateOnly ExpirationDate { get; set; }
            
            [DisplayName("Category")]
            public string CategoryName { get; set; }
            [DisplayName("Vendor")]
            public string VendorName { get; set; }
        }

        /// <summary>
        /// This method return the list of all product in the database
        /// </summary>
        /// <returns></returns>
        public static List<ProductDTO> GetAllProducts()
        {
            using (SupplyTrackerContext context = new SupplyTrackerContext())
            {
                var lstProduct = from p in context.Products
                                 join c in context.ProductCategories on p.ProductCategoryCode equals c.ProductCategoryCode
                                 join v in context.Vendors on p.VendorCode equals v.VendorCode
                                 select new ProductDTO
                                 {
                                     ProductID = p.ProductId,
                                     ProductName = p.ProductName,
                                     LotNumber = p.LotNumber,
                                     Price = p.Price,
                                     UnitOfSupply = p.UnitOfSupply,
                                     ProductionDate = p.DateOfProduct,
                                     ExpirationDate = p.DateOfExpire,
                                     CategoryName = c.CategoryName,
                                     VendorName = v.VendorName
                                 };

                return lstProduct.ToList();
            }
        }

        /// <summary>
        /// This method to add a new product to the database
        /// </summary>
        /// <param name="product"></param>
        public static void AddProduct(Product product)
        {
            using (SupplyTrackerContext context = new SupplyTrackerContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This method to update the product information in the database
        /// </summary>
        /// <param name="product"></param>
        public static void UpdateProduct(Product product)
        {
            using (SupplyTrackerContext context = new SupplyTrackerContext())
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This method to delete the product from the database
        /// </summary>
        /// <param name="product"></param>
        public static void DeleteProduct(Product product)
        {
            using (SupplyTrackerContext context = new SupplyTrackerContext())
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
