namespace Microsoft.Sudoku.Web.Controllers
{
    using System;
    using System.Web.Http;
    using Microsoft.Sudoku.Web.SudokuEngines;

    public class SudokuController : ApiController
    {
        private ISudokuGame sudokuEngine;

        public SudokuController(ISudokuGame value)
        {
            sudokuEngine = value;
        }

        [HttpPost]
        public bool IsValidGame(Board body)
        {
            bool result = false;
            try
            {
                result = sudokuEngine.IsValidGame(body);
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
