using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.Model
{
    class Position
    {
        public String Description { get; set; }
        public Double Bonus { get; set; }

        public DateTime CreatedAt { get; set; }

        public Position()
        {
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {

            return "\n Nome: " + Description + " | Bônus: " + Bonus;
        }

    }
    
}
