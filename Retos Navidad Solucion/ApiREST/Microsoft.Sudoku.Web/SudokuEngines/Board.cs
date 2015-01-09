namespace Microsoft.Sudoku.Web.SudokuEngines
{
    public class Board : IBoard
    {
        public int[,] Values
        {
            get;
            set;
        }
    }
}