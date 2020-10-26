using System;
using System.Collections.Generic;
using TodoApp.Helpers;

namespace TodoApp.Models
{
    public class TodoItemsGroup : ObservableRangeCollection<TodoItem>
    {
        public TodoItemCompletedState State { get; set; }

        private string _groupName;
        public string GroupName
        {
            get
            {
                switch (State)
                {
                    case TodoItemCompletedState.Completed:
                        _groupName = "Completados";
                        break;
                    case TodoItemCompletedState.Pending:
                        _groupName = "Pendientes";
                        break;
                }
                return _groupName;
            }
        }

        public ObservableRangeCollection<TodoItem> TodoItems => this;

        public TodoItemsGroup(TodoItemCompletedState state)
        {
            this.State = state;
        }
    }

    public enum TodoItemCompletedState
    {
        Completed,
        Pending
    }
}
