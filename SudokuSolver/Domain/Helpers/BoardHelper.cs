using SudokuSolver.Domain.Enum;
using SudokuSolver.Domain.Exceptions.BoardExceptions;

namespace SudokuSolver.Domain.Helpers;
public static class BoardHelper
{
    public static bool ThrowErrorIfUnsolvable(int[,] board)
    {
        if (board.GetLength(0) != 9 || board.GetLength(1) != 9)
            throw new InvalidBoardSize(board);

        var counter = new int[9];
        for (int i = 0; i < 9; i++)
        {
            //Check for row duplicate
            counter = new int[9];
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] != 0)
                    counter[board[i, j] - 1]++;
            }

            if (counter.Any(x => x > 1))
                throw new DuplicateDigitsInBlock(BlockTypeEnum.Row, i + 1, board);

            //Check for column duplicate
            counter = new int[9];
            for (int j = 0; j < 9; j++)
            {
                if (board[j, i] != 0)
                    counter[board[j, i] - 1]++;
            }

            if (counter.Any(x => x > 1))
                throw new DuplicateDigitsInBlock(BlockTypeEnum.Column, i + 1, board);
        }

        //Check for square duplicate
        for (int i1 = 0; i1 < 3; i1++)
        {
            for (int j1 = 0; j1 < 3; j1++)
            {
                counter = new int[9];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i + 3 * i1, j + 3 * j1] != 0)
                            counter[board[i + 3 * i1, j + 3 * j1] - 1]++;
                    }
                }

                if (counter.Any(x => x > 1))
                    throw new DuplicateDigitsInBlock(BlockTypeEnum.Square, i1 * 3 + j1 + 1, board);
            }
        }

        return true;
    }
}
