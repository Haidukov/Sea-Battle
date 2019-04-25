using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Game
    {
        private GameBoard board;
        
        public void Start()
        {
            GetBoard();
            PrepareBoard();
            RenderBoard();
            Console.ReadLine();
        }


        private void GetBoard()
        {
            board = BoardFactory.makeBoard();
        }


        private void PrepareBoard()
        {

            board.ArrangeShips();
        }


        private void RenderBoard()
        {
            Renderer.Render(board);
        }
    }
}
