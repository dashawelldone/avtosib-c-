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
    public sealed partial class AdminEdit : Page
    {
        private int? id;
        public AdminEdit()
        {
            this.InitializeComponent();
        }


        public bool Validate()
        {
            if (String.IsNullOrEmpty(Number.Text) || String.IsNullOrEmpty(Name.Text) || String.IsNullOrEmpty(Surname.Text))
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
            var admin = e.Parameter as Admin;
            id = admin.id;
            Name.Text = admin.name;
            Number.Text = admin.phonenumber;
            Surname.Text = admin.surname;
            Password.Password = admin.password;
        }

        private async void Save(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var admin = new Admin
                {
                    id = id,
                    name = Name.Text,
                    surname = Surname.Text,
                    phonenumber = Number.Text,
                    password = Password.Password,

                };

                await Admins.Update(admin);
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.GoBack();
            }
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            var admin = new Admin { id = id };
            await Admins.Delete(admin);
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(AdminPage));
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(AdminPage));
        }
    }
}

