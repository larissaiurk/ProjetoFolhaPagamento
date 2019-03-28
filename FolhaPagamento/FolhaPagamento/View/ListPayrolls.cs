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
    class ListPayrolls
    {
        public static void Render()
        {
            Console.WriteLine("\n -- LISTA DE FOLHAS DE PAGAMENTO -- ");
            foreach (Payroll pay in PayrollDAO.ListPayrolls())
            {
                Console.WriteLine(pay.ToString());
            }
        }
        
        public static void ListByEmployee()
        {
            //create objects
            Payroll pay = new Payroll();
            Employee emp = new Employee();
            Double grossAmount = 0, netAmount = 0, bonus = 0, ir = 0, inss = 0, fgts = 0;

            //read employee cpf
            Console.WriteLine("Digite o CPF  do funcionário");
            emp.CPF = Console.ReadLine();
            //search employee
            emp = EmployeeDAO.SearchByCpf(emp);

            if (emp != null)
            {
                //add employee
                pay.Employee = emp;
                
                //read date
                Console.WriteLine("Digite o mês e ano da folha de pagamento (mm/yyyy)");
                DateTime dataValida;
                String date = Console.ReadLine();
                date = "01/" + date;
                
                //validate date
                if (DateTime.TryParse(date, out dataValida))
                {
                    pay.PayrollDate = dataValida;
                    
                    //search payroll
                    pay = PayrollDAO.Search(pay);
                    if (pay != null)
                    {
                        //title
                        Console.WriteLine("\n -- LISTA DE FOLHAS DE PAGAMENTO FUNCIONÁRIO -- ");
                        
                        //Header
                        Console.WriteLine(pay.ToString());
                        Console.WriteLine("\n Horas: " + pay.Hours + "\n Valor da Hora: " + pay.Value);

                        //Bonus
                        grossAmount = Calculations.GrossAmount(pay.Hours, pay.Value);
                        bonus = Calculations.Bonus(pay.Position.Bonus,grossAmount);
                        //Gross Amount 
                        //todo: REVER ISSO AQUI
                        grossAmount += bonus;

                        //calculo IR
                        ir = Calculations.Ir(grossAmount);

                        //calculo inss
                        inss = Calculations.Inss(grossAmount);

                        //calculo fgts
                        fgts = Calculations.Fgts(grossAmount);

                        //salario liquido
                        netAmount = Calculations.NetAmount(grossAmount, ir, inss);

                        Console.Write("\n Bruto: " + Convert.ToString(grossAmount - bonus) + " | Bonus: " + Convert.ToString(bonus) +
                        " | Bruto + Bonus: " + Convert.ToString(grossAmount)  +
                            " | IR: " + Convert.ToString(ir) + " | INSS: " + Convert.ToString(inss) + " | FGTS: " + Convert.ToString(fgts) +
                            "\n Líquido: " + Convert.ToString(netAmount));
                    }
                    else
                    {
                        Console.WriteLine("Atenção! Folha de pagamento não encontrada.");
                    }
                }
                else
                {
                    Console.WriteLine("Atenção! Data inválida");
                }
            }
            else
            {
                Console.Write("Antenção! Funcionário não encontrado.");
            }
        }

        public static void ListByEmployeeHistoricByCpf()
        {
            List<Payroll> pp = new List<Payroll>();
            String cpf;
            //read employee cpf
            Console.WriteLine("Digite o CPF  do funcionário");
            cpf = Console.ReadLine();
            pp = PayrollDAO.Search(cpf);

            pp = (from e in pp
                  orderby e.PayrollDate
                  select e).ToList();

            Console.WriteLine("\n -- HISTÓRICO LISTA DE FOLHAS DE PAGAMENTO FUNCIONÁRIO POR FUNCIONÁRIO -- \n");
            //To Do: totalizar as horas
            Double total = 0;
            foreach (var item in pp)
            {
                total += ListPayroll(item);
            }

            Console.WriteLine("\n Total sálarios: "+Convert.ToString(total));

        }

        public static void ListByEmployeeHistoricByDate()
        {
            List<Payroll> pp = new List<Payroll>();

            //read date
            Console.WriteLine("Digite o mês e ano da folha de pagamento (mm/yyyy)");
            DateTime dataValida;
            String date = Console.ReadLine();
            date = "01/" + date;
            if (DateTime.TryParse(date, out dataValida))
            {
                pp = PayrollDAO.Search(dataValida);

                pp = (from e in pp
                      orderby e.Employee.Name
                      select e).ToList();

                Console.WriteLine("\n -- HISTÓRICO LISTA DE FOLHAS DE PAGAMENTO FUNCIONÁRIO POR DATA-- \n");
                //To Do: totalizar as horas
                Double total = 0;
                foreach (var item in pp)
                {
                    total += ListPayroll(item);
                }
                Console.WriteLine("\n Total sálarios: " + Convert.ToString(total));
            }
            else
            {
                Console.WriteLine("Atenção! Data inválida.");
            }
        }

        public static Double ListPayroll(Payroll pay)
        {
            Double grossAmount = 0, netAmount = 0, bonus = 0, ir = 0, inss = 0, fgts = 0;
            //title
            Console.WriteLine("\n -- LISTA DE FOLHAS DE PAGAMENTO FUNCIONÁRIO -- \n");

            //Header
            Console.WriteLine(pay.ToString());
            Console.WriteLine("\n Horas: " + pay.Hours + "\n Valor da Hora: " + pay.Value);

            //Bonus
            grossAmount = Calculations.GrossAmount(pay.Hours, pay.Value);
            bonus = Calculations.Bonus(pay.Position.Bonus, grossAmount);
            //Gross Amount 
            //todo: REVER ISSO AQUI
            grossAmount += bonus;

            //calculo IR
            ir = Calculations.Ir(grossAmount);

            //calculo inss
            inss = Calculations.Inss(grossAmount);

            //calculo fgts
            fgts = Calculations.Fgts(grossAmount);

            //salario liquido
            netAmount = Calculations.NetAmount(grossAmount, ir, inss);

            Console.Write("\n Bruto: " + Convert.ToString(grossAmount - bonus) + " | Bonus: " + Convert.ToString(bonus) +
            " | Bruto + Bonus: " + Convert.ToString(grossAmount) +
                " | IR: " + Convert.ToString(ir) + " | INSS: " + Convert.ToString(inss) + " | FGTS: " + Convert.ToString(fgts) +
                "\n Líquido: " + Convert.ToString(netAmount) + "\n");

            return netAmount;
        }
    }
}
