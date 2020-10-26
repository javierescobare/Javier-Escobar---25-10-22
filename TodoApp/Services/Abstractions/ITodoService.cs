using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Services.Abstractions
{
    public interface ITodoService
    {
        Task<IList<TodoItem>> GetAll();
        Task Insert(TodoItem item);
        Task Remove(TodoItem item);
        Task<bool> Update(TodoItem item);
    }
}
