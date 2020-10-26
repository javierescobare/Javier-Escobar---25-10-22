using System;
using SQLite;

namespace TodoApp.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
