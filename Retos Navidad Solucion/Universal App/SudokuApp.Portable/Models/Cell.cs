namespace SudokuApp.Portable.Models
{
    using ViewModels.Base;

    /// <summary>
    /// Una celda del tablero
    /// </summary>
    public class Cell : ObservableObject
    {
        private int? digit = null;

        /// <summary>
        /// El dígito de la celda. Los digitos válidos van del 1 al 9 
        /// </summary>
        public int? Digit
        {
            get { return digit; }

            set
            {
                if (NotFixed)
                {
                    if ((value != null) && (value < 1 || value > 9))
                    {
                        value = null;
                    }
                    SetProperty(ref digit, value);
                }
            }
        }

        private bool notFixed = true;

        /// <summary>
        /// ¿Es una celda fija (parte del tablero inicial de juego) o no lo es? 
        /// </summary>
        public bool NotFixed { get { return notFixed; } set { SetProperty(ref notFixed, value); } }
    }
}
