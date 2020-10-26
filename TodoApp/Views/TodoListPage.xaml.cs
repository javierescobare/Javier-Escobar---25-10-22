using TodoApp.ViewModels;
using Xamarin.Forms;

namespace TodoApp.Views
{
    public partial class TodoListPage : ContentPage
    {
        private readonly TodoListViewModel viewModel;

        public TodoListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = App.Locator.TodoListViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearingCommand.Execute(null);
        }
    }
}
