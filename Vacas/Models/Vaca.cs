using System;
namespace Vacas.Models;

public class Vaca
{
    public long Id { get; set; }
    public string? Raza { get; set; }
    public double? Peso { get; set; }
    public double? Edad { get; set; }
    public bool Vivo { get; set; }
}
