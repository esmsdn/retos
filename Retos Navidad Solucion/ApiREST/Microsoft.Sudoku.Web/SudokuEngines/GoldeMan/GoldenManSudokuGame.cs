namespace Microsoft.Sudoku.Web.SudokuEngines.GoldeMan
{
    using Golden.Man.Sudoku.Solver;

    public class GoldenManSudokuGame : ISudokuGame
    {
        public bool IsValidGame(IBoard board)
        {
            return SudokuSolver.Solve(board.Values);
        }
    }
}