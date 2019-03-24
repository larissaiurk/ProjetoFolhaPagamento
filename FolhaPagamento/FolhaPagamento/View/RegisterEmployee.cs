using FolhaPagamento.DAL;
using FolhaPagamento.Model;
using FolhaPagamento.Utils;
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
            Console.WriteLine("\n -- CADASTRO DE FUNCIONÁRIO -- ");
            //create employee
            Employee e = new Employee();
            Console.WriteLine("Digite o CPF do funcionário");
            e.CPF = Console.ReadLine();
            //validate cpf
            if (Validation.ValidateCpf(e.CPF)) { 
                Console.WriteLine("Digite o nome do funcionário");
                e.Name = Console.ReadLine();
                //validate birthday
                String date;
                DateTime dataValida;
                Console.WriteLine("Digite o data de nascimento do funcionário (dd/mm/yyyy)");
                date = Console.ReadLine();
                if (DateTime.TryParse(date, out dataValida)) {
                    e.Birthday = dataValida;
                    //if everything is validated, register employee
                    if (EmployeeDAO.RegisterEmployee(e)) { 
                        Console.WriteLine("\n Funcionário cadastrado com sucesso! ");
                    }else
                    {
                        Console.WriteLine("\n Atenção! Funcionário já existente na base de dados! ");
                    }
                } else
                {
                    Console.WriteLine("Atenção! Data inválida");
                }
            }else { Console.WriteLine("Atenção! CPF inválido! "); }
        }
    }
}
