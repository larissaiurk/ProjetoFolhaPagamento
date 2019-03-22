using FolhaPagamento.DAL;
using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.View
{
    class RegisterEmployee
    {
        public static void Render()
        {
            Console.WriteLine(" -- CADASTRO DE FUNCIONÁRIO -- ");

            Employee e = new Employee();

            Console.WriteLine("Digite o nome do funcionário");
            e.Name = Console.ReadLine();
            Console.WriteLine("Digite o CPF do funcionário");
            e.CPF = Console.ReadLine();
            //Console.WriteLine("Digite o data de nascimento do funcionário");
            //e.Birthday = Convert.ToDateTime(Console.ReadLine());

            EmployeeDAO.RegisterEmployee(e);
            Console.WriteLine(" Funcionário cadastrado com sucesso! ");
        }
    }
}
