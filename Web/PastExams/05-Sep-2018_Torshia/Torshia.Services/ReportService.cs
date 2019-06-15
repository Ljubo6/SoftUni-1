namespace Torshia.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using Torshia.Data;
    using Torshia.Models;
    using Torshia.Models.Enums;

    public class ReportService : IReportService
    {
        private readonly TorshiaDbContext context;

        public ReportService(TorshiaDbContext context)
        {
            this.context = context;
        }
        public bool CreateReportByTaskId(string userId, string taskId)
        {
            var random = new Random();
            ReportStatus status = ReportStatus.Completed;

            if(random.Next(1, 5) == 4)
            {
                status = ReportStatus.Archived;
            }

            var report = new Report
            {
                TaskId = taskId,
                ReporterId = userId,
                ReportedOn = DateTime.UtcNow,
                Status = status
            };

            this.context.Add(report);
            this.context.SaveChanges();
            return true;
        }

        public IQueryable<Report> GetAllReports()
        {
            return this.context
                .Reports
                .Include(report => report.Task.AffectedSectors)
                .Include(report => report.Task)
                .Include(report => report.Reporter)
                .Include(report => report.Task.Participants)
                .ThenInclude(p => p.User);
        }

        public Report GetReportById(string id)
        {
            return this.GetAllReports().SingleOrDefault(report => report.Id == id);
        }
    }
}
