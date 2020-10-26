using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Helpers;
using TodoApp.Models;
using TodoApp.Services.Abstractions;
using TodoApp.Views;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class TodoListViewModel: BaseViewModel
    {
        private readonly ITodoService _todoService;

        public ObservableCollection<TodoItemsGroup> TodoItems { get; set; }
        public ICommand AddTodoCommand { get; set; }
        public ICommand DeleteTodoCommand { get; set; }
        public ICommand UpdateTodoCommand { get; set; }


        public TodoListViewModel(ITodoService todoService, INavigationService navigationService)
        {
            _todoService = todoService;
            _navigationService = navigationService;

            TodoItems = new ObservableCollection<TodoItemsGroup>();
            AddTodoCommand = new Command(async () => await AddTodo());
            OnAppearingCommand = new Command(async () => await OnAppearing());
            DeleteTodoCommand = new Command<TodoItem>(async (item) => await DeleteTodo(item));
            UpdateTodoCommand = new Command<TodoItem>(async (item) => await UpdateTodo(item));
        }


        private async Task OnAppearing()
        {
            await LoadTodoList();
        }

        private async Task LoadTodoList()
        {
            var todos = await _todoService.GetAll();
            var pendingGroup = TodoItems.FirstOrDefault(t => t.State == TodoItemCompletedState.Pending);
            if (pendingGroup is null)
            {
                pendingGroup = new TodoItemsGroup(TodoItemCompletedState.Pending);
            }
            var completedGroup = TodoItems.FirstOrDefault(t => t.State == TodoItemCompletedState.Completed);
            if (completedGroup is null)
            {
                completedGroup = new TodoItemsGroup(TodoItemCompletedState.Completed);
            }

            var pending = todos.Where(t => !t.Completed).ToList();
            pendingGroup.TodoItems.ReplaceRange(pending);
            var completed = todos.Where(t => t.Completed).ToList();
            completedGroup.TodoItems.ReplaceRange(completed);
            TodoItems.Clear();
            TodoItems.Add(pendingGroup);
            TodoItems.Add(completedGroup);
        }

        private async Task AddTodo()
        {
            await _navigationService.NavigateTo<NewTodoViewModel>();
        }

        private async Task UpdateTodo(TodoItem item)
        {
            var updated = await _todoService.Update(item);
            if (updated)
            {
                await LoadTodoList();
            }
        }

        private async Task DeleteTodo(TodoItem item)
        {
            var willDelete = await _navigationService.DisplayAlert(
                "Confirmación",
                "¿Estás seguro que deseas borrar la tarea?",
                "Sí, borrar", "Cancelar");
            if (willDelete)
            {
                await _todoService.Remove(item);
                await LoadTodoList();
            }
        }
    }
}
