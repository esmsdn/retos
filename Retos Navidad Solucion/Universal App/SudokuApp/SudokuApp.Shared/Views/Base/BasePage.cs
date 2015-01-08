﻿namespace SudokuApp.Views.Base
{
    using Portable.ViewModels.Base;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// La clase de la que toda página tiene que heredar. Este código es el que añade la plantilla de Visual Studio
    /// a todas las nuevas páginas, con ligeras modificaciones para trabajar con nuestros vista-modelo
    /// </summary>
    public class BasePage : Page
    {
        /// <summary>
        /// The <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        private NavigationHelper navigationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class
        /// </summary>
        public BasePage()
        {
            navigationHelper = new NavigationHelper(this);
            navigationHelper.LoadState += NavigationHelper_LoadState;
            navigationHelper.SaveState += NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender"> The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        protected virtual void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with serializable state.</param>
        protected virtual void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BaseViewModel viewModel = DataContext as BaseViewModel;
            if (viewModel != null)
            {
                viewModel.OnNavigatedTo(e.Parameter);
            }

            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);

            BaseViewModel viewModel = DataContext as BaseViewModel;
            if (viewModel != null)
            {
                viewModel.OnNavigatedFrom();
            }
        }
    }
}
