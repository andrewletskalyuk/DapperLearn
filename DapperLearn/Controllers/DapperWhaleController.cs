using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperWhaleController : ControllerBase
    {
        // GET: api/<DapperWhaleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DapperWhaleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DapperWhaleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DapperWhaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DapperWhaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
