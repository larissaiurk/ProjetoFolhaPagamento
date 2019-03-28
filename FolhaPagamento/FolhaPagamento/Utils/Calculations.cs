using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.Utils
{
    class Calculations
    {
        public static Double GrossAmount(Double hours, Double value)
        {
            return hours * value;
        }
        public static Double Bonus(Double bonus, Double grossAmount)
        {
            return (bonus / 100) * grossAmount;
        }

        public static Double Ir(Double grossAmount)
        {
            Double aliquota = 0, ir=0;

            if (grossAmount >= 1903.99 && grossAmount <= 2826.65)
            {
                aliquota = grossAmount * 0.075;
                ir = aliquota - 142.8;
            }
            else if (grossAmount >= 2826.66 && grossAmount <= 3751.05)
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
            }else
            {
                ir = 0;
            }

            return ir;
        }

        public static Double Inss(Double grossAmount)
        {
            Double inss = 0;
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
            }else
            {
                inss = 0;
            }

            return inss;
        }

        public static Double Fgts(Double grossAmount)
        {
            return grossAmount * 0.08;
        }

        public static Double NetAmount(Double grossAmount, Double ir, Double inss)
        {
            return grossAmount - ir - inss;
        }
    }
}
