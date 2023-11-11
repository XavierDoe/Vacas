using MongoDB.Bson;

namespace Vacas.Models
{
    public class HistorialVacunacion
    {
        public ObjectId Id { get; set; }
        public string? IdVaca { get; set; }
        public List<DateOnly> FechaVacunas {  get; set; }
        public List<Enfermedades> Enfermedades { get; set; }
        public List<Tratamientos>  Tratamientos { get; set; }
    }
}
