using MongoDB.Bson;
using Vacas.Models;

namespace Vacas.Repositories
{
    public interface IInventario
    {
        // Create
        Task<ObjectId> Create(Inventario inventario);

        // Read
        Task<Inventario> Get(ObjectId objectId);

        // Read all
        Task<IEnumerable<Inventario>> GetAll();

        // Update
        Task<bool> Update(ObjectId objectId, Inventario vaca);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
