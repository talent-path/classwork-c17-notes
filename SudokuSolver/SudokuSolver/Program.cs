using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] vals = {
                { 0, 5, 0, 3, 4, 7, 1, 9, 0 },
                { 0, 0, 7, 0, 0, 0, 0, 6, 0 },
                { 2, 9, 0, 8, 6, 0, 7, 5, 0 },
                { 4, 0 ,0, 0, 0, 6, 0, 3, 0 },
                { 0, 0, 0, 1, 9, 4, 0, 0, 0 },
                { 0, 6, 0, 2, 0, 0, 0, 0, 5 },
                { 0, 2, 5, 0, 1, 0, 0, 4, 9 },
                { 0, 1, 0, 0, 0, 0, 2, 0, 0 },
                { 0, 4, 9, 6, 3, 2, 0, 1, 0 }
            };

            SudokuBoard board = new SudokuBoard(vals);

            bool changedVal = false;
            for( int row = 0; !changedVal && row < 9; row++)
            {
                for( int col = 0; !changedVal && col < 9; col++)
                {
                    if(board.AllowableVals[row, col] != null && board.AllowableVals[row, col].Count == 1)
                    {
                        board.SetValue(row, col, board.AllowableVals[row, col][0]);
                        changedVal = true;
                    }
                }
            }

            Console.WriteLine("Hello World!");

            //I lied (mac version?)
            //Console.WriteLine("this shouldn't work except VS is great");
        }
    }
}
