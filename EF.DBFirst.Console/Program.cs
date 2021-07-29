using print = System.Console;
using System;
using EF.DBFirst.DataAccessLayer;
namespace EF.DBFirst.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            print.WriteLine("Hello World!");
            InSystRepository repository = new InSystRepository();
            var customers = repository.GetAllCustomers();
            foreach (var cust in customers) print.WriteLine($"{cust.CustId}: {cust.FirstName} {cust.LastName}");
            print.WriteLine($"------------------------------------------------------------------------------");
            customers = repository.GetSpecificCustomers('F');
            foreach (var cust in customers) print.WriteLine($"{cust.CustId}: {cust.FirstName} {cust.Gender}");
            print.WriteLine($"------------------------------------------------------------------------------");
            var customer = repository.GetCustomer(1001);
            print.WriteLine(customer.CustId);
            print.WriteLine($"------------------------------------------------------------------------------");
            customers = repository.GetCustomerUsingLike("%ore");
            foreach (var cust in customers) print.WriteLine($"{cust.City}: {cust.FirstName}");
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
