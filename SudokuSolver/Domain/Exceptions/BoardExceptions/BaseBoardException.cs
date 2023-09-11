namespace SudokuSolver.Domain.Exceptions.BoardExceptions;
public abstract class BaseBoardException: BaseException
{
    public int[,] Board { get; set; }

    protected BaseBoardException(string message, int[,] board)
        : base(message)
    {
        Board = board;
    }
}
