using MongoDB.Bson;
using MongoDB.Driver;
using Vacas.Models;

namespace Vacas.Repositories
{
    public class TrabajadorI : ITrabajador
    {
        private readonly IMongoCollection<Trabajador> _Trabajador;

        public TrabajadorI(IMongoClient client)
        {
            var database = client.GetDatabase("TrabajadorDB");
            var collection = database.GetCollection<Trabajador>(nameof(Trabajador));

            _Trabajador = collection;
        }
        public async Task<ObjectId> Create(Trabajador trabajador)
        {
            await _Trabajador.InsertOneAsync(trabajador);
            return trabajador.Id;

        }

        public Task<Trabajador> Get(ObjectId objectId)
        {
            var filter = Builders<Trabajador>.Filter.Eq(c => c.Id, objectId);
            var Trabajador = _Trabajador.Find(filter).FirstOrDefaultAsync();

            return Trabajador;
        }

        public async Task<IEnumerable<Trabajador>> GetAll()
        {
            var Trabajadores = await _Trabajador.Find(_ => true).ToListAsync();

            return Trabajadores;
        }

        public async Task<bool> Update(ObjectId objectId, Trabajador trabajador)
        {
            var filter = Builders<Trabajador>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Trabajador>.Update
                .Set(c => c.Nombre, trabajador.Nombre)
                .Set(c => c.Edad, trabajador.Edad)
                .Set(c => c.Sexo, trabajador.Sexo)
                .Set(c => c.HistoriaEmpleo, trabajador.HistoriaEmpleo)
                .Set(c => c.Salario, trabajador.Salario)
                .Set(c => c.Permisos, trabajador.Permisos)
                .Set(c => c.Certificaciones, trabajador.Certificaciones);
            var result = await _Trabajador.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Trabajador>.Filter.Eq(c => c.Id, objectId);
            var result = await _Trabajador.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }

    }


}
