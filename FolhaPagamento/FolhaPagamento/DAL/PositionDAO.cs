using FolhaPagamento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento.DAL
{
    class PositionDAO
    {
        private static List<Position> positions = new List<Position>();

        public static List<Position> ListPositions()
        {
            return positions;
        }

        public static void RegisterPosition(Position p)
        {
            positions.Add(p);
        }
    }
}
