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
    public sealed partial class ScheduleEdit : Page
    {
        private int? id;
        public ScheduleEdit()
        {
            this.InitializeComponent();
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(Route.Text) || String.IsNullOrEmpty(Busstop.Text) || String.IsNullOrEmpty(Time.Text))
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
            var schedule = e.Parameter as Schedulerow;
            id = schedule.id;
            Route.Text = schedule.routeId;
            Busstop.Text = schedule.busstopId;
            Time.Text = schedule.time;
        }

        private async void Update(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var schedule = new Schedulerow
                {
                    id = id,
                    routeId = Route.Text,
                    busstopId = Busstop.Text,
                    time = Time.Text,
                };
                await Schedulerows.Update(schedule);

                var frm = Window.Current.Content as Frame;
                frm.Navigate(typeof(ScheduleList));

            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(ScheduleList));
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedulerow { id = id };
            await Schedulerows.Delete(schedule);
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(ScheduleList));
        }
    }
}
