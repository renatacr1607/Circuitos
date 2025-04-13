using Circuitos.Models;
using Microsoft.EntityFrameworkCore;

namespace Circuitos.Data
{
    public class CircuitosContext : DbContext
    { 
        public CircuitosContext(DbContextOptions<CircuitosContext> options) : base(options)
        {
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Circuito> Circuitos { get; set; }

        public DbSet<Volta> Voltas { get; set; }
    }
}
