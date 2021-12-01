using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeturReport.Models;
using SeturReport.Models.Queries;
using SeturReport.Models.Responses;

namespace SeturReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public ReportResponse<Report> GetReports(ReportQuery query)
        {
            try
            {

                using (var ctx = new ReportDbContext())
                {
                    IQueryable<Report> contacts = ctx.Reports.Where(c => query.ReportIds.Contains(c.ReportId));

                    foreach (var include in query.Includes)
                    {
                        contacts = contacts.Include(include);
                    }

                    return new ReportResponse<Report>() { Result = contacts.ToList(), Type = ResponseType.Succes };
                }
            }
            catch (Exception ex)
            {

                return new ReportResponse<Report> { ErrorMessage = ex.Message, Type = ResponseType.Error };
            }
        }
    }
}