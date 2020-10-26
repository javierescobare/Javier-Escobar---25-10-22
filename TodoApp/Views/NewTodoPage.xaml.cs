using System;
using System.Collections.Generic;
using TodoApp.ViewModels;
using TodoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TodoApp.Views
{

    public partial class NewTodoPage : ContentPage
    {
        public NewTodoPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.NewTodoViewModel;
        }
    }
}
