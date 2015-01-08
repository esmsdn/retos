namespace SudokuApp.Portable.Models
{
    /// <summary>
    /// Estado del juego
    /// </summary>
    public enum GameStatus
    {
        New,        // Se inicia un nuevo juego
        Checking,   // Se está comprobando el estado del tablero con el servidor
        Valid,      // Las celdas del tablero son correctas
        Invalid,    // Alguna celda del tablero no es correcta
        ServerError // No hemos podido determinar el estado del tablero
    }

    /// <summary>
    /// Mensajes con el estado de juego enviados desde los vista-modelo a las vistas. Usados con <see cref="MessagingService"/>
    /// </summary>
    public class GameStatusMessage
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameStatusMessage"/>
        /// </summary>
        /// <param name="status">El estado del juego</param>
        public GameStatusMessage(GameStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// El estado del juego
        /// </summary>
        public GameStatus Status { get; set; }
    }
}
