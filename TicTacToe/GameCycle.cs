using System;

namespace TicTacToe
{
    class GameCycle
    {
        Field ticTacToeField;

        public void Start()
        {
            ticTacToeField = new Field();
            Boolean isXMovie = true;

            ticTacToeField.InitField();
            ticTacToeField.PrintField();

            Console.WriteLine("Please type the number where you want to put your symbol ");

            while (ticTacToeField.GetCountOfFreeCells() != 0) //пока есть клетки, куда можно походить
            {
                int cellNumber;
                if (isXMovie)
                {
                    Console.Write("Player X: ");
                    while (!int.TryParse(Console.ReadLine(), out cellNumber))
                    {
                        Console.WriteLine("Please enter a digit!");
                        Console.Write("Player X: ");
                    }
                    if (!ticTacToeField.MakeStep(cellNumber, "X"))
                    {
                        continue;
                    }
                    ticTacToeField.PrintField();
                    if (ticTacToeField.IsWin("X"))
                    {
                        Console.WriteLine("CONGRATULATIONS!! PLAYER X WON!!");
                        break;
                    }
                    if (ticTacToeField.IsWin("O"))
                    {
                        Console.WriteLine("CONGRATULATIONS!! PLAYER O WON!!");
                        break;
                    }
                    isXMovie = false;
                }
                else
                {      
                    Console.Write("Player O: ");
                    while (!int.TryParse(Console.ReadLine(), out cellNumber))
                    {
                        Console.WriteLine("Please enter a digit!");
                        Console.Write("Player O: ");
                    }
                    if (!ticTacToeField.MakeStep(cellNumber, "O"))
                    {
                        continue;
                    }
                    ticTacToeField.PrintField();
                    if (ticTacToeField.IsWin("O"))
                    {
                        Console.WriteLine("CONGRATULATIONS!! PLAYER O WON!!");
                        break;
                    }
                    if (ticTacToeField.IsWin("X"))
                    {
                        Console.WriteLine("CONGRATULATIONS!! PLAYER X WON!!");
                        break;
                    }
                    isXMovie = true;
                }
            }
            if (ticTacToeField.GetCountOfFreeCells() == 0)
            {
                Console.WriteLine("DRAW! YOU BOTH WERE DOING WELL!");
            }
            Console.ReadLine();
        }
    }
}
