﻿using Avtosib.Services;
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
    public sealed partial class ScheduleClient : Page
    {
        public ScheduleClient()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RouteListBox.ItemsSource = await Schedulerows.getAll();
        }

        private  async void Add(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(BookingAdd));
        }

        private void SelectedRoute(object sender, SelectionChangedEventArgs e)
        {
            var schedule = this.RouteListBox.SelectedItem as Schedulerow;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(ScheduleClient), schedule);
        }

    }
}