using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Vacas.Models;
using Vacas.Repositories;

namespace Vacas.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class VacunacionController : Controller
    {
        private readonly IHistorialVacunacion _HistorialVacunacion;
        public VacunacionController(IHistorialVacunacion Historial)
        {
            _HistorialVacunacion = Historial;
        }

        [HttpPost]
        public async Task<IActionResult> Create(HistorialVacunacion Historial)
        {
            var id = await _HistorialVacunacion.Create(Historial);

            return new JsonResult(id.ToString());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Vaca = await _HistorialVacunacion.Get(ObjectId.Parse(id));

            return new JsonResult(Vaca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, HistorialVacunacion Historial)
        {
            var result = await _HistorialVacunacion.Update(ObjectId.Parse(id), Historial);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _HistorialVacunacion.Delete(ObjectId.Parse(id));

            return new JsonResult(result);
        }
    }
}
