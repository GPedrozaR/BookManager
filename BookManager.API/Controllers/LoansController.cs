using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {

        public LoansController()
        {
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }
    }
}
