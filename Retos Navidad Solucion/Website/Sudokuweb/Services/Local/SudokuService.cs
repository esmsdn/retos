using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Services;
using Sudokuweb.Models;

namespace Sudokuweb.Services
{
    public class SudokuService
    {
        const string baseURL = "http://microsoftsudokuweb.azurewebsites.net/api/sudoku/";
        private readonly HttpService httpService;
        public SudokuService(HttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<bool> IsValid(Sudoku sudoku) 
        {
            var response = await httpService.PostAsync(baseURL + "IsValidGame", sudoku);

            return JsonConvert.DeserializeObject<bool>(response);
        }
    }
}