using SudokuSolver.Domain.Enum;
using SudokuSolver.Domain.Exceptions.BoardExceptions;
using SudokuSolver.Domain.Helpers;

namespace UnitTests;
internal class BoardTests
{
    [Test]
    public void TestBoardValidation_InvalidRowsSize_ThrowsError()
    {
        var board = new int[9, 8];
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<InvalidBoardSize>();
    }

    [Test]
    public void TestBoardValidation_InvalidColumnsSize_ThrowsError()
    {
        var board = new int[8, 9];
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<InvalidBoardSize>();
    }

    [Test]
    public void TestBoardValidation_InvalidSize_ThrowsError()
    {
        var board = new int[8, 8];
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<InvalidBoardSize>();
    }

    [Test]
    public void TestBoardValidation_DuplicateInColumn1_ThrowsError()
    {
        var board = new int[9, 9]
        {
            { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<DuplicateDigitsInBlock>()
            .WithMessage(string.Format(DuplicateDigitsInBlock.MessageFormat, BlockTypeEnum.Column, 1));
    }

    [Test]
    public void TestBoardValidation_DuplicateInColumn3_ThrowsError()
    {
        var board = new int[9, 9]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<DuplicateDigitsInBlock>()
            .WithMessage(string.Format(DuplicateDigitsInBlock.MessageFormat, BlockTypeEnum.Column, 3));
    }

    [Test]
    public void TestBoardValidation_DuplicateInRow1_ThrowsError()
    {
        var board = new int[9, 9]
        {
            { 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<DuplicateDigitsInBlock>()
            .WithMessage(string.Format(DuplicateDigitsInBlock.MessageFormat, BlockTypeEnum.Row, 1));
    }

    [Test]
    public void TestBoardValidation_DuplicateInRow3_ThrowsError()
    {
        var board = new int[9, 9]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<DuplicateDigitsInBlock>()
            .WithMessage(string.Format(DuplicateDigitsInBlock.MessageFormat, BlockTypeEnum.Row, 3));
    }


    [Test]
    public void TestBoardValidation_Square1Duplicate_ThrowsError()
    {
        var board = new int[9, 9]
        {
            { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .Throw<DuplicateDigitsInBlock>()
            .WithMessage(string.Format(DuplicateDigitsInBlock.MessageFormat, BlockTypeEnum.Square, 1));
    }

    [Test]
    public void TestBoardValidation_Success()
    {
        var board = new int[9, 9]
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
        var act = () => BoardHelper.ThrowErrorIfUnsolvable(board);

        act.Should()
            .NotThrow<DuplicateDigitsInBlock>();
    }
}
