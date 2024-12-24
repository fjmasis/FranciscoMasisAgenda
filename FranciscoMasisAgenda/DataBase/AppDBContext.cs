using FranciscoMasisAgenda.Model;
using Microsoft.EntityFrameworkCore;

namespace FranciscoMasisAgenda.DataBase

{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Agenda> Agendas { get; set; } //sirve para dar el comportamiento de los datos de la tabla 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>().ToTable("Agenda"); 

            modelBuilder.Entity<Agenda>().HasKey(x => x.IdContacto); // especifico a llave primaria


            modelBuilder.Entity<Agenda>().Property(x => x.IdContacto).ValueGeneratedOnAdd(); // autoincremento
        }
    }
}
