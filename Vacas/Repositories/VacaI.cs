using MongoDB.Bson;
using MongoDB.Driver;
using Vacas.Models;

namespace Vacas.Repositories
{
    public class VacaI : IVaca
    {
        private readonly IMongoCollection<Vaca> _Vaca;

        public VacaI(IMongoClient client)
        {
            var database = client.GetDatabase("VacaDB");
            var collection = database.GetCollection<Vaca>(nameof(Vaca));

            _Vaca = collection;
        }

        public async Task<ObjectId> Create(Vaca Vaca)
        {
            await _Vaca.InsertOneAsync(Vaca);

            return Vaca.Id;
        }

        public Task<Vaca> Get(ObjectId objectId)
        {
            var filter = Builders<Vaca>.Filter.Eq(c => c.Id, objectId);
            var Vaca = _Vaca.Find(filter).FirstOrDefaultAsync();

            return Vaca;
        }

        public async Task<IEnumerable<Vaca>> GetAll()
        {
            var Vacas = await _Vaca.Find(_ => true).ToListAsync();

            return Vacas;
        }

        public async Task<bool> Update(ObjectId objectId, Vaca Vaca)
        {
            var filter = Builders<Vaca>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Vaca>.Update
                .Set(c => c.Raza, Vaca.Raza)
                .Set(c => c.Edad, Vaca.Edad)
                .Set(c => c.Vivo, Vaca.Vivo)
                .Set(c => c.Vivo, Vaca.Vivo)
                .Set(c => c.HistoriaVac, Vaca.HistoriaVac)
                .Set(c => c.InfoParto, Vaca.InfoParto);
            var result = await _Vaca.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Vaca>.Filter.Eq(c => c.Id, objectId);
            var result = await _Vaca.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
