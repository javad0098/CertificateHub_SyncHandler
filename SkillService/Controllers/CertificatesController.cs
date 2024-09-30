using Microsoft.AspNetCore.Mvc;
using System;
namespace SkillService.Controllers
{
    [ApiController]
    [Route("api/s/[controller]")]
    public class CertificatesController : ControllerBase
    {
        public CertificatesController()
        {

        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult TestInboundConnection()
        {
            Console.WriteLine("==> Inbound post # Skill Services ");
            return Ok("Inbound test of from Certificate controller");
        }
    }
}
