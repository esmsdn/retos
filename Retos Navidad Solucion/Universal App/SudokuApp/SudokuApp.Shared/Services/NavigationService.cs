namespace SudokuApp.Services
{
    using Portable.Services;
    using Portable.ViewModels;
    using System;
    using System.Collections.Generic;
    using Views;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Con este servicio los vista-modelo navegarán a las vistas asociadas a otros vista-modelo.
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// Tabla que asocia cada vista-modelo con su vista correspondiente
        /// </summary>
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(MainViewModel), typeof(MainPage) },
            { typeof(HelpViewModel), typeof(HelpPage) }
        };

        /// <summary>
        /// Navega a la vista asociada a un vista-modelo
        /// </summary>
        /// <typeparam name="TDestinationViewModel">Tipo del vista-modelo asociado a la vista</typeparam>
        /// <param name="navigationContext">Parámetros a pasar al vista-modelo</param>
        public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(viewModelRouting[typeof(TDestinationViewModel)], navigationContext);
        }

        /// <summary>
        /// Navega a la vista anterior
        /// </summary>
        public void NavigateBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}