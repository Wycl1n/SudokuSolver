using SudokuSolver.Domain.Helpers;

namespace SudokuSolver.Domain.Models;
public class BoardModel
{
    public int[,] BoardArray { get; set; }

    public BoardModel(int[,] board)
    {
        if (!BoardHelper.ThrowErrorIfUnsolvable(board))
            throw new Exception();

        BoardArray = board.Clone() as int[,];
    }
}
