using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.Model
{
    class Employee
    {
        public Employee()
        {
            CreatedAt = DateTime.Now;
        }

        public String Name { get; set; }
        public String CPF { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }



        public override string ToString()
        {

            return "\n Nome: " + Name + " | CPF: " + CPF + " | Data Nascimento: " + 
                Convert.ToString(Birthday.Day)+"/"+ Convert.ToString(Birthday.Month)+"/"+Convert.ToString(Birthday.Year);
        }
    }

   
}
