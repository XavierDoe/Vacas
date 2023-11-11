using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Vacas.Repositories;
using Vacas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vacas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacasController : ControllerBase
    {
        private readonly IVaca _Vaca;
        public VacasController(IVaca VacaRepository)
        {
            _Vaca = VacaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vaca Vaca)
        {
            var id = await _Vaca.Create(Vaca);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Vaca = await _Vaca.Get(ObjectId.Parse(id));

            return new JsonResult(Vaca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Vaca Vaca)
        {
            var result = await _Vaca.Update(ObjectId.Parse(id), Vaca);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _Vaca.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
