namespace SudokuApp.Portable.ViewModels
{
    using Base;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System.Windows.Input;

    /// <summary>
    /// El vista-modelo de la página principal
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private Cell[][] cells;

        /// <summary>
        /// Las celdas que forman parte del tablero de juego.
        /// Nota: No lo he declarado como Cell[,] porque no se puede hacer un data binding a sus elementos. Sólo funciona con Cell[][]
        /// </summary>
        public Cell[][] Cells { get { return cells; } }

        private bool playingGame;

        /// <summary>
        /// ¿Estamos jugando al juego o definiendo el tablero inicial?
        /// </summary>
        private bool PlayingGame
        {
            get { return playingGame; }

            set
            {
                playingGame = value;
                NewGameCommand.RaiseCanExecuteChanged();
                PlayGameCommand.RaiseCanExecuteChanged();
                VerifyValidGameCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// ¿Está pensando "la máquina"?
        /// </summary>
        private bool thinking;
        private bool Thinking
        {
            get { return thinking; }

            set
            {
                thinking = value;
                NewGameCommand.RaiseCanExecuteChanged();
                PlayGameCommand.RaiseCanExecuteChanged();
                VerifyValidGameCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Ejecutar para empezar un nuevo tablero de juego
        /// </summary>
        public RelayCommand NewGameCommand { get; private set; }

        /// <summary>
        /// Ejecutar para empezar a jugar al tablero creado
        /// </summary>
        public RelayCommand PlayGameCommand { get; private set; }

        /// <summary>
        /// Ejecutar para verificar que todas las celdas del tablero son correctas
        /// </summary>
        public RelayCommand VerifyValidGameCommand { get; private set; }

        /// <summary>
        /// Ejecutar para mostrar la ayuda
        /// </summary>
        public ICommand ShowHelpCommand { get; private set; }

        private INavigationService navigationService;
        private SudokuService sudokuService;
        private MessagingService messagingService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MainViewModel"/>
        /// </summary>
        /// <param name="navigationService">El servicio de navegación</param>
        /// <param name="sudokuService">El servicio de la API REST de Sudokus</param>
        /// <param name="messagingService">El servicio de mensajería</param>
        public MainViewModel(
            INavigationService navigationService,
            SudokuService sudokuService,
            MessagingService messagingService)
        {
            this.navigationService = navigationService;
            this.sudokuService = sudokuService;
            this.messagingService = messagingService;

            NewGameCommand = new RelayCommand(NewGame, () => PlayingGame && !Thinking);
            PlayGameCommand = new RelayCommand(PlayGame, () => !PlayingGame && !Thinking);
            VerifyValidGameCommand = new RelayCommand(VerifyValidGame, () => PlayingGame && !Thinking);
            ShowHelpCommand = new RelayCommand(ShowHelp);

            cells = new Cell[9][];
            for (int row = 0; row < 9; row++)
            {
                cells[row] = new Cell[9];
                for (int column = 0; column < 9; column++)
                {
                    cells[row][column] = new Cell();
                }
            }
        }

        /// <summary>
        /// Empieza un nuevo tablero de juego
        /// </summary>
        private void NewGame()
        {
            Thinking = true;

            messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.New));

            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    Cell cell = cells[row][column];
                    cell.NotFixed = true;
                    cell.Digit = null;
                }
            }

            PlayingGame = false;
            Thinking = false;
        }

        /// <summary>
        /// Empieza a jugar al tablero creado
        /// </summary>
        private async void PlayGame()
        {
            Thinking = true;

            messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.Checking));

            bool? isValid = await this.sudokuService.IsValidGameAsync(cells);
            if (!isValid.HasValue)
            {
                messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.ServerError));
            }
            else if (isValid.Value)
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int column = 0; column < 9; column++)
                    {
                        Cell cell = cells[row][column];
                        cell.NotFixed = cell.Digit == null;
                    }
                }

                PlayingGame = true;

                messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.Valid));
            }
            else
            {
                messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.Invalid));
            }

            Thinking = false;
        }

        /// <summary>
        /// Verfica que todas las celdas del tablero son correctas
        /// </summary>
        private async void VerifyValidGame()
        {
            Thinking = true;

            messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.Checking));

            bool? isValid = await this.sudokuService.IsValidGameAsync(cells);
            if (!isValid.HasValue)
            {
                messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(GameStatus.ServerError));
            }
            else
            {
                messagingService.Send(typeof(GameStatusMessage), new GameStatusMessage(isValid.Value ? GameStatus.Valid : GameStatus.Invalid));
            }

            Thinking = false;
        }

        /// <summary>
        /// Muestra la ayuda
        /// </summary>
        private void ShowHelp()
        {
            navigationService.NavigateTo<HelpViewModel>();
        }
    }
}
