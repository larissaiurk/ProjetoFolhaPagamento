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

        public static bool RegisterPosition(Position p)
        {
            if (SearchByName(p) == null)
            {
                positions.Add(p);
                return true;
            }
            return false;
            
        }
        
        public static Position SearchByName(Position p)
        {
            foreach (var registeredPosition in positions)
            {
                if (p.Description.Equals(registeredPosition.Description))
                {
                    return registeredPosition;
                }
            }
            return null;
        }
    }
}
