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
    public sealed partial class UserEdit2 : Page
    {
        private int? id;
        public UserEdit2()
        {
            this.InitializeComponent();
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(Number.Text) || String.IsNullOrEmpty(Name.Text) || String.IsNullOrEmpty(Surname.Text) || String.IsNullOrEmpty(Password.Password))
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
            var client = e.Parameter as Client;
            id = client.id;
            Name.Text = client.name;
            Surname.Text = client.surname;
            Number.Text = client.phonenumber;
            //Password.Password = client.password;
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var client = new Client
                {
                    id = id,
                    name = Name.Text,
                    surname = Surname.Text,
                    phonenumber = Number.Text,
                    password = Password.Password
                };

                await Clients.Update(client);
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(UserPage));
        }

    }
}

