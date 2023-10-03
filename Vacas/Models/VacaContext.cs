using Microsoft.EntityFrameworkCore;

namespace Vacas.Models;

public class VacaContext : DbContext
{
    public VacaContext(DbContextOptions<VacaContext> options)
        : base(options)
    {
    }

    public DbSet<Vaca> Vacas { get; set; } = null!;
}