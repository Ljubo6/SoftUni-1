using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                var allBooks = db.Library.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            
            using (var db = new LibraryDbContext())
            {
                db.Library.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Library.Where(x => x.Id == id).FirstOrDefault();
                if (bookToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return View(bookToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new LibraryDbContext())
            {
                db.Library.Update(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using(var db = new LibraryDbContext())
            {
                var bookToRemove = db.Library.Where(x => x.Id == id).FirstOrDefault();
                if (bookToRemove == null)
                {
                    return RedirectToAction("Index");
                }
                return View(bookToRemove);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book deletedBook)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToRemove = db.Library.FirstOrDefault(b => b.Id == deletedBook.Id);
                db.Library.Remove(bookToRemove);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}