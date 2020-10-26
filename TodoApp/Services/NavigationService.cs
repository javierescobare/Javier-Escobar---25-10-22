using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Services.Abstractions;
using TodoApp.ViewModels;
using TodoApp.Views;
using Xamarin.Forms;

namespace TodoApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(TodoListViewModel),  typeof(TodoListPage) },
            { typeof(NewTodoViewModel), typeof(NewTodoPage) }
        };

        public async Task NavigateTo<TDestinationViewModel>()
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType) as Page;

            if (page != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        public async Task NavigateTo(Type destinationType)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType) as Page;

            if (page != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        public async Task NavigateBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
