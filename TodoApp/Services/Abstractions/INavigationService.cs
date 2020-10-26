using System;
using System.Threading.Tasks;

namespace TodoApp.Services.Abstractions
{
    public interface INavigationService
    {
        Task NavigateTo<TDestinationViewModel>();

        Task NavigateTo(Type destinationType);

        Task NavigateBack();

        Task DisplayAlert(string title, string message, string cancel);

        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    }
}
