﻿using CrudXamarin2.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TarjetaCreditoPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
