namespace Microsoft.Sudoku.Web.SudokuEngines
{
    public interface IBoard
    {
        int[,] Values { get; set; }
    }
}