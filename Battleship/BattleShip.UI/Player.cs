using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class Player// Responsibility: keeps track of player data
    {
        public Board Board { get; set; }
        public String Name { get; set; }
        public Player(String name)
        {
            Board = new Board();
            Name = name;
        }
    }
}
