using System;
using TodoApp.Helpers;
using TodoApp.Services;
using TodoApp.Services.Abstractions;
using TodoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get { return _locator = _locator ?? new ViewModelLocator(); }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListPage());
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
