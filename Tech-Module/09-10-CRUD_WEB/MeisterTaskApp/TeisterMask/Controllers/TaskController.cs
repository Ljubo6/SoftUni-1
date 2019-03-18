using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeisterMask.Data;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new TeisterMaskDbContext())
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
        public IActionResult Create(string title, string status)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var taskToCreate = new Task()
            {
                Title = title,
                Status = status
            };

            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Add(taskToCreate);
                db.SaveChanges();
            }

            TempData["createdSuccessfully"] = "You have successfully created a new task!";

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            using (var db = new TeisterMaskDbContext())
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

            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == editedTask.Id);
                taskToEdit.Title = editedTask.Title;
                taskToEdit.Status = editedTask.Status;
                db.SaveChanges();
                TempData["editedSuccessfully"] = "Task was successfully edited!";

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new TeisterMaskDbContext())
            {
                var taskToDelete = db.Tasks.FirstOrDefault(t => t.Id == id);

                return View(taskToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete (Task deletedTask)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToDelete = db.Tasks.FirstOrDefault(t => t.Id == deletedTask.Id);
                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();
                TempData["deletedSuccessfully"] = "Task was successfully deleted!";

                return RedirectToAction("Index");
            }
        }
    }
}