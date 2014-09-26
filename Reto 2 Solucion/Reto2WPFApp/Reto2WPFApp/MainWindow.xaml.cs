using Reto2ClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace Reto2WPFApp
{
    /// <summary>
    /// Ventana para probar la librería del Reto 2
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Cada botón del interfaz se corresponderá con uno de estos items
        /// </summary>
        private Item[] items;

        /// <summary>
        /// Objecto de la clase a implementar en el reto
        /// </summary>
        private Reto2 reto2;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            items = new Item[6] 
            { 
                new Item() { Index = 1 },
                new Item() { Index = 2 },
                new Item() { Index = 3 }, 
                new Item() { Index = 4 },
                new Item() { Index = 5 },
                new Item() { Index = 6 }
            };

            reto2 = new Reto2();

            InitializeComponent();
        }

        /// <summary>
        /// Se ha pulsado uno de los botones "Botón 1"..."Botón 6" 
        /// Subscribimos el manejador de eventos de su item correspondiente al evento del reto
        /// </summary>
        /// <param name="sender">Botón pulsado</param>
        /// <param name="e">No es utilizado</param>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            switch (button.Name as string)
            {
                case "Button1":
                    reto2.EventFired += items[0].OnEvent;
                    button.IsEnabled = false;
                    break;
                case "Button2":
                    reto2.EventFired += items[1].OnEvent;
                    button.IsEnabled = false;
                    break;
                case "Button3":
                    reto2.EventFired += items[2].OnEvent;
                    button.IsEnabled = false;
                    break;
                case "Button4":
                    reto2.EventFired += items[3].OnEvent;
                    button.IsEnabled = false;
                    break;
                case "Button5":
                    reto2.EventFired += items[4].OnEvent;
                    button.IsEnabled = false;
                    break;
                case "Button6":
                    reto2.EventFired += items[5].OnEvent;
                    button.IsEnabled = false;
                    break;
            }

            this.ExecuteButton.IsEnabled = !this.Button1.IsEnabled && !this.Button2.IsEnabled && !this.Button3.IsEnabled && !this.Button4.IsEnabled && !this.Button5.IsEnabled && !this.Button6.IsEnabled;
        }

        /// <summary>
        /// Se ha pulsado el botón "Ejecuta".
        /// Se llama al método que lanza el evento del reto. En la Consola de Visual Studio deberíamos 
        /// de ver cómo los manejadores de eventos suscritos se ejecutan en el orden definido por el 
        /// índice del item correspondiente, independientemente del orden en el que se hayan suscrito al evento.
        /// Luego lo dejamos todo como estaba.
        /// </summary>
        /// <param name="sender">No es utilizado</param>
        /// <param name="e">No es utilizado</param>
        private void OnExecuteClick(object sender, RoutedEventArgs e)
        {
            this.reto2.FireEvent();

            foreach (Item item in items)
            {
                reto2.EventFired -= item.OnEvent;
            }

            this.Button1.IsEnabled = this.Button2.IsEnabled = this.Button3.IsEnabled = this.Button4.IsEnabled = this.Button5.IsEnabled = this.Button6.IsEnabled = true;
            this.ExecuteButton.IsEnabled = false;
        }
    }
}
