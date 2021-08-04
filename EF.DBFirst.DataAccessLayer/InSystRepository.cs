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

            //Entity State used to track changes
            //State: Unchanged
            //context.Entry(customers.First()).State  -- row level state

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

        public bool AddCredentials(string userName, string password)
        {
            Credential newCred = new Credential();
            newCred.UserName = userName;
            newCred.UserPassword = password;
            //State : Detached
            //context.Entry(newCred).State
            bool status = false;
            try
            {
                context.Add<Credential>(newCred);
                //context.Credentials.Add(newCred);

                //State : Added
                //context.Entry(newCred).State

                //Changes are saves only in local copy(application memory) in here and not in Db
                context.SaveChanges();

                //State : Added

                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool AddBulkCredentials(List<Credential> creds)
        {
            bool status = false;
            try
            {
                context.Credentials.AddRange(creds);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public Credential SearchCredential(string userName, string password)
        {
            Credential cred = (from _cred in context.Credentials
                                where _cred.UserName.Equals(userName) && _cred.UserPassword.Equals(password)
                                select _cred).FirstOrDefault();
            return cred;
        }

        public bool UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            bool status = false;
            Credential cred = SearchCredential(userName, oldPassword);
            //Credential cred = context.Credentials.Find(credId);
            if (cred != null)
            {
                try
                {
                    cred.UserPassword = newPassword;
                    //State : Modified
                    context.SaveChanges();
                    status = true;
                }
                catch (Exception)
                {
                    status = false;
                }
            }
            return status;
        }

        public bool UpdateCustomerContact(string userName, string password,decimal contantNo, out string msg)
        {
            bool status = false;
            Credential cred = SearchCredential(userName, password);
            if (cred != null)
            {
                Customer cust = (from _customer in context.Customers
                                 where _customer.CredentialId.Equals(cred.CredentialId)
                                 select _customer).FirstOrDefault();

                cust.PhoneNumber = contantNo;

                using (var newContext = new InSystContext())
                {
                    try
                    {
                        newContext.Customers.Update(cust);
                        newContext.SaveChanges();
                        msg = "Contact updated successfully!";
                        status = true;
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        msg = $"Error technical error occurred. Please try again later." + Environment.NewLine +
                            $"{ex.InnerException.Message}";
                    }
                }
            }
            else msg = $"Invalid username or password.";
            return status;
        }

        public bool UpdateCredentials()
        {
            bool status = false;
            List<Credential> creds = (from _cred in context.Credentials
                                      where _cred.RoleId == null
                                      select _cred).ToList();
            foreach (var cred in creds) cred.RoleId = 1;
            try
            {
                using(var newContext = new InSystContext())
                {
                    newContext.Credentials.UpdateRange(creds);
                    newContext.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        public bool DeleteCredentials()
        {
            bool status = false;
            List<Credential> creds = (from _cred in context.Credentials
                                      where _cred.CredentialId.Equals(1008) || _cred.CredentialId.Equals(1009)
                                      select _cred).ToList();
            try
            {
                using(var newContext = new InSystContext())
                {
                    newContext.Credentials.RemoveRange(creds);
                    //State : Deleted
                    newContext.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            return status;
        }

        public List<Policy> GetPoliciesUsingSQL()
        {
            List<Policy> policies = null;
            try
            {
                policies = context.Policies.FromSqlRaw($"SELECT * FROM Policies").ToList();
                //context.Database.ExecuteSqlRaw($"EXEC usp_<> {param1}") -- cannot exec usp with select command
            }
            catch (Exception)
            {
                policies = null;
            }
            return policies;
        }

    }
}
