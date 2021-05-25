using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] vals = {
                { 1, 0, 0, 0, 0, 9, 5, 0, 7 },
                { 0, 0, 0, 0, 4, 0, 0, 0, 0 },
                { 7, 0, 8, 0, 0, 0, 0, 0, 2 },
                { 2, 0 ,3, 0, 7, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 3, 0, 0, 4, 0 },
                { 0, 0, 0, 0, 9, 0, 7, 0, 1 },
                { 3, 0, 0, 0, 0, 0, 6, 0, 8 },
                { 0, 0, 0, 0, 2, 0, 0, 0, 0 },
                { 5, 0, 2, 6, 0, 0, 0, 0, 3 }
            };

            SudokuBoard board = new SudokuBoard(vals);

            Solve(board);
        }

        static bool Solve( SudokuBoard board)
        {
            //1. Find the square with the fewest choices.
            //2. If the number of choices is 0, we have to stop (we made
            //      a bad guess earlier
            //3. If the number of choices is 1, obviously we just pick it
            //4. If the number of choise is >1, we'll loop through each possibility
            //      and try it recursively


            int minChoiceRow = -1;
            int minChoiceCol = -1;
            int minChoiceCount = int.MaxValue;



            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (   board.AllowableVals[row, col] != null
                        && board.AllowableVals[row, col].Count < minChoiceCount)
                    {
                        minChoiceCount = board.AllowableVals[row, col].Count;
                        minChoiceRow = row;
                        minChoiceCol = col;
                    }
                }
            }


            bool success = false;
            if( minChoiceCount > 0)
            {
                foreach( var allowableVal in board.AllowableVals[minChoiceRow, minChoiceCol])
                {
                    //1. try the value
                    board.SetValue(minChoiceRow, minChoiceCol, allowableVal);

                    //check for success???
                    success = board.IsComplete;

                    //2. recurse
                    if (success)
                    {
                        //if we're successful here, that means we just filled in
                        //the last square

                        PrintBoard(board)
;                    }
                    else
                    {
                        success = Solve(board);
                        //if we're successful after this line, that means somewhere
                        ///down the line finished
                        //aka, we just guessed correctly and verified it works
                    }


                    //maybe don't need because we just iterate to the next possible value
                    //3. back out our change and continue
                    if (!success)
                    {
                        board.SetValue(minChoiceRow, minChoiceCol, 0);
                    }
                    else break;
                }
            }

            return success;

            //board.SetValue(row, col, board.AllowableVals[row, col][0]);
        }

        private static void PrintBoard(SudokuBoard board)
        {
            for( int row = 0; row < 9; row++)
            {
                if( row % 3 == 0)
                {
                    Console.WriteLine("-----------");
                }
                for( int col = 0; col < 9; col++)
                {
                    if( col %3 == 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(board.Vals[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
