using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class BoardFactory
    {
        public static GameBoard makeBoard()
        {
            GameBoard board = new GameBoard(getCells(), getShips());
            return board;
        }

        private static int getCells() => Settings.boardSize;

        private static int getShips() => Settings.oneDeckersCount + Settings.twoDeckersCount + Settings.threeDeckersCount + Settings.fourDeckersCount;
    }
}
