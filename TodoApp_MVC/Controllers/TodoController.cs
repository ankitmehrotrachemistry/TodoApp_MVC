using Microsoft.AspNetCore.Mvc;
using TodoApp_MVC.Models;
using TodoApp_MVC.Services;

namespace TodoApp_MVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // Get list of todos
        public IActionResult Index()
        {
            var todos = _todoService.GetTodos();
            return View(todos);
        }

        // Add new todo
        [HttpPost]
        public IActionResult Add(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.AddTodo(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // Edit existing todo
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _todoService.GetTodoById(id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _todoService.UpdateTodo(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // Delete todo
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _todoService.DeleteTodo(id);
            return RedirectToAction("Index");
        }
    }
}
