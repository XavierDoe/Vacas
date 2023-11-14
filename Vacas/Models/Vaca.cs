using MongoDB.Bson;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Vacas.Models;

public class Vaca
{
    public ObjectId Id { get; set; }
    public string? Raza { get; set; }
    public double? Peso { get; set; }
    public double? Edad { get; set; }
    public bool Vivo { get; set; }
    public string Padre { get; set; }
    public string HistoriaVac {  get; set; }
    public string InfoParto { get; set; }
    public string IdVaca => IdVac(Id);
    public String IdVac (ObjectId id)
    {
        return id.ToString();
    }
}
