using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using BandRegister.Data;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new ConcertDBContext())
            {
                var allBands = db.Concerts.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ConcertDBContext())
            {
                db.Concerts.Add(band);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new ConcertDBContext())
            {
                Band bandToEdit = db.Concerts.FirstOrDefault(x => x.Id == id);
                return View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new ConcertDBContext())
            {
                Band editedBand = db.Concerts.FirstOrDefault(x => x.Id == band.Id);
                editedBand.Genre = band.Genre;
                editedBand.Honorarium = band.Honorarium;
                editedBand.Members = band.Members;
                editedBand.Name = band.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new ConcertDBContext())
            {
                Band bandToDelete = db.Concerts.FirstOrDefault(x => x.Id == id);
                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new ConcertDBContext())
            {
                Band deletedBand = db.Concerts.FirstOrDefault(x => x.Id == band.Id);
                db.Remove(deletedBand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}