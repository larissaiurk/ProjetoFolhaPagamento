using FolhaPagamento.DAL;
using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.View
{
    class RegisterPosition
    {
        public static void Render()
        {
            Console.WriteLine(" -- CADASTRO DE CARGO -- ");

            Position p = new Position();

            Console.WriteLine("Digite a descrição do cargo");
            p.Description = Console.ReadLine();
            Console.WriteLine("Digite o bônus do cargo");
            p.Bonus = Convert.ToDouble(Console.ReadLine());

            PositionDAO.RegisterPosition(p);
            Console.WriteLine("\n Cargo cadastrado com sucesso! ");
        }
    }
}
