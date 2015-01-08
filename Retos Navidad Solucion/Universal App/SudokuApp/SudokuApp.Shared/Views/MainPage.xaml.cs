namespace SudokuApp.Views
{
    using Base;
    using Portable.Models;
    using Portable.Services;
    using System;
    using Windows.UI;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// La vista de la página principal
    /// </summary>
    public sealed partial class MainPage : BasePage
    {
        private MessagingService messagingService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MainPage"/>
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

#if WINDOWS_PHONE_APP
            var statusBar = StatusBar.GetForCurrentView();
            statusBar.BackgroundColor = (Color)Application.Current.Resources["BrandColor"];
            statusBar.BackgroundOpacity = 1;
            statusBar.ForegroundColor = (Color)Application.Current.Resources["BrandForegroundColor"];
            var ignoreResult = statusBar.ShowAsync();
            var progressIndicator = statusBar.ProgressIndicator;
            progressIndicator.Text = "SUDOKU";
            progressIndicator.ProgressValue = 0;
            ignoreResult = progressIndicator.ShowAsync();
#endif

            messagingService = (Application.Current.Resources["Locator"] as ServiceLocator).MessagingService;
        }

        /// <summary>
        /// Acabamos de llegar a la página
        /// </summary>
        /// <param name="e">Los argumentos del evento de navegación</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            messagingService.Register(this, typeof(GameStatusMessage), new Action<object>(ShowGameStatusToUser));

            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Nos vamos de la página
        /// </summary>
        /// <param name="e">Los argumentos del evento de navegación</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            messagingService.Unregister(this, typeof(GameStatusMessage), new Action<object>(ShowGameStatusToUser));
        }

        /// <summary>
        /// Muestra al usuario el mensaje de estado de juego recibido del vista-modelo
        /// </summary>
        /// <param name="messageObject"></param>
        private void ShowGameStatusToUser(object messageObject)
        {
            switch ((messageObject as GameStatusMessage).Status)
            {
                case GameStatus.New:
                    StatusMessage.Text = "";
                    break;
                case GameStatus.Checking:
                    StatusMessage.Text = "Comprobando el tablero...";
                    break;
                case GameStatus.Valid:
                    StatusMessage.Text = "¡¡¡Todas las celdas son correctas!!!";
                    break;
                case GameStatus.Invalid:
                    StatusMessage.Text = "¡¡¡Una o más celdas son incorrectas!!!";
                    break;
                case GameStatus.ServerError:
                    StatusMessage.Text = "No se ha podido contactar con el servidor";
                    break;
            }
        }

        /// <summary>
        /// Impide que se puedan introducir dígitos inválidos (que no estén entre 1 y 9) en las celdas del tablero
        /// </summary>
        /// <param name="sender">El campo de texto en el que se introduce el dígito</param>
        /// <param name="e">Este parámetro es ignorado</param>
        private void OnTextBoxChanged(object sender, Windows.UI.Xaml.Controls.TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            int result;
            if (string.IsNullOrWhiteSpace(text) || !int.TryParse(text, out result) || (result < 1) || (result > 9))
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
