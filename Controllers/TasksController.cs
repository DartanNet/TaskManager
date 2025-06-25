using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Data;
using TaskManager.Models;
using System.Linq;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TasksController> _logger;

        // Jeden konstruktor z dwoma parametrami
        public TasksController(AppDbContext context, ILogger<TasksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tasks = _context.Tasks.OrderByDescending(t => t.CreatedAt).ToList();
            _logger.LogInformation($"Loaded {tasks.Count} tasks");
            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            Console.WriteLine("Create POST called");
            _logger.LogInformation("Create POST method called");
            
            _logger.LogInformation($"ModelState.IsValid: {ModelState.IsValid}, Errors count: {ModelState.ErrorCount}");
            _logger.LogInformation($"ModelState.IsValid: {ModelState.IsValid}");
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogWarning($"Validation error in '{state.Key}': {error.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                task.CreatedAt = DateTime.Now;
                _context.Tasks.Add(task);
                _context.SaveChanges();
                _logger.LogInformation("Task saved successfully.");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning("Validation error: " + error.ErrorMessage);
                }
            }

            return View(task);
        }



        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
