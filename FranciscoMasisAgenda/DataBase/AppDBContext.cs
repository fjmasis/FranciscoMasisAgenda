using FranciscoMasisAgenda.Model;
using Microsoft.EntityFrameworkCore;

namespace FranciscoMasisAgenda.DataBase

{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Agenda> agendas { get; set; } //sirve para dar el comportamiento de los datos de la tabla 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>().HasKey(x => x.IdContacto); // especifico a llave primaria
        }
    }
}
