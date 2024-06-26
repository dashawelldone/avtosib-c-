using Avtosib.Services;
using System;
using System.Collections;
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
    public sealed partial class SchedulerowList : Page
    {
        public SchedulerowList()
        {
            this.InitializeComponent();

        }

        private async void routeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list1 = await Busstops.getAll();
            var selectedRoute = (Itinerary)routeComboBox.SelectedItem;
            var list2 = selectedRoute?.busstops;
            RouteListBox.ItemsSource = selectedRoute?.busstops;
            var nonIntersectingItems = list1.Where(item1 => !list2.Any(item2 => item2.id == item1.id))
            .Concat(list2.Where(item2 => !list1.Any(item1 => item1.id == item2.id)))
            .ToList();

            this.busstopComboBox.ItemsSource = nonIntersectingItems;
        }

        private void busstopComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedBusstop = (Busstop)busstopComboBox.SelectedItem;
            var selectedRoute = (Schedulerow)routeComboBox.SelectedItem;

        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
          
            routeComboBox.ItemsSource = await Itinerarys.getAll();
            routeComboBox.SelectedIndex = 0;
            var selectedRoute = (Itinerary)routeComboBox.SelectedItem;
            RouteListBox.ItemsSource = selectedRoute?.busstops;

        }

        private async void Add(object sender, RoutedEventArgs e)
        {
            var selectedBusstop = (Busstop)busstopComboBox.SelectedItem;
            var selectedRoute = (Itinerary)routeComboBox.SelectedItem;
            selectedRoute.busstops.Add(selectedBusstop);
            await Itinerarys.Update(selectedRoute);

        }

        private void SelectedRoute(object sender, SelectionChangedEventArgs e)
        {
            var busstop = this.RouteListBox.SelectedItem as Busstop;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(BusstopEdit), busstop);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(Menu));
        }

       
    }
}
