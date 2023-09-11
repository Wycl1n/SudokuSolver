using LinqKit;
using SudokuSolver.Domain.Exceptions;
using SudokuSolver.Domain.Models;
using SudokuSolver.Helpers.Logger;
using System.Text;

namespace SudokuSolver.BLL;
public class Solver: ISolver
{
    private readonly IEnumerable<ILogger> _loggers;

    public Solver(IEnumerable<ILogger> loggers)
    {
        _loggers = loggers;
    }

    public BoardModel Solve(int[,] boardArray)
    {
        try
        {
            var board = new BoardModel(boardArray);
            return Solve(board);
        }
        catch (BaseException ex)
        {
            _loggers.ForEach(x => x.Error(ex.Message));
        }

        return null;
    }

    #region Helpers

    private BoardModel Solve(BoardModel board)
    {
        #region log

        _loggers.ForEach(x =>
        {
            var boardBuilder = new StringBuilder();
            boardBuilder.AppendLine($"Started solving board: {DateTime.Now.ToString("yyyy.MM.dd: HH.mm.ss.fffffff")}");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardBuilder.Append((int)board.BoardArray[i, j]);

                    if (j < 8)
                        boardBuilder.Append(" | ");
                }
                boardBuilder.AppendLine();
            }

            x.Log(boardBuilder.ToString());
        });

        #endregion

        var insertDone = false;
        do
        {
            insertDone = false;
            var counter = new int[9];

            // Insert By Column
            for (int i = 0; i < 9; i++)
            {
                counter = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (board.BoardArray[i, j] != 0)
                        counter[board.BoardArray[i, j] - 1]++;
                }

                if (counter.Count(x => x == 1) == 8)
                {
                    var valueToInsert = Array.IndexOf(counter, 0) + 1;
                    for (int j = 0; j < 9; j++)
                    {
                        if (board.BoardArray[i, j] == 0)
                        {
                            #region log

                            FoundElementLog(i, j, valueToInsert);

                            #endregion

                            board.BoardArray[i, j] = valueToInsert;
                            insertDone = true;
                        }
                    }
                }
            }

            // Insert By Row
            for (int j = 0; j < 9; j++)
            {
                counter = new int[9];
                for (int i = 0; i < 9; i++)
                {
                    if (board.BoardArray[i, j] != 0)
                        counter[board.BoardArray[i, j] - 1]++;
                }

                if (counter.Count(x => x == 1) == 8)
                {
                    var valueToInsert = Array.IndexOf(counter, 0) + 1;
                    for (int i = 0; i < 9; i++)
                    {
                        if (board.BoardArray[i, j] == 0)
                        {
                            #region log

                            FoundElementLog(i, j, valueToInsert);

                            #endregion

                            board.BoardArray[i, j] = valueToInsert;
                            insertDone = true;
                        }
                    }
                }
            }

            // Insert By Square
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    counter = new int[9];

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board.BoardArray[i + 3 * i1, j + 3 * j1] != 0)
                                counter[board.BoardArray[i + 3 * i1, j + 3 * j1] - 1]++;
                        }
                    }

                    if (counter.Count(x => x == 1) == 8)
                    {
                        var valueToInsert = Array.IndexOf(counter, 0) + 1;
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (board.BoardArray[i + 3 * i1, j + 3 * j1] == 0)
                                {
                                    #region log

                                    FoundElementLog(i + 3 * i1, j + 3 * j1, valueToInsert);

                                    #endregion

                                    board.BoardArray[i + 3 * i1, j + 3 * j1] = valueToInsert;
                                    insertDone = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        while (insertDone);

        //TODO: bruteforce yetogo govna

        #region log

        _loggers.ForEach(x =>
        {
            var boardBuilder = new StringBuilder();
            boardBuilder.AppendLine($"Ended solving board: {DateTime.Now.ToString("yyyy.MM.dd: HH.mm.ss.fffffff")}");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    boardBuilder.Append(board.BoardArray[i, j]);

                    if (j < 8)
                        boardBuilder.Append(" | ");
                }
                boardBuilder.AppendLine();
            }

            x.Log(boardBuilder.ToString());
        });

        #endregion

        return board;
    }

    private void FoundElementLog(int i, int j, int value)
    {
        _loggers.ForEach(x => x.Log($"Found element to insert into Column #{i + 1} Row #{j + 1} Element {value}"));
    }

    #endregion
}
