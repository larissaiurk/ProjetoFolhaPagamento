using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.Model
{
    class Employee
    {

        public String Name { get; set; }
        public String CPF { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }

        public Employee()
        {
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {

            return "Nome: " + Name + "| CPF: " + CPF + "| Data Nascimento: " + Convert.ToString(Birthday);
        }
    }

   
}
