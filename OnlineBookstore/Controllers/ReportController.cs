using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Report.Application;

namespace OnlineBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("")]
        public Task Add(ReportLogDto reportLogDto)
        {
            try
            {
                _reportService.Add(reportLogDto);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
