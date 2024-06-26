using Avtosib.Services;
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
    public sealed partial class BookingUser : Page
    {
        public BookingUser()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RouteListBox.ItemsSource = await Bookings.getAll();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            //Frame rootFrame = Window.Current.Content as Frame;
            //rootFrame.Navigate(typeof(BookingEdit));
        }

        private void SelectedRoute(object sender, SelectionChangedEventArgs e)
        {
            //var booking = this.RouteListBox.SelectedItem as Booking;

            //Frame rootFrame = Window.Current.Content as Frame;
            //rootFrame.Navigate(typeof(BookingEdit), booking);
        }
    }
}
