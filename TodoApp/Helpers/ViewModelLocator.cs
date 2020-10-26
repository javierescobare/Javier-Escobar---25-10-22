using Autofac;
using TodoApp.Services;
using TodoApp.Services.Abstractions;
using TodoApp.ViewModels;

namespace TodoApp.Helpers
{
    public class ViewModelLocator
    {
        private static IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            builder.RegisterType<TodoListViewModel>();
            builder.RegisterType<NewTodoViewModel>();

            // Services     
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<TodoService>().As<ITodoService>().SingleInstance();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public TodoListViewModel TodoListViewModel
        {
            get { return _container.Resolve<TodoListViewModel>(); }
        }

        public NewTodoViewModel NewTodoViewModel
        {
            get { return _container.Resolve<NewTodoViewModel>(); }
        }
    }
}
