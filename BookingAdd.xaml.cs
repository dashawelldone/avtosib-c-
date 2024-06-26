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
    public sealed partial class BookingAdd : Page
    {
        public BookingAdd()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RouteListBox.ItemsSource = await Schedulerows.getAll();
        }
        public bool Validate()
        {
            //if (String.IsNullOrEmpty(Num))
            //{
            //    var dialog = new ContentDialog()
            //    {
            //        Title = "Ошибка при заполнении формы",
            //        CloseButtonText = "Ok",
            //        IsPrimaryButtonEnabled = false
            //    };
            //    dialog.ShowAsync();
            //    return false;
            //}

            return true;
        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var booking = new Booking
                {
                  date = Date.SelectedDate.Value.Date.ToString("o"),
                    clientId = Auth.UserClient.id??1,
                  schedulerowId = (RouteListBox.SelectedItem as Schedulerow).id??1,
                };
                await Bookings.Add(booking);
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
            }

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(ScheduleClient));
        }

        private async void BookingComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            //DatePicker datePicker = (DatePicker)sender;

            //datePicker.SelectedDate = DateTime.Now; 

            //await Bookings.Add(datePicker.SelectedDate);
        }

     

    }
}
