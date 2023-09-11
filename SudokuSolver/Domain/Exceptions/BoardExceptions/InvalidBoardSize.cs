namespace SudokuSolver.Domain.Exceptions.BoardExceptions;
public class InvalidBoardSize: BaseBoardException
{
    public static string MessageFormat => "Board size is invalid";

    public InvalidBoardSize(int[,] board)
        : base(MessageFormat, board)
    { }
}
