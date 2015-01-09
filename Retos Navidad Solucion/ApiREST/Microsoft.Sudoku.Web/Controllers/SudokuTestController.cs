using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft.Sudoku.Web.Controllers
{
    public class SudokuTestController : Controller
    {
        // GET: SudokuTest
        public ActionResult Index()
        {
            return View();
        }
    }
}