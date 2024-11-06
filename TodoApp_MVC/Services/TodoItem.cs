using TodoApp_MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp_MVC.Services
{
    public class TodoService
    {
        private static List<TodoItem> _todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Learn .NET Core", IsCompleted = false },
            new TodoItem { Id = 2, Title = "Build MVC app", IsCompleted = false }
        };

        public List<TodoItem> GetTodos() => _todos;

        public TodoItem GetTodoById(int id) => _todos.FirstOrDefault(t => t.Id == id);

        public void AddTodo(TodoItem todo)
        {
            todo.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(todo);
        }

        public void UpdateTodo(TodoItem todo)
        {
            var existingTodo = GetTodoById(todo.Id);
            if (existingTodo != null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.IsCompleted = todo.IsCompleted;
            }
        }

        public void DeleteTodo(int id)
        {
            var todo = GetTodoById(id);
            if (todo != null)
            {
                _todos.Remove(todo);
            }
        }
    }
}
