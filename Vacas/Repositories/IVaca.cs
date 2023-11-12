using MongoDB.Bson;
using Vacas.Models;

namespace Vacas.Repositories
{
    public interface IVaca
    {
        // Create
        Task<ObjectId> Create(Vaca vaca);

        // Read
        Task<Vaca> Get(ObjectId objectId);

        // Read all
        Task<IEnumerable<Vaca>> GetAll();

        // Update
        Task<bool> Update(ObjectId objectId, Vaca vaca);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
