using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class GameBoard
    {
        private Cell[,] cells;
        private List<Ship> ships;
        private int boardSize;
        private int shipsCount;

        public int Size => boardSize;
        public Cell[,] Cells => cells;


        public GameBoard(int boardSize, int shipsCount)
        {
            this.boardSize = boardSize;
            this.shipsCount = shipsCount;
            cells = new Cell[boardSize, boardSize];
            ships = new List<Ship>(shipsCount);
        }


        public void ArrangeShips()
        {
            prepareCells(); 
            prepareShips();
            Random random = new Random();
            Array orientations = Enum.GetValues(typeof(Orientation));
           
            foreach (Ship s in ships)
            {
                int x, y;
                Orientation orientation;
                do
                {
                    x = random.Next(boardSize);
                    y = random.Next(boardSize);
                    orientation = (Orientation) orientations.GetValue(random.Next(orientations.Length));

                } while (!CanAddShip(s, y, x, orientation));

                for (int i = 0; i < s.Length; i++)
                {
                    switch (orientation)
                    {
                        case Orientation.HORIZONTAL:
                            cells[y, x + i].addShip(s);
                            break;
                        case Orientation.VERTICAL:
                            cells[y + i, x].addShip(s);
                            break;
                    }
                    SetOccupied(y, x, s, orientation);
                }  
            }
        }


        private void SetOccupied(int y, int x, Ship s, Orientation orientation)
        { 
            switch (orientation)
            {
                case Orientation.HORIZONTAL:
                    for (int i = y - 1; i <= y + 1; i++)
                    {
                        if (i < 0 || i >= boardSize) 
                        {
                            continue;
                        }

                        for (int j = x - 1; j <= x + s.Length; j++)
                        {
                            if (j < 0 || j >= boardSize) 
                            {
                                continue;
                            }
                            
                            if (!cells[i, j].isDeck) 
                            {
                                cells[i, j].isOccupied = true;
                            }
                        }
                    }
                    break;

                case Orientation.VERTICAL:

                    for (int i = y - 1; i <= y + s.Length; i++)
                    {
                        if (i < 0 || i >= boardSize) 
                        {
                            continue;
                        }

                        for (int j = x - 1; j <= x + 1; j++)
                        {
                            if (j < 0 || j >= boardSize)
                            {
                                continue;
                            }
                                
                            if (!cells[i, j].isDeck) 
                            {
                                cells[i, j].isOccupied = true;
                            }
                        }
                    }
                    break;
            }
        }


        private bool CanAddShip(Ship s, int y, int x, Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.HORIZONTAL:
                    if (x + s.Length > boardSize - 1)
                    {
                        return false;
                    }
                        
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (cells[y, x + i].isDeck || cells[y, x + i].isOccupied) 
                        {
                            return false;
                        }
                    }
                    break;

                case Orientation.VERTICAL:
                    if (y + s.Length > boardSize - 1)
                    {
                        return false;
                    }

                    for (int i = 0; i < s.Length; i++)
                    {
                        if (cells[y + i, x].isDeck || cells[y + i, x].isOccupied) 
                        {
                            return false;
                        }
                    }
                    break;
            }
            return true;
        }


        private void prepareCells()
        {
            for (int i = 0; i < boardSize; i++) 
            {
                for (int j = 0; j < boardSize; j++) 
                {
                    cells[i, j] = new Cell();
                }
            }
        }


        private void prepareShips()
        {
            int i;
            for (i = 0; i < Settings.FOUR_DECKERS_COUNT; i++) 
            {
                ships.Add(new Ship(4));
            }
            for (i = 0; i < Settings.THREE_DECKERS_COUNT; i++) 
            {
                ships.Add(new Ship(3));
            }
            for (i = 0; i < Settings.TWO_DECKERS_COUNT; i++) 
            {
                ships.Add(new Ship(2));
            }
            for (i = 0; i < Settings.ONE_DECKERS_COUNT; i++) 
            {
                ships.Add(new Ship(1));
            }
        }
    }
}
