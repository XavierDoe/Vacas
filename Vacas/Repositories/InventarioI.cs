using MongoDB.Bson;
using MongoDB.Driver;
using Vacas.Models;
using Vacas.Repositories;

namespace Inventarios.Repositories
{
    public class InventarioI : IInventario
    {
        private readonly IMongoCollection<Inventario> _Inventario;

        public InventarioI(IMongoClient client)
        {
            var database = client.GetDatabase("Inventario");
            var collection = database.GetCollection<Inventario>(nameof(Inventario));

            _Inventario = collection;
        }

        public async Task<ObjectId> Create(Inventario Inventario)
        {
            await _Inventario.InsertOneAsync(Inventario);

            return Inventario.Id;
        }

        public Task<Inventario> Get(ObjectId objectId)
        {
            var filter = Builders<Inventario>.Filter.Eq(c => c.Id, objectId);
            var Inventario = _Inventario.Find(filter).FirstOrDefaultAsync();

            return Inventario;
        }

        public async Task<IEnumerable<Inventario>> GetAll()
        {
            var Inventarios = await _Inventario.Find(_ => true).ToListAsync();

            return Inventarios;
        }

        public async Task<bool> Update(ObjectId objectId, Inventario Inventario)
        {
            var filter = Builders<Inventario>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Inventario>.Update
                .Set(c => c.Cantidad, Inventario.Cantidad)
                .Set(c => c.descripcion, Inventario.descripcion)
                .Set(c => c.precio, Inventario.precio)
                .Set(c => c.tipoArticulo, Inventario.tipoArticulo)
                .Set(c => c.NombreArticulo, Inventario.NombreArticulo);
            var result = await _Inventario.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Inventario>.Filter.Eq(c => c.Id, objectId);
            var result = await _Inventario.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
