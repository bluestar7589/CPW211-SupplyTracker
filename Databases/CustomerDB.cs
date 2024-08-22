using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using SupplyTracker.Data;
using SupplyTracker.Models;
using SupplyTracker.Util;

namespace SupplyTracker.Databases
{
    public class CustomerDB
    {
        /// <summary>
        /// This method grabs all customers in the database
        /// </summary>
        /// <returns>Returns a list of all customers in the database</returns>
        public static List<Customer> GetAllCustomers()
        {
            using (SupplyTrackerContext context = new())
            {
                return context.Customers.ToList();
            }
        }

        /// <summary>
        /// This method adds a new customer to the database
        /// </summary>
        /// <param name="customer"></param>
        public static void AddCustomer(Customer customer)
        {
            using (SupplyTrackerContext context = new())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This method to update the customer information in the database
        /// </summary>
        /// <param name="customer"></param>
        public static void UpdateCustomer(Customer customer)
        {
            using (SupplyTrackerContext context = new())
            {
                var existingCustomer = context.Customers.Find(customer.CustomerID);
                if (existingCustomer != null)
                {
                    existingCustomer.FirstName = customer.FirstName;
                    existingCustomer.LastName = customer.LastName;
                    existingCustomer.DepartmentCode = customer.DepartmentCode;
                    existingCustomer.PhoneNumber = customer.PhoneNumber;
                    existingCustomer.Position = customer.Position;

                    context.SaveChanges();
                }

            }
        }

        /// <summary>
        /// This method to delete the customer from the database
        /// </summary>
        /// <param name="customer"></param>
        public static void DeleteCustomer(Customer customer)
        {
            using (SupplyTrackerContext context = new())
            {
                var existingCustomer = context.Customers.Find(customer.CustomerID);
                if (existingCustomer != null)
                {
                    context.Customers.Remove(existingCustomer);
                    context.SaveChanges();
                }
            }
        }
    }
}
