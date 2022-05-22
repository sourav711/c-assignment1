using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cricket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cricket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        // GET: api/Stadium
        private readonly CricketContext _cricketcontext;
        public StadiumController(CricketContext cricketcs)
        {
            _cricketcontext = cricketcs;
        }
        [HttpGet]
        public IActionResult Get3()
        {
            var getStadiums = _cricketcontext.Stadium.ToList();
            return Ok(getStadiums);
        }


     /*   // GET: api/Stadium/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Stadium
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Stadium/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
