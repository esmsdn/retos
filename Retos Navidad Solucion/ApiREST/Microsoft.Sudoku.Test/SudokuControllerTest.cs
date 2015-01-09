using System;
using Microsoft.Sudoku.Web.Controllers;
using Microsoft.Sudoku.Web.SudokuEngines;
using Microsoft.Sudoku.Web.SudokuEngines.GoldeMan;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Microsoft.Sudoku.Test
{
    [TestClass]
    public class SudokuControllerTest
    {
        [TestMethod]
        public void IsValidGameTest()
        {
            SudokuController controller = new SudokuController(new GoldenManSudokuGame());
            int[,] sudoku = new int[9, 9];
            sudoku[0, 0] = 0; sudoku[0, 1] = 0; sudoku[0, 2] = 0; sudoku[0, 3] = 0; sudoku[0, 4] = 0; sudoku[0, 5] = 0; sudoku[0, 6] = 0; sudoku[0, 7] = 0; sudoku[0, 8] = 0;
            sudoku[1, 0] = 0; sudoku[1, 1] = 0; sudoku[1, 2] = 0; sudoku[1, 3] = 0; sudoku[1, 4] = 0; sudoku[1, 5] = 0; sudoku[1, 6] = 0; sudoku[1, 7] = 0; sudoku[1, 8] = 0;
            sudoku[2, 0] = 0; sudoku[2, 1] = 0; sudoku[2, 2] = 0; sudoku[2, 3] = 0; sudoku[2, 4] = 0; sudoku[2, 5] = 0; sudoku[2, 6] = 0; sudoku[2, 7] = 0; sudoku[2, 8] = 0;
            sudoku[3, 0] = 0; sudoku[3, 1] = 0; sudoku[3, 2] = 0; sudoku[3, 3] = 0; sudoku[3, 4] = 0; sudoku[3, 5] = 0; sudoku[3, 6] = 0; sudoku[3, 7] = 0; sudoku[3, 8] = 0;
            sudoku[4, 0] = 0; sudoku[4, 1] = 0; sudoku[4, 2] = 0; sudoku[4, 3] = 0; sudoku[4, 4] = 0; sudoku[4, 5] = 0; sudoku[4, 6] = 0; sudoku[4, 7] = 0; sudoku[4, 8] = 0;
            sudoku[5, 0] = 0; sudoku[5, 1] = 0; sudoku[5, 2] = 0; sudoku[5, 3] = 0; sudoku[5, 4] = 0; sudoku[5, 5] = 0; sudoku[5, 6] = 0; sudoku[5, 7] = 0; sudoku[5, 8] = 0;
            sudoku[6, 0] = 0; sudoku[6, 1] = 0; sudoku[6, 2] = 0; sudoku[6, 3] = 0; sudoku[6, 4] = 0; sudoku[6, 5] = 0; sudoku[6, 6] = 0; sudoku[6, 7] = 0; sudoku[6, 8] = 0;
            sudoku[7, 0] = 0; sudoku[7, 1] = 0; sudoku[7, 2] = 0; sudoku[7, 3] = 0; sudoku[7, 4] = 0; sudoku[7, 5] = 0; sudoku[7, 6] = 0; sudoku[7, 7] = 0; sudoku[7, 8] = 0;
            sudoku[8, 0] = 0; sudoku[8, 1] = 0; sudoku[8, 2] = 0; sudoku[8, 3] = 0; sudoku[8, 4] = 0; sudoku[8, 5] = 0; sudoku[8, 6] = 0; sudoku[8, 7] = 0; sudoku[8, 8] = 0;

            bool isValid = controller.IsValidGame(new Board() { Values = sudoku });
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void SolveSudokuTest()
        {
            SudokuController controller = new SudokuController(new GoldenManSudokuGame());
            int[,] sudoku = new int[9, 9];
            sudoku[0, 0] = 0; sudoku[0, 1] = 0; sudoku[0, 2] = 0; sudoku[0, 3] = 0; sudoku[0, 4] = 0; sudoku[0, 5] = 0; sudoku[0, 6] = 0; sudoku[0, 7] = 0; sudoku[0, 8] = 0;
            sudoku[1, 0] = 0; sudoku[1, 1] = 0; sudoku[1, 2] = 0; sudoku[1, 3] = 0; sudoku[1, 4] = 0; sudoku[1, 5] = 0; sudoku[1, 6] = 0; sudoku[1, 7] = 0; sudoku[1, 8] = 0;
            sudoku[2, 0] = 0; sudoku[2, 1] = 0; sudoku[2, 2] = 0; sudoku[2, 3] = 0; sudoku[2, 4] = 0; sudoku[2, 5] = 0; sudoku[2, 6] = 0; sudoku[2, 7] = 0; sudoku[2, 8] = 0;
            sudoku[3, 0] = 0; sudoku[3, 1] = 0; sudoku[3, 2] = 0; sudoku[3, 3] = 0; sudoku[3, 4] = 0; sudoku[3, 5] = 0; sudoku[3, 6] = 0; sudoku[3, 7] = 0; sudoku[3, 8] = 0;
            sudoku[4, 0] = 0; sudoku[4, 1] = 0; sudoku[4, 2] = 0; sudoku[4, 3] = 0; sudoku[4, 4] = 0; sudoku[4, 5] = 0; sudoku[4, 6] = 0; sudoku[4, 7] = 0; sudoku[4, 8] = 0;
            sudoku[5, 0] = 0; sudoku[5, 1] = 0; sudoku[5, 2] = 0; sudoku[5, 3] = 0; sudoku[5, 4] = 0; sudoku[5, 5] = 0; sudoku[5, 6] = 0; sudoku[5, 7] = 0; sudoku[5, 8] = 0;
            sudoku[6, 0] = 0; sudoku[6, 1] = 0; sudoku[6, 2] = 0; sudoku[6, 3] = 0; sudoku[6, 4] = 0; sudoku[6, 5] = 0; sudoku[6, 6] = 0; sudoku[6, 7] = 0; sudoku[6, 8] = 0;
            sudoku[7, 0] = 0; sudoku[7, 1] = 0; sudoku[7, 2] = 0; sudoku[7, 3] = 0; sudoku[7, 4] = 0; sudoku[7, 5] = 0; sudoku[7, 6] = 0; sudoku[7, 7] = 0; sudoku[7, 8] = 0;
            sudoku[8, 0] = 0; sudoku[8, 1] = 0; sudoku[8, 2] = 0; sudoku[8, 3] = 0; sudoku[8, 4] = 0; sudoku[8, 5] = 0; sudoku[8, 6] = 0; sudoku[8, 7] = 0; sudoku[8, 8] = 0;

            bool isValid = controller.IsValidGame(new Board() { Values = sudoku });
            Assert.IsTrue(isValid);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void SolveQuiqueSudokuTest()
        {
            SudokuController controller = new SudokuController(new GoldenManSudokuGame());
            string value = "[[3,7,8,1,4,9,5,2,6],[1,4,5,8,6,2,3,9,7],[6,2,9,7,5,3,1,4,8],[8,3,5,2,6,1,7,9,4],[9,2,1,4,7,3,6,5,8],[4,7,6,8,9,5,3,1,2],[9,8,3,6,1,7,4,5,2],[5,1,4,2,8,9,7,3,6],[2,6,7,5,3,4,9,8,1]]";
            bool isValid = controller.IsValidGame(new Board() { Values = JsonConvert.DeserializeObject<int[,]>(value) });
            Assert.IsTrue(isValid);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void IsValidQuiqueSudokuTest()
        {
            SudokuController controller = new SudokuController(new GoldenManSudokuGame());
            string value = "[[3,7,8,1,4,9,5,2,6],[1,4,5,8,6,2,3,9,7],[6,2,9,7,5,3,1,4,8],[8,3,5,2,6,1,7,9,4],[9,2,1,4,7,3,6,5,8],[4,7,6,8,9,5,3,1,2],[9,8,3,6,1,7,4,5,2],[5,1,4,2,8,9,7,3,6],[2,6,7,5,3,4,9,8,1]]";
            bool isValid = controller.IsValidGame(new Board() { Values = JsonConvert.DeserializeObject<int[,]>(value) });
            Assert.IsTrue(isValid);
        }
    }
}
