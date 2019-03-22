using FolhaPagamento.DAL;
using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.View
{
    class ListEmployees
    {
        public static void Render()
        {

            if ((EmployeeDAO.ListEmployees() != null) && (!EmployeeDAO.ListEmployees().Any()))
            {
                foreach (Employee emplo in EmployeeDAO.ListEmployees())
                {
                    Console.WriteLine(emplo.ToString());
                }
            }

        }
    }
}
