using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterData.Repository
{
    public class UnitOFWork : IUnitOfWork
    {
        private EmployeeContext _context = null;
        public UnitOFWork()
        {
            _context = new EmployeeContext();
        }
        private IEmployeeRepository _employeeRepository = null;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if(_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}