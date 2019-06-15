using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;
using Torshia.App.ViewModels;
using Torshia.Services;

namespace Torshia.App.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [Authorize("Admin")]
        public IActionResult All()
        {
            var allReports = this.reportService.GetAllReports();
            var viewModel = allReports.Select(report => new ReportsAllViewModel
            {
                Id = report.Id,
                Status = report.Status.ToString(),
                TaskLevel = report.Task.AffectedSectors.Count,
                TaskTitle = report.Task.Title
            }).ToList();

            return this.View(viewModel);
        }

        [Authorize("Admin")]
        public IActionResult Details(string id)
        {
            var report = this.reportService.GetReportById(id);
            var viewModel = new ReportViewModel
            {
                Id = report.Id,
                TaskTitle = report.Task.Title,
                TaskLevel = report.Task.AffectedSectors.Count,
                AffectedSectors = string.Join(", ", report.Task.AffectedSectors.Select(s => s.Sector.ToString())),
                ReportedOn = report.ReportedOn.ToString("dd/MM/yyyy"),
                TaskDueDate = report.Task.DueDate.ToString("dd/MM/yyyy"),
                ReporterName = report.Reporter.Username,
                Status = report.Status.ToString(),
                TaskDescription = report.Task.Description,
                Participants = string.Join(", ", report.Task.Participants.Select(p => p.User.Username))
            };

            return this.View(viewModel);
        }
    }
}

