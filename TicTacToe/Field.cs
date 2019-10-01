using System;

namespace TicTacToe
{
    public class Field
    {

        private static string[,] field = new string[9,9];
        private static string[,] miniField = new string[3,3];

        private bool isFirstStep = true;
        private bool isSubFieldFull = false;
        private int countOfFreeCells = 81;
        private int iPossibleForNextStep;
        private int jPossibleForNextStep;

        public void InitField()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    field[i,j] = (i*9 + j + 1).ToString();
                }    
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    miniField[i, j] = "-";
                }
            }
        }

        private void PrintBigField()
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i == 0
                        ? "  ____________________________________________"
                        : " |______________|______________|______________|");
                    Console.WriteLine(" |              |              |              |");
                }

                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(" | ");
                    }

                    if ((field[i, j] == "X" || field[i, j] == "O") && (i > 0))
                    {
                        Console.Write(" {0}  ", field[i, j]);
                    }
                    else
                    {
                        Console.Write(i == 0 ? " {0}  " : " {0} ", field[i, j]);
                    }
                    if ((j + 1) % 3 == 0)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(" |______________|______________|______________|");
        }

        private void PrintMiniField()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i == 0
                        ? "  _________________"
                        : " |_____|_____|_____|");
                Console.WriteLine(
                          " |     |     |     |");

                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(" | ");
                    }

                    Console.Write(" {0} ", miniField[i, j]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" |_____|_____|_____|");
            Console.WriteLine();
        }

        public void PrintField()
        {
            PrintBigField();
            PrintMiniField();
        }

        public int GetCountOfFreeCells()
        {
            return countOfFreeCells;
        }

        private void CheckPartialWin(String symbol)
        {
            for (int k = 0; k < 3; k++) 
            {
                for (int l = 0; l < 3; l++) 
                {              
                    for (int i = 3*k; i < 3 + 3*k; i++) 
                    {
                        int horizontal = 0;
                        int vertical = 0;
                        for (int j = 3*l; j < 3 + 3*l; j++)
                        {
                            if (field[i, j] == symbol) 
                            {
                                ++horizontal; 
                            }
                            if (field[j, i] == symbol)
                            {
                                ++vertical;
                            }
                        }
                        if (horizontal == 3)
                        {
                            if (miniField[k, l] == "-")
                            {
                                miniField[k, l] = symbol;
                              
                            }
                        }
                        if (vertical == 3)
                        {
                            if (miniField[k, l] == "-")
                            {
                                miniField[l, k] = symbol;

                            }
                        }
                    }
                    if (field[3*k, 3*l] == symbol &&
                        field[3*k + 1, 3*l + 1] == symbol &&
                        field[3*k + 2, 3*l + 2] == symbol)
                    {
                         if (miniField[k, l] == "-")
                         {
                             miniField[k, l] = symbol;

                         }
                    }
                    if (field[3*k, 3*l + 2] == symbol &&
                            field[3*k + 1, 3*l + 1] == symbol &&
                            field[3*k + 2, 3*l] == symbol)
                    {
                        if (miniField[k, l] == "-")
                        {
                            miniField[k, l] = symbol;

                        }
                    }
                }
            }
        }

        public bool IsWin(String symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                int horizontal = 0;
                int vertical = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (miniField[i, j] == symbol)
                    {
                        ++horizontal;
                    }
                    if (miniField[j, i] == symbol)
                    {
                        ++vertical;
                    }
                }
                if (horizontal == 3 || vertical == 3)
                {
                    return true;
                }
            }
            if (miniField[0, 0] == symbol && miniField[1, 1] == symbol && miniField[2, 2] == symbol)
            {
                return true;
            }
            if (miniField[0, 2] == symbol && miniField[1, 1] == symbol && miniField[2, 0] == symbol)
            {
                return true;
            }
            return false;
        }

        private bool IsSubFieldFull(int iCurrStep, int jCurrStep)
        {
            int countOfFreeCellsInSubField = 9;

            for (int i = 3 * iCurrStep; i < 3 + 3 * iCurrStep; i++)
            {
                for (int j = 3 * jCurrStep; j < 3 + 3 * jCurrStep; j++)
                {
                    if (field[i, j] == "O" || field[i, j] == "X")
                    {
                        --countOfFreeCellsInSubField;
                    }
                }
            }
            if (countOfFreeCellsInSubField == 0)
            {
                return true;
            }
            return false;
        }

        public bool MakeStep(int step, String symbol)
        {
            if (step < 1 || step > 81)
            {
                Console.WriteLine("Sorry, choose a cell from 1 to 81!");
                return false;
            }

            if (isFirstStep)
            {
                field[(step - 1)/9, (step - 1)%9] = symbol; 
                countOfFreeCells--;
                isFirstStep = false;
                iPossibleForNextStep = (step - 1)/9%3;
                jPossibleForNextStep = (step%9 == 0) ? ((step - 3)%9 - 1)%3 : (step%9 - 1)%3;
                return true;
            }

            if (isSubFieldFull)
            {
                if ((field[(step - 1)/9, (step - 1)%9] == "X") || (field[(step - 1)/9, (step - 1)%9] == "O"))
                {
                    Console.WriteLine("Sorry, there is already a symbol X or O, try to make a step in another coord!");
                    return false;
                }
                else
                {
                    field[(step - 1) / 9, (step - 1) % 9] = symbol; 
                    countOfFreeCells--;
                    CheckPartialWin("X");
                    CheckPartialWin("O");
                    iPossibleForNextStep = (step - 1) / 9 % 3;
                    jPossibleForNextStep = (step % 9 == 0) ? ((step - 3) % 9 - 1) % 3 : (step % 9 - 1) % 3;
                    isSubFieldFull = false;
                    return true;
                }
     
            }

            int iCurrStep = (step - 1)/9/3;
            int jCurrStep = (step - 1)%9/3;

            if (iPossibleForNextStep == iCurrStep && jPossibleForNextStep == jCurrStep)
            {
                if (IsSubFieldFull(iCurrStep, jCurrStep))
                {
                    isSubFieldFull = true;
                    Console.WriteLine("Sorry, the field where u want to step is already full! Choose any other field!");
                    return false;
                }
 
                if ((field[(step - 1)/9, (step - 1)%9] == "X") || (field[(step - 1)/9, (step - 1)%9] == "O"))
                {
                    Console.WriteLine("Sorry, there is already a symbol X or O, try to make a step in another coord!");
                    return false;
                }

                field[(step - 1)/9, (step - 1)%9] = symbol;
                countOfFreeCells--;
                CheckPartialWin("X");
                CheckPartialWin("O");
                iPossibleForNextStep = (step - 1)/9%3;
                jPossibleForNextStep = (step%9 == 0) ? ((step - 3)%9 - 1)%3 : (step%9 - 1)%3;
                return true;
            }
            else
            {
                Console.WriteLine("Sorry, incorrect step, choose a step according to the last step of your opponent!");
                return false;
            }

            return true;
        }
    }
}