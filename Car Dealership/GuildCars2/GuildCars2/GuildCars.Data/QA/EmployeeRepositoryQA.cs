using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.QA
{
    public class EmployeeRepositoryQA : IEmployeeRepository
    {
        public void CreateEmployee(Employees employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employees employee)
        {
            throw new NotImplementedException();
        }

        public List<Employees> ReadAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employees ReadByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employees employee)
        {
            throw new NotImplementedException();
        }
    }
}
