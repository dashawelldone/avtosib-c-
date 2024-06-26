﻿using System;
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
    public sealed partial class Menu : Page
    {
        public Menu()
        {
            this.InitializeComponent();
        }

        private void Button_Route(object sender, RoutedEventArgs e)
        {
             var frm = Window.Current.Content as Frame;
             frm.Navigate(typeof(SchedulerowList));
        }

        private void Button_Busstop(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(BusstopList1));
        }

        private void Button_Schedule(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(ScheduleList));
        }

      
    }
}
