using Accounting.DataLayer.Repositories;
using Accounting.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        Acc_DBEntities _context = new Acc_DBEntities();
        private ICustomerRepository _customerRepository;

        public ICustomerRepository CustomerRepository {
            get {
                if(_customerRepository == null)
                {
                    return _customerRepository = new CustomerRepository(_context);
                }
                return _customerRepository;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
