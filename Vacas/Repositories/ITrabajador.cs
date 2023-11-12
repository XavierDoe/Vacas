using MongoDB.Bson;
using Vacas.Models;

namespace Vacas.Repositories
{

        public interface ITrabajador
        {
            // Create
            Task<ObjectId> Create(Trabajador trabajador);

            // Read
            Task<Trabajador> Get(ObjectId objectId);

            // Update
            Task<bool> Update(ObjectId objectId, Trabajador trabajador);

            // Delete
            Task<bool> Delete(ObjectId objectId);
        }
    


}
