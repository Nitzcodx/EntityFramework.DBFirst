using print = System.Console;
using System;
using EF.DBFirst.DataAccessLayer;
using System.Collections.Generic;

namespace EF.DBFirst.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            print.WriteLine("Hello World!");
            InSystRepository repository = new InSystRepository();

            #region Read
            //var customers = repository.GetAllCustomers();
            //foreach (var cust in customers) print.WriteLine($"{cust.CustId}: {cust.FirstName} {cust.LastName}");
            //print.WriteLine($"------------------------------------------------------------------------------");
            //customers = repository.GetSpecificCustomers('F');
            //foreach (var cust in customers) print.WriteLine($"{cust.CustId}: {cust.FirstName} {cust.Gender}");
            //print.WriteLine($"------------------------------------------------------------------------------");
            //var customer = repository.GetCustomer(1001);
            //print.WriteLine(customer.CustId);
            //print.WriteLine($"------------------------------------------------------------------------------");
            //customers = repository.GetCustomerUsingLike("%ore");
            //foreach (var cust in customers) print.WriteLine($"{cust.City}: {cust.FirstName}");
            #endregion

            #region Create

            //repository.AddCredentials("", "");

            //List<DataAccessLayer.Models.Credential> creds = new List<DataAccessLayer.Models.Credential>
            //{
            //    new DataAccessLayer.Models.Credential
            //    {
            //        UserName = "",
            //        UserPassword = ""
            //    },
            //    new DataAccessLayer.Models.Credential
            //    {
            //        UserName = "",
            //        UserPassword = ""
            //    }
            //};
            //repository.AddBulkCredentials(creds);

            #endregion

            #region Update
            //repository.UpdatePassword("", "", "");
            //string msg = String.Empty;
            //repository.UpdateCustomerContact("", "", 1234567876, out msg);
            //print.WriteLine(msg);

            //repository.UpdateCredentials();
            #endregion

            #region Delete
            //repository.DeleteCredentials();
            #endregion

            #region SQL/SP's/Functions
            //var policies = repository.GetPoliciesUsingSQL();
            //foreach (var policy in policies) print.WriteLine($"{policy.PolicyId} : {policy.PolicyType}");


            #endregion  
        }
    }
}

// MS.EFCore.SqlServer
// MS.EFCore.Tools
//-------------------------------------------------------------------
// Scaffold-DbContext -Connection
//                          "Data Source =desktop-tej7tld;
//                           Initial Catalog=InSyst;
//                           Integrated Security=true"
//                    -Provider
//                           Microsoft.EntityFrameworkCore.SqlServer
//                    -OutputDir
//                           Models
//-------------------------------------------------------------------
//MS.Extensions.Configurations.FileExtensions
//MS.Extensions.Configurations
//MS.Extensions.Configurations.Json
//-------------------------------------------------------------------
//appsettings.json
//{
//    "ConnectionStrings": {
//        "InSystDBConnectionString": "Data Source =desktop-tej7tld; Initial Catalog=InSyst; Integrated Security=true"
//    }
//}
//-------------------------------------------------------------------
//var builder = new ConfigurationBuilder().
//                            SetBasePath(Directory.GetCurrentDirectory()).
//                            AddJsonFile("appsettings.json");
//var config = builder.Build();
//var connectionString = config.GetConnectionString("InSystDBConnectionString");
//-------------------------------------------------------------------
