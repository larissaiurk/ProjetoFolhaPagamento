using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.Model
{
    class Payroll
    {
        public Employee Employee { get; set; }
        public Position Position { get; set; }
        public int Hours { get; set; }
        public Double Value { get; set; }
        public DateTime PayrollDate { get; set; } // just mounth and year matters
        public DateTime CreatedAt { get; set; }

        public Payroll()
        {
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {

            return "\n Data: "+ PayrollDate.Month+"/"+PayrollDate.Year +
                "\n Funcionário: "+ Employee.Name +"| Cargo: "+Position.Description +
                "| Valor da Hora: "+Value+" | Quantidade de horas: " + Hours;

        }


    }
    }
