using SudokuSolver.BLL;
using SudokuSolver.Domain.Helpers;
using SudokuSolver.Helpers.Logger;

namespace ConsoleTest;

internal class Program
{
    static void Main(string[] args)
    {
        var board = new int[9, 9]
        {
            { 9,5,7,0,1,3,2,8,0 },
            { 0,8,3,0,5,7,1,0,0 },
            { 6,1,2,0,4,9,5,3,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0 },
        };

        var solver = new Solver(new ILogger[] { new ConsoleLogger() }) as ISolver;

        solver.Solve(board);

        var a = 1;
    }
}
