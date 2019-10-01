using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        private string playerName = "";
        private int position = 0;

        public Player(string name)
        {
            playerName = name;
        }

        public int getPosition()
        {
            return position;
        }

        public string getPlayerName()
        {
            return playerName;
        }

        public void setPosition( int position)
        {
            this.position = position;
        }
    }
}
