using MongoDB.Bson;
using Vacas.Models;

namespace Vacas.Repositories
{
    public interface IHistorialVacunacion
    {
        // Create
        Task<ObjectId> Create(HistorialVacunacion vaca);

        // Read
        Task<HistorialVacunacion> Get(ObjectId objectId);

        // Update
        Task<bool> Update(ObjectId objectId, HistorialVacunacion vaca);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
