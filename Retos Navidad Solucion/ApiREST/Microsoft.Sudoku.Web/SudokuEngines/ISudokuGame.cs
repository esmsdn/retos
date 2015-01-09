namespace Microsoft.Sudoku.Web.SudokuEngines
{
    public interface ISudokuGame
    {
        bool IsValidGame(IBoard board);
    }
}