namespace SudokuSolver.Helpers.Logger;
public interface ILogger
{
    void Log(string message);

    void Warning(string message);

    void Error(string message);
}
