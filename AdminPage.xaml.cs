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
    public sealed partial class AdminPage : Page
    {
        public AdminPage()
        {
            this.InitializeComponent();
         
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Admin_Schedilerow.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(AdminClientList));
        }

        private void Admin_Schedilerow_Click(object sender, RoutedEventArgs e)
        {
            Admin_Client.Style = null;
            Admin_Route.Style = null;
            Admin_Booking.Style = null;
            Admin_Admin.Style = null;
            Admin_Schedilerow.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(Menu));
        }

        private void Admin_Route_Click(object sender, RoutedEventArgs e)
        {
            Admin_Client.Style = null;
            Admin_Schedilerow.Style = null;
            Admin_Booking.Style = null;
            Admin_Admin.Style = null;
            Admin_Route.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(RoteList));
        }

        private void Admin_Booking_Click(object sender, RoutedEventArgs e)
        {
            Admin_Client.Style = null;
            Admin_Schedilerow.Style = null;
            Admin_Route.Style = null;
            Admin_Admin.Style = null;
            Admin_Booking.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(BookingList));

        }

        private void Admin_Client_Click(object sender, RoutedEventArgs e)
        {
            Admin_Booking.Style = null;
            Admin_Schedilerow.Style = null;
            Admin_Route.Style = null;
            Admin_Admin.Style = null;
            Admin_Client.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(AdminClientList));

        }

        private void Admin_Admin_Click(object sender, RoutedEventArgs e)
        {
            Admin_Booking.Style = null;
            Admin_Schedilerow.Style = null;
            Admin_Route.Style = null;
            Admin_Client.Style = null;
            Admin_Admin.Style = (Style)Application.Current.Resources["AccentButtonStyle"];
            frx.Navigate(typeof(AdminList));
        }


        private void Logout(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage));
        }
    }
}
