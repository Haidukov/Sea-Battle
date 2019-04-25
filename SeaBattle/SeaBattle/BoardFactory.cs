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

        private static int getCells() => Settings.BOARD_SIZE;

        private static int getShips() => Settings.ONE_DECKERS_COUNT + Settings.TWO_DECKERS_COUNT + Settings.THRE_DECKERS_COUNT + Settings.FOUR_DECKERS_COUNT;
    }
}
