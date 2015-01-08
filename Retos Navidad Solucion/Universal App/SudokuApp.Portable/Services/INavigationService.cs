namespace SudokuApp.Portable.Services
{
    /// <summary>
    /// El servicio de navegación que necesitan los vista-modelo de esta librería tiene que implementar este interfaz.
    /// Con este servicio los vista-modelo podrán navegar a las vistas asociadas a otros vista-modelo.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navega a la vista asociada a un vista-modelo
        /// </summary>
        /// <typeparam name="TDestinationViewModel">Tipo del vista-modelo asociado a la vista a la que se quiere navegar</typeparam>
        /// <param name="navigationContext">Parámetros a pasar a la vista y a su vista-modelo</param>
        void NavigateTo<TDestinationViewModel>(object navigationContext = null);

        /// <summary>
        /// Navega a la vista anterior
        /// </summary>
        void NavigateBack();
    }
}
