namespace ToDoList.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using ToDoList.Data;
    using ToDoList.Models;

    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new ToDoDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string comments)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Task currentTask = new Task()
            {
                Title = title,
                Comments = comments
            };

            using (var db = new ToDoDbContext())
            {
                db.Tasks.Add(currentTask);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return View(taskToEdit);

            }
        }

        [HttpPost]
        public IActionResult Edit(Task editedTask)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ToDoDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == editedTask.Id);
                taskToEdit.Title = editedTask.Title;
                taskToEdit.Comments = editedTask.Comments;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details (int id)
        {
            using (var db = new ToDoDbContext())
            {
                var taskToDelete = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return View(taskToDelete);
            }
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var taskToDelete = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}