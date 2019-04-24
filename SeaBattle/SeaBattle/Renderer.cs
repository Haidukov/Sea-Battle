using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    class Renderer
    {
        public static void Render(GameBoard board)
        {
            if (board == null) return;

            Console.Title = "Sea Battle";
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0, n = 3 - (int) Math.Log10(board.Size); i < n; i++) {
                Console.Write(" ");
            }

            for (char i = 'A'; i < board.Size + 'A'; i++) {
                Console.Write(" " + i);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            for (int i = 0; i < board.Size; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i + 1 + " ");

                for (int j = 1, n = 1 - (int) Math.Log10(i + 1) + 1; j < n; j++) {
                    Console.Write(" ");
                }
                    
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.Cells[i, j].isDeck)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("* ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
