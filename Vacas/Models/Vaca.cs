using MongoDB.Bson;
using System;
namespace Vacas.Models;

public class Vaca
{
    public ObjectId Id { get; set; }
    public string? Raza { get; set; }
    public double? Peso { get; set; }
    public double? Edad { get; set; }
    public bool Vivo { get; set; }
    public ObjectId HistoriaVac {  get; set; }
    public ObjectId InfoParto { get; set; }
}
