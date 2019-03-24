using FolhaPagamento.DAL;
using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.View
{
    class RegisterPayroll
    {
        public static void Render()
        {
            Console.Write("\n -- CADASTRO FOLHA DE PAGAMENTO -- ");

            Position p = new Position();
            Employee e = new Employee();
            Payroll pay = new Payroll();

            //employee
            Console.WriteLine("Digite o CPF do funcionário");
            e.CPF = Console.ReadLine();
            e = EmployeeDAO.SearchByCpf(e);
            if (e != null )
            {
                //add employee on payroll
                pay.Employee = e;

                //position
                Console.WriteLine("Digite o nome do cargo do funcionário");
                p.Description = Console.ReadLine();
                p = PositionDAO.SearchByName(p);
                if (p != null)
                {
                    //add position on payroll
                    pay.Position = p;

                    //adds the rest of the information on the payroll
                    DateTime dataValida;
                    Console.WriteLine("Digite o mês e o ano da folha de pagamento (mm/yyyy)");
                    String date = Console.ReadLine();
                    date = "01/" + date;
                    if (DateTime.TryParse(date, out dataValida))
                    {
                        pay.PayrollDate = dataValida;

                        Console.WriteLine("Digite o número de horas trabalho");
                        pay.Hours = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o valor da hora de trabalho");
                        pay.Value = Convert.ToDouble(Console.ReadLine());

                        PayrollDAO.RegisterPayroll(pay);
                        Console.WriteLine("Folha de pagamento cadastrada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Atenção! Erro ao cadastrar data da folha de pagamento");
                    }

                }else
                {
                    Console.WriteLine("Atenção! Cargo não encontrado!");
                }



            }else
            {
                Console.WriteLine("Atenção! Funcionário não encontrado!");
            }

        }

    }
}
