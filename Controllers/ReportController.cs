using Microsoft.AspNetCore.Mvc;
using SahafWebAPI.DataProvider;
using SahafWebAPI.Models;

namespace SahafWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportDataProvider reportData;
        public ReportController(IReportDataProvider reportData)
        {
            this.reportData = reportData;
        }

        [HttpGet]
        public List<Gunluk_Rapor> Get()
        {
            return reportData.GetList();
        }

        [HttpGet("{id}")]
        public Gunluk_Rapor Get(int id)
        {
            return reportData.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Gunluk_Rapor rapor)
        {
            reportData.Create(rapor);
        }

        [HttpPut("{id}")]
        public void Put(Gunluk_Rapor rapor)
        {
            reportData.Update(rapor);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            reportData.Delete(id);
        }
    }
}
