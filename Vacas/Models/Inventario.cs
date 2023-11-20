using MongoDB.Bson;

namespace Vacas.Models
{
    public class Inventario
    {
        public ObjectId Id { get; set; }
        public String? NombreArticulo { get; set; }
        public int? Cantidad { get; set; }
        public string IdInventario => IdVac(Id);
        public String IdVac(ObjectId id)
        {
            return id.ToString();
        }
        public String? tipoArticulo { get; set; }
        public String descripcion { get; set; }
        public double? precio { get; set; }
    }
}
