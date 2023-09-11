using SudokuSolver.BLL;
using SudokuSolver.Helpers.Logger;

namespace UnitTests;
public class SolverTests
{
    public Solver SolverInstance { get; set; }

    [SetUp]
    public void Setup()
    {
        SolverInstance = new(new ILogger[] { new ConsoleLogger() });
    }

    [TearDown]
    public void TearDown()
    {
        SolverInstance = null;
    }

    [Test]
    public void Solve_RowsAndColumnsInsertions_Success()
    {
        var board = new int[9, 9]
        {
            { 9, 5, 7, 6, 1, 3, 2, 8, 0 },
            { 0, 8, 3, 2, 5, 7, 1, 0, 6 },
            { 6, 0, 2, 8, 4, 9, 0, 3, 7 },
            { 1, 7, 0, 3, 6, 0, 9, 5, 2 },
            { 5, 2, 4, 9, 7, 1, 3, 6, 8 },
            { 3, 6, 9, 0, 2, 0, 7, 4, 1 },
            { 8, 4, 0, 7, 9, 2, 0, 1, 3 },
            { 2, 0, 1, 4, 3, 6, 8, 0, 5 },
            { 0, 3, 6, 1, 8, 5, 4, 2, 0 },
        };
        var solved = new int[9, 9]
        {
            { 9, 5, 7, 6, 1, 3, 2, 8, 4 },
            { 4, 8, 3, 2, 5, 7, 1, 9, 6 },
            { 6, 1, 2, 8, 4, 9, 5, 3, 7 },
            { 1, 7, 8, 3, 6, 4, 9, 5, 2 },
            { 5, 2, 4, 9, 7, 1, 3, 6, 8 },
            { 3, 6, 9, 5, 2, 8, 7, 4, 1 },
            { 8, 4, 5, 7, 9, 2, 6, 1, 3 },
            { 2, 9, 1, 4, 3, 6, 8, 7, 5 },
            { 7, 3, 6, 1, 8, 5, 4, 2, 9 },
        };

        var result = SolverInstance.Solve(board);

        AreArraysSame(result.BoardArray, solved)
            .Should()
            .BeTrue();
    }

    [Test]
    public void Solve_SquareInsertions_Success()
    {
        var board = new int[9, 9]
        {
            { 9, 5, 7, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 3, 0, 0, 0, 0, 0, 0 },
            { 6, 1, 2, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };

        var result = SolverInstance.Solve(board);

        result.BoardArray[0, 0]
            .Should()
            .Be(9);
        result.BoardArray[0, 1]
            .Should()
            .Be(5);
        result.BoardArray[0, 2]
            .Should()
            .Be(7);
        result.BoardArray[1, 0]
            .Should()
            .Be(4);
        result.BoardArray[1, 1]
            .Should()
            .Be(8);
        result.BoardArray[1, 2]
            .Should()
            .Be(3);
        result.BoardArray[2, 0]
            .Should()
            .Be(6);
        result.BoardArray[2, 1]
            .Should()
            .Be(1);
        result.BoardArray[2, 2]
            .Should()
            .Be(2);
    }

    [Test]
    public void Solve_InvalidInput_Error()
    {
        var board = new int[8, 8];
        var act = () => SolverInstance.Solve(board);

        act.Should()
            .NotThrow();
        SolverInstance.Solve(board)
            .Should()
            .BeNull();
    }

    #region Helpers

    private bool AreArraysSame(int[,] arr1, int[,] arr2)
    {
        if (arr1 == arr2)
            throw new Exception("Same link");

        if (arr1.GetLength(0) != arr2.GetLength(0)
            || arr1.GetLength(1) != arr2.GetLength(1))
        {
            return false;
        }

        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                if (arr1[i, j] != arr2[i, j]) 
                    return false;
            }
        }

        return true;
    }

    #endregion
}
