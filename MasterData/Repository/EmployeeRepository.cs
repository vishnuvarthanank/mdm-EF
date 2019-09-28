using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterData.Models;
using System.Data.Entity;

namespace MasterData.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly EmployeeContext db;
        public EmployeeRepository(EmployeeContext _db)
        {
            db = _db;
        }

        public Employee GetEmployeeByID(int id)
        {
            return db.Employee.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employee.AsEnumerable();
        }

        public void RemoveEmployee(Employee employee)
        {
            Employee _employee = GetEmployeeByID(employee.Id);
            db.Employee.Remove(_employee);
        }

        public void Save(Employee employee)
        {
            db.Employee.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}