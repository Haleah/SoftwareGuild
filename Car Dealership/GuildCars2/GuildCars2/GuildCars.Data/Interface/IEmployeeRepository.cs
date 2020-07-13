using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IEmployeeRepository
    {
        List<Employees> ReadAllEmployees();
        Employees ReadByEmployeeId(int employeeId);
        void CreateEmployee(Employees employee);
        void UpdateEmployee(Employees employee);
        void DeleteEmployee(Employees employee);
    }
}
