﻿using MongoDB.Bson;

namespace Vacas.Models
{
    public class Inventario
    {
        public ObjectId Id { get; set; }
        public String? NombreArticulo { get; set; }
        public int? Cantidad { get; set; }
    }
}
