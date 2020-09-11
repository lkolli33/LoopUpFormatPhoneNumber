using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoopUpFormatPhoneNumber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormatPhoneNumberController : ControllerBase
    {
        // GET api/<FormatPhoneNumber>/5
        // API to format UK phone numbers
        [HttpGet("{phoneNumber}")]
        public IActionResult GetFormat
        ([FromHeader] string phoneNumber)
        {
            return Ok(Helpers.PhoneNumberFormatHelper.FormatAsUkTelephone(phoneNumber));
        }

    }
}
