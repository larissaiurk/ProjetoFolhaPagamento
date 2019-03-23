using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.DAL
{
    class EmployeeDAO
    {
        private static List<Employee> employees = new List<Employee>();

        public static List<Employee> ListEmployees()
        {
            return employees; ;
        }

        public static void RegisterEmployee(Employee e)
        {
            employees.Add(e);
        }

    }
}
