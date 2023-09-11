using SudokuSolver.Domain.Models;

namespace SudokuSolver.BLL;
public interface ISolver
{
    BoardModel Solve(int[,] boardArray);
}
