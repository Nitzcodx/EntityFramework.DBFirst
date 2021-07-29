using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EF.DBFirst.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using EFC = Microsoft.EntityFrameworkCore;

namespace EF.DBFirst.DataAccessLayer
{
    public class InSystRepository
    {
        InSystContext context;
        public InSystRepository()
        {
            context = new InSystContext();
        }

        public List<Customer> GetAllCustomers()
        {
            var customers = (from customer in context.Customers
                             orderby customer.CustId descending
                             select customer).ToList();
            return customers;
        }

        public List<Customer> GetSpecificCustomers(char gender)
        {
            List<Customer> list = null;
            try
            {
                list = (from customer in context.Customers
                        where customer.Gender.Equals(gender.ToString())
                        select customer).ToList();
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;
        }

        public Customer GetCustomer(int custId)
        {
            Customer customer = null;
            try
            {
                customer = (from cust in context.Customers
                                where cust.CustId.Equals(custId)
                                select cust).FirstOrDefault();
            }
            catch (Exception)
            {
                customer = null;
            }
            return customer;
        }

        public List<Customer> GetCustomerUsingLike(string pattern)
        {
            List<Customer> customers = null;
            try
            {
                customers = (from customer in context.Customers
                             where EFC.EF.Functions.Like(customer.City, pattern)
                             select customer).ToList();
            }
            catch (Exception)
            {
                customers = null;
            }
            return customers;
        }
    }
}
