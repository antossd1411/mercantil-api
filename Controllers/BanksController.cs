using mercantil_api.Models.Banks;
using mercantil_api.Services.Banks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mercantil_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BanksService _service;
        public BanksController(BanksService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Bank>> GetBanks()
        {
            var banks = _service.GetAll();

            return Ok(banks);
        }
    }
}
