using Accounting.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Services
{
    public class CustomerRepository : ICustomerRepository,IDisposable
    {
        private Acc_DBEntities _context;
        public CustomerRepository(Acc_DBEntities context)
        {
            this._context = context;
        }
        public bool DeleteCustomer(Customers customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var customer = GetCustomerById(customerId);
                DeleteCustomer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Customers> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customers GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public bool InsertCustomer(Customers customer)
        {
            try
            {
                _context.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateCustomer(Customers customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
