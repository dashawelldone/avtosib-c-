using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Avtosib
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainWindow : Page
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ProfileButton.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(UserPage));
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ScheduleButton.Style = null;
            BusButton.Style = null;
            TicketButton.Style = null;
            ProfileButton.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(UserPage));

        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileButton.Style = null;
            BusButton.Style = null;
            TicketButton.Style = null;
            ScheduleButton.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(ScheduleClient));
        }

        private void TicketButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileButton.Style = null;
            BusButton.Style = null;
            ScheduleButton.Style = null;
            TicketButton.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(BookingList));
        }

        private void BusButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileButton.Style = null;
            TicketButton.Style = null;
            ScheduleButton.Style = null;
            BusButton.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(BookingAdd));
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
          
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }


    }
}
