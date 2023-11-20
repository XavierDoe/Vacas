using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Vacas.Models;
using Vacas.Repositories;

namespace Inventarios.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventario _Inventario;
        public InventarioController(IInventario InventarioRepos)
        {
            _Inventario = InventarioRepos;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inventario Inventario)
        {
            var id = await _Inventario.Create(Inventario);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Inventario = await _Inventario.Get(ObjectId.Parse(id));

            return new JsonResult(Inventario);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Inventarios = await _Inventario.GetAll();
            return new JsonResult(Inventarios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Inventario Inventario)
        {
            var result = await _Inventario.Update(ObjectId.Parse(id), Inventario);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _Inventario.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
