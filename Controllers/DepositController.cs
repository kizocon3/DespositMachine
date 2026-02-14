using DespositMachine.Web.Models;
using DespositMachine.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DespositMachine.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepositController: ControllerBase
    {
        private readonly IDepositService _service;

        public DepositController(IDepositService service)
        {
            _service = service;
        }

        [HttpPost("Insert/{type}")]
        public async Task<IActionResult> InsertAsync([FromRoute]  ContainerType type)
        {
            try
            {
                await _service.InsertAsync(type);
                return Ok(new { total = _service.CurrentTotal });
      
            }
            catch (ArgumentException ex)
            {
               return StatusCode(500, $"Internal error: {ex.Message}");
            }
      
        }

        [HttpPost("Voucher")]
        public IActionResult PrintVoucher()
        {
            var voucher = _service.PrintVoucher();
            return Ok(voucher);
        }
    }
}
