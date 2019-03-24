using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.DAL
{
    class SeedsDAO
    {
        public static void Add()
        {
            Employee e = new Employee
            {
                Name = "Larissa Iurk",
                CPF = "12345678909",
                Birthday = Convert.ToDateTime("29/07/1999"),
                CreatedAt = DateTime.Now
            };

            EmployeeDAO.RegisterEmployee(e);

            e = new Employee
            {
                Name = "Teste da Silva",
                CPF = "52392358052",
                Birthday = Convert.ToDateTime("05/01/1995"),
                CreatedAt = DateTime.Now
            };

            EmployeeDAO.RegisterEmployee(e);

            Position p = new Position
            {
                Description = "Programador",
                Bonus = 2,
                CreatedAt = DateTime.Now
            };

            PositionDAO.RegisterPosition(p);
            p = new Position
            {
                Description = "Vendedor",
                Bonus = 10,
                CreatedAt = DateTime.Now
            };
            PositionDAO.RegisterPosition(p);
        }
    }
}
