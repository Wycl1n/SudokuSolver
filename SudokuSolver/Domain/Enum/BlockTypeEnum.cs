namespace SudokuSolver.Domain.Enum;
public enum BlockTypeEnum
{
    Undefined = 0,

    Column = 1,
    Row = 2,
    Square = 3,
}

/*
 * [column, rows]
 * Columns are first digit in index 
 * Rows are second digit in index 
 * 
 * Squares are numerated next:
 * 1, 2, 3
 * 4, 5, 6
 * 7, 8, 9
 */
