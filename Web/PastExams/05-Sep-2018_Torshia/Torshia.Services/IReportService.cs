using System.Linq;
using Torshia.Models;

namespace Torshia.Services
{
    public interface IReportService
    {
        bool CreateReportByTaskId(string userId, string taskId);
        IQueryable<Report> GetAllReports();
        Report GetReportById(string id);
    }
}
