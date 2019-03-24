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
        
    }
}
