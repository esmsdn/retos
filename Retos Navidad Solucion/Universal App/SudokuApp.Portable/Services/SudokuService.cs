namespace SudokuApp.Portable.Services
{
    using Models;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// El servicio con el que nos conectamos a la API REST de Sudokus que hemos creado en el reto anterior
    /// </summary>
    public class SudokuService
    {
        /// <summary>
        /// Hace una petición a la API https://microsoftsudokuweb.azurewebsites.net/api/sudoku/isvalidgame 
        /// El tipo de petición es POST y este es un ejemplo de cuerpo de la petición:
        /// {"Values":[[3,7,8,1,4,9,5,2,6],[1,4,5,8,6,2,3,9,7],[6,2,9,7,5,3,1,4,8],[8,3,5,2,6,1,7,9,4],[9,2,1,4,7,3,6,5,8],[4,7,6,8,9,5,3,1,2],[9,8,3,6,1,7,4,5,2],[5,1,4,2,8,9,7,3,6],[2,6,7,5,3,4,9,8,1]]}
        /// </summary>
        /// <param name="cells">Las celdas que forman parte del tablero de juego</param>
        /// <returns>'True' si todas las celdas son válidas; 'False' si alguna no lo es; 'null' si no lo hemos podido determinar (p.ej. no hay conexión con el servidor)</returns>
        public async Task<bool?> IsValidGameAsync(Cell[][] cells)
        {
            var board = new { Values = new int[9, 9] };
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    Cell cell = cells[row][column];
                    board.Values[row, column] = cell.Digit.HasValue ? cell.Digit.Value : 0;
                }
            }

            string response = await ExecutePostRequestAsync("https://microsoftsudokuweb.azurewebsites.net/api/sudoku/isvalidgame ", board);
            switch (response)
            {
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Ejecuta una petición POST a un servidor. El cuerpo de la petición es un Json
        /// </summary>
        /// <param name="requestUriString">La URI de la petición</param>
        /// <param name="requestBody">El cuerpo de la petición</param>
        /// <returns>La respuesta de la petición</returns>
        private async Task<string> ExecutePostRequestAsync(string requestUriString, object requestBody)
        {
            string result = null;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUriString);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string serializedObject = JsonConvert.SerializeObject(requestBody);
                request.Content = new StringContent(serializedObject);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }

            return result;
        }
    }
}
