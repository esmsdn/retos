using Sudokuweb.Models;
using Sudokuweb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sudokuweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SudokuService sudokuService;

        public HomeController(SudokuService sudokuService) {
            this.sudokuService = sudokuService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IsValid(Sudoku sudoku)
        {
            var result = await this.sudokuService.IsValid(sudoku);
            return Json(result);
        }
    }
}