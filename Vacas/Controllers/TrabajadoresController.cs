using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Vacas.Repositories;
using Vacas.Models;

namespace Vacas.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ITrabajador _Trabajador;
        public TrabajadoresController(ITrabajador TrabajadorRepository)
        {
            _Trabajador = TrabajadorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Trabajador Trabajador)
        {
            var id = await _Trabajador.Create(Trabajador);

            return new JsonResult(id.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Vacas = await _Trabajador.GetAll();
            return new JsonResult(Vacas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Trabajador = await _Trabajador.Get(ObjectId.Parse(id));
            return new JsonResult(Trabajador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Trabajador trabajador)
        {
            var result = await _Trabajador.Update(ObjectId.Parse(id), trabajador);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _Trabajador.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
