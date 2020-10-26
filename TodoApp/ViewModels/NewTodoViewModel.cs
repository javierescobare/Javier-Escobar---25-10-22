using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using TodoApp.Services.Abstractions;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class NewTodoViewModel: BaseViewModel
    {
        private readonly ITodoService _todoService;

        public TodoItem Todo { get; set; }
        public ICommand CreateTodoCommand { get; set; }


        public NewTodoViewModel(
            ITodoService todoService,
            INavigationService navigationService)
        {
            _todoService = todoService;
            _navigationService = navigationService;

            Todo = new TodoItem();
            CreateTodoCommand = new Command(async () => await CreateTodo());
        }


        private async Task CreateTodo()
        {
            if (string.IsNullOrWhiteSpace(Todo.Description))
            {
                return;
            }

            await _todoService.Insert(Todo);
            await _navigationService.NavigateBack();
        }
    }
}
