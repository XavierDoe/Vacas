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
        public async Task<ObjectId> Create(Trabajador Trabajador)
        {
            await _Trabajador.Insert(Trabajador);
            return Trabajador.Id;

        }

        public Task<Trabajador> Get(ObjectId objectId)
        {
            var filter = Builders<Trabajador>.Filter.Eq(c => c.Id, objectId);
            var Trabajador = _Trabajador.Find(filter).FirstOrDefaultAsync();

            return Trabajador;
        }

        public async Task<IEnumerable<Trabajador>> Get()
        {
            var Trabajadores = await _Trabajador.Find(_ => true).ToListAsync();

            return Trabajadores;
        }

        public async Task<bool> Update(ObjectId objectId, Trabajador trabajador)
        {
            var filter = Builders<Trabajador>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Trabajador>.Update
                .Set(c => c.Nombre, Trabajador.Nombre)
                .Set(c => c.Edad, Trabajador.Edad)
                .Set(c => c.Sexo, Trabajador.Sexo)
                .Set(c => c.HistoriaEmpleo, Trabajador.HistoriaEmpleo)
                .Set(c => c.Salario, Trabajador.Salario)
                .Set(c => c.Permisos, Trabajador.Permisos)
                .Set(c => c.Certificaciones, Trabajador.Certificaciones);
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
