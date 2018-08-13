using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork db = new UnitOfWork();

            var customers = db.CustomerRepository.GetAllCustomers();

            foreach(var c in customers)
                Console.WriteLine(c.FullName);
            Console.ReadKey();
        }
    }
}
