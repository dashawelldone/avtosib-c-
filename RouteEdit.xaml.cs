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
    public sealed partial class RouteEdit : Page
    {
        private int? id;
        public RouteEdit()
        {
            this.InitializeComponent();
        }

     
        public bool Validate()
        {
            if (String.IsNullOrEmpty(Number.Text))
            {
                var dialog = new ContentDialog()
                {
                    Title = "Ошибка при заполнении формы",
                    CloseButtonText = "Ok",
                    IsPrimaryButtonEnabled = false
                };
                dialog.ShowAsync();
                return false;
            }

            return true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var itinerary = e.Parameter as Itinerary;
            id = itinerary.id;
            Number.Text = itinerary.number;
        }

        private async void Update(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var itinerary = new Itinerary
                {
                    id = id,
                    number = Number.Text,
                };
                await Itinerarys.Update(itinerary);

                var frm = Window.Current.Content as Frame;
                frm.Navigate(typeof(RoteList));

            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(AdminPage));
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            var itinerary = new Itinerary { id = id };
            await Itinerarys.Delete(itinerary);
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(AdminPage));
        }

    }
}

