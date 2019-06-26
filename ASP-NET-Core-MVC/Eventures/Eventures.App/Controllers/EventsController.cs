using Eventures.App.Models.InputModels;
using Eventures.App.Models.ViewModels;
using Eventures.Domain;
using Eventures.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eventures.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventuresDbContext context;

        public EventsController(EventuresDbContext context)
        {
            this.context = context;
        }

        public IActionResult All()
        {
            var viewModel = this.context.Events
                .Select(e => new EventViewModel
                {
                    Name = e.Name,
                    Start = e.Start.ToString("dd-MMM-yy HH:mm"),
                    End = e.End.ToString("dd-MMM-yy HH:mm"),
                    Place = e.Place
                })
                .ToList();

            return this.View(viewModel);
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateEventInputModel inputModel)
        {
            var newEvent = new Event
            {
                Name = inputModel.Name,
                Place = inputModel.Place,
                Start = inputModel.Start,
                End = inputModel.End,
                PricePerTicket = inputModel.PricePerTicket,
                TotalTickets = inputModel.TotalTickets
            };

            this.context.Add(newEvent);
            this.context.SaveChanges();

            return this.Redirect("All");
        }
    }
}