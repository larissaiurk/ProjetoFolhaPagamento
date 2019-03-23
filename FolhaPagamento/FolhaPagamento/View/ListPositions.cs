using FolhaPagamento.DAL;
using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.View
{
    class ListPositions
    {
        public static void Render()
        {
            Console.WriteLine(" -- LISTA DE CARGOS -- ");
            foreach (Position posi in PositionDAO.ListPositions())
            {
                Console.WriteLine(posi.ToString());
            }
        }
    }
}
