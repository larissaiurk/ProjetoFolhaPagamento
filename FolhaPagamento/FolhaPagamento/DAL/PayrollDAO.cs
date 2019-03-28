using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.DAL
{
    class PayrollDAO
    {

        private static List<Payroll> payrolls = new List<Payroll>();

        public static List<Payroll> ListPayrolls()
        {
            return payrolls;
        }

        public static bool RegisterPayroll(Payroll p)
        {
            if (Search(p) == null)
            {
                payrolls.Add(p);
                return true;
            }
            return false;

        }

        public static Payroll Search(Payroll p)
        {
            foreach (var registeredPayroll in payrolls)
            {
                if (p.Employee.CPF.Equals(registeredPayroll.Employee.CPF) && 
                    p.PayrollDate.Month.Equals(registeredPayroll.PayrollDate.Month) && 
                    p.PayrollDate.Year.Equals(registeredPayroll.PayrollDate.Year))
                {
                    return registeredPayroll;
                }
            }
            return null;
        }

        public static List<Payroll> Search(String cpf)
        {
            List<Payroll> l = new List<Payroll>();
            foreach (Payroll registeredPayroll in payrolls)
            {
                if (registeredPayroll.Employee.CPF.Equals(cpf))
                {
                    l.Add(registeredPayroll);
                }
            }
            return l;
        }

        public static List<Payroll> Search(DateTime date)
        {
            List<Payroll> l = new List<Payroll>();
            foreach (Payroll registeredPayroll in payrolls)
            {
                if (registeredPayroll.PayrollDate.Month.Equals(date.Month) &&
                    registeredPayroll.PayrollDate.Year.Equals(date.Year))
                {
                    l.Add(registeredPayroll);
                }
            }
            return l;
        }
    }
}
