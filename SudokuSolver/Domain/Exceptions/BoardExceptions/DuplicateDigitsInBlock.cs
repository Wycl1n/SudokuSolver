using SudokuSolver.Domain.Enum;

namespace SudokuSolver.Domain.Exceptions.BoardExceptions;
public class DuplicateDigitsInBlock: BaseBoardException
{
    public static string MessageFormat => "Duplicate occupied in block: {0} #{1}";

    public BlockTypeEnum ErrorBlock { get; set; }
    public int BlockNumber { get; set; }

    public DuplicateDigitsInBlock(BlockTypeEnum errorBlock, int blockNumber, int[,] board)
        : base(string.Format(MessageFormat, errorBlock, blockNumber), board)
    {
        ErrorBlock = errorBlock;
        BlockNumber = blockNumber;
    }
}
