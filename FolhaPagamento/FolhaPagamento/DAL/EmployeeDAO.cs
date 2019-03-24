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

        public static bool RegisterEmployee(Employee e)
        {
            if (SearchByCpf(e) == null) { 
                employees.Add(e);
                return true;
            }
            return false;
        }

        public static Employee SearchByCpf(Employee e)
        {
            foreach (var registeredEmployee in employees)
            {
                if (e.CPF.Equals(registeredEmployee.CPF))
                {
                    return registeredEmployee;
                }
            }
            return null;
        }

    }
}
