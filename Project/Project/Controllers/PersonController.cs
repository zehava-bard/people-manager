using Project.BLL;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.DAL;
using System.Text;
using System.Data;
namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PersonController : ControllerBase
    {
        private readonly IPersonService _Personservice;
        private readonly Context _context;
        private readonly IConfiguration _config;

        public PersonController(IPersonService buyer, IConfiguration _config, Context _context)
        {
            this._Personservice = buyer;
            this._config = _config;
            this._context = _context;
        }
        /*        [HttpGet("getAllPersons")]
         *        [HttpGet("DeletePerson")]
         *        [HttpGet("AddPerson")]
*/
        [HttpGet("getAll")]
        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            var p = await _Personservice.GetAllPerson();
            return p;
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            try
            {
                _Personservice.AddPerson(person);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }


        [HttpDelete("{id}")]

        public async void DeletePerson(int id)
        {
            _Personservice.DeletePerson(id);
        }
    }
}
