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
    public sealed partial class BusstopList : Page
    {
        public BusstopList()
        {
            this.InitializeComponent();
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(Busstop.Text))
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

        private async void Add(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var busstop = new Busstop
                {
                    name = Busstop.Text,
                };
                await Busstops.Add(busstop);
                var frm = Window.Current.Content as Frame;
                frm.Navigate(typeof(BusstopList1));
            }

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(AdminPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
