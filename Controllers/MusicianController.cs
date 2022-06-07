using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kolokwium2.Controllers
{
    [Route("api/musician")]
    [ApiController]    
    public class MusicianController : ControllerBase
    {
        private readonly IDbService _dbService;
        public MusicianController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{IdMusician}")]
        public async Task<IActionResult> GetMusician(int IdMusician)
        {
            return Ok(await _dbService.GetMusician(IdMusician));
        }

        [HttpDelete("{IdMusician}")]
        public async Task<IActionResult> RemoveMusician(int IdMusician)
        {
            if(await _dbService.RemoveMusician(IdMusician)) return Ok("Musician removed");
            else return NotFound("Musician can not be removed");
        }
        
    }
}