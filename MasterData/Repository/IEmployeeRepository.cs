using MasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterData.Repository
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int id);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        void Save(Employee employee);
    }
}