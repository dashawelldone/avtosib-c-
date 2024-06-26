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
    public sealed partial class AdminAdd : Page
    {
        public AdminAdd()
        {
            this.InitializeComponent();
        }

        public bool Validate()
        {
            if (String.IsNullOrEmpty(NumberReg.Text) || String.IsNullOrEmpty(NameReg.Text) || String.IsNullOrEmpty(Surname.Text) || String.IsNullOrEmpty(PasswordReg.Password))
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

        private async void Button_Add(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var admin = new Admin
                {
                    name = NameReg.Text,
                    surname = Surname.Text,
                    phonenumber = NumberReg.Text,
                    password = PasswordReg.Password,
                };
                await Admins.Add(admin);
                var frm = Window.Current.Content as Frame;
                frm.Navigate(typeof(AdminPage));
            }

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var frm = Window.Current.Content as Frame;
            frm.Navigate(typeof(AdminPage));
        }
    }
}
