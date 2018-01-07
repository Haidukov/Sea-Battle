using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class BoardFactory
    {
        private static int getCells() => Settings.boardSize;


        private static int getShips() => Settings.oneDeckersCount + Settings.twoDeckersCount + Settings.threeDeckersCount + Settings.fourDeckersCount;


        public static GameBoard makeBoard()
        {
            GameBoard board = new GameBoard(getCells(), getShips());
            return board;
        }
    }
}
