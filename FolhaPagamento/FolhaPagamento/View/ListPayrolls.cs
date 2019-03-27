using FolhaPagamento.DAL;
using FolhaPagamento.Model;
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
        
        public static void listByEmployee(Payroll pay)
        {
            
            pay = PayrollDAO.Search(pay);
            if (pay != null) {
                Console.WriteLine("\n -- LISTA DE FOLHAS DE PAGAMENTO FUNCIONÁRIO -- ");
                //Cabeçalho
                Console.WriteLine(pay.ToString());
                Console.WriteLine("\n Horas: " + pay.Hours + "\n Valor da Hora: " + pay.Value);
                Console.WriteLine("\n ---------------------");

                //Calculos - eu quero dividir isso pra outra classe, eu crio uma validacao? crio um dto de calculos? ou faco tudo aqui mesmo?
                Double grossAmount=0, netAmount=0, bonus=0, aliquota=0,
                    ir=0, inss=0, fgts=0, grossAmountBonus=0;
                //Bonus - ok
                grossAmount = pay.Hours * pay.Value;
                bonus = (pay.Position.Bonus / 100) * grossAmount;
                //Gross Amount - revisar calculo
                grossAmount += bonus;

                //calculo IR
                if (grossAmount >= 1903.99 && grossAmount <= 2826.65)
                {
                    aliquota = grossAmount * 0.075;
                    ir = aliquota - 142.8;
                }else if(grossAmount >= 2826.66 && grossAmount <= 3751.05)
                {
                    aliquota = grossAmount * 0.15;
                    ir = aliquota - 354.8;
                }
                else if (grossAmount >= 3751.06 && grossAmount <= 4664.68)
                {
                    aliquota = grossAmount * 0.225;
                    ir = aliquota - 636.13;
                }
                else if (grossAmount > 4664.68)
                {
                    aliquota = grossAmount * 0.275;
                    ir = aliquota - 869.36;
                }

                //calculo inss
                if (grossAmount <= 1693.72)
                {
                    inss = grossAmount * 0.08;
                }
                else if (grossAmount >= 1693.73 && grossAmount <= 2822.90)
                {
                    inss = grossAmount * 0.09;
                }
                else if (grossAmount >= 2822.91 && grossAmount <= 5645.8)
                {
                    inss = grossAmount * 0.11;
                }
                else if (grossAmount >= 5645.81)
                {
                    inss = 621.03;
                }

                //calculo fgts
                fgts = grossAmount * 0.08;

                //salario liquido
                netAmount = grossAmount - ir - inss;

                Console.Write("\n Bruto: " +Convert.ToString(grossAmount - bonus) + " | Bonus: " + Convert.ToString(bonus) +
                " | Bruto + Bonus: " + Convert.ToString(grossAmount) + " \n Aliquota: " + Convert.ToString(aliquota) +
                    " | IR: " + Convert.ToString(ir)+" | INSS: " + Convert.ToString(inss) + " | FGTS: " + Convert.ToString(fgts)+
                    "\n Líquido: " + Convert.ToString(netAmount));

            }
            else
            {
                Console.WriteLine("Atenção! Folha de pagamento não encontrada");
            }
        }

    }
}
