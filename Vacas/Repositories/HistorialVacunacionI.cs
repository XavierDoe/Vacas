using MongoDB.Bson;
using MongoDB.Driver;
using Vacas.Models;
using Vacas.Repositories;

namespace HistorialVacunacions.Repositories
{
    public class HistorialVacunacionI : IHistorialVacunacion
    {
        private readonly IMongoCollection<HistorialVacunacion> _Historial;

        public HistorialVacunacionI(IMongoClient client)
        {
            var database = client.GetDatabase("HistorialVacunacion");
            var collection = database.GetCollection<HistorialVacunacion>(nameof(HistorialVacunacion));

            _Historial = collection;
        }

        public async Task<ObjectId> Create(HistorialVacunacion HistorialVacunacion)
        {
            await _Historial.InsertOneAsync(HistorialVacunacion);

            return HistorialVacunacion.Id;
        }

        public Task<HistorialVacunacion> Get(ObjectId objectId)
        {
            var filter = Builders<HistorialVacunacion>.Filter.Eq(c => c.Id, objectId);
            var HistorialVacunacion = _Historial.Find(filter).FirstOrDefaultAsync();

            return HistorialVacunacion;
        }

        public async Task<IEnumerable<HistorialVacunacion>> Get()
        {
            var HistorialVacunacions = await _Historial.Find(_ => true).ToListAsync();

            return HistorialVacunacions;
        }

        public async Task<bool> Update(ObjectId objectId, HistorialVacunacion HistorialVacunacion)
        {
            var filter = Builders<HistorialVacunacion>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<HistorialVacunacion>.Update
                .Set(c => c.IdVaca, HistorialVacunacion.IdVaca)
                .Set(c => c.FechaVacunas, HistorialVacunacion.FechaVacunas)
                .Set(c => c.Enfermedades, HistorialVacunacion.Enfermedades)
                .Set(c => c.Tratamientos, HistorialVacunacion.Tratamientos);
            var result = await _Historial.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<HistorialVacunacion>.Filter.Eq(c => c.Id, objectId);
            var result = await _Historial.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
