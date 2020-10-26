using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using TodoApp.Helpers;
using TodoApp.Models;
using TodoApp.Services.Abstractions;
using Xamarin.Forms;

namespace TodoApp.Services
{
    public class TodoService: ITodoService
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            return new SQLiteAsyncConnection(databasePath);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public TodoService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TodoItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TodoItem)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public async Task<IList<TodoItem>> GetAll()
        {
            var items = await Database
                .Table<TodoItem>()
                .ToListAsync()
                .ConfigureAwait(false);
            return items;
        }

        public async Task Insert(TodoItem item)
        {
            await Database.InsertAsync(item);
        }

        public async Task Remove(TodoItem item)
        {
            await Database.DeleteAsync(item);
        }

        public async Task<bool> Update(TodoItem item)
        {
            var existing = await Database
                .Table<TodoItem>()
                .FirstOrDefaultAsync(t =>
                    t.Id == item.Id &&
                    t.Completed == item.Completed
                )
                .ConfigureAwait(false);
            bool willUpdate = existing is null;
            if (willUpdate)
            {
                await Database.UpdateAsync(item);
            }
            return willUpdate;
        }
    }
}
