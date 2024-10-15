using ApiRestFullPruebaTecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<ApiMetric> ApiMetrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuramos los estandares de la bd : tablas y campos
            modelBuilder.Entity<Candidato>(entity =>
            {
                //Configuramos correo como index unico
                entity.HasIndex(c => c.Email)
                      .IsUnique();
                      
                        

                //Configuramos los campos para  que no sean nulleables
                entity.Property(c => c.Name)
                      .IsRequired() // Nombre es un campo obligatorio
                      .HasMaxLength(50); 

                entity.Property(c => c.Surname)
                      .IsRequired()// Apellido es un campo obligatorio
                      .HasMaxLength(120); 

                entity.Property(c => c.Email)
                      .IsRequired() // Correo es un campo obligatorio
                      .HasMaxLength(120);

                entity.Property(c => c.PhoneNumber)
                      .IsRequired() // Numero de Telefono es un campo obligatorio
                      .HasMaxLength(13);

                entity.Property(c => c.BirthDate)
                      .IsRequired(); // FechaNacimiento de Telefono es un campo obligatorio

                entity.Property(c => c.AppliedPosition)
                      .IsRequired(); // PuestoAplicado de Telefono es un campo obligatorio


                entity.Property(c => c.DateAppliedPosition) 
                      .IsRequired(); // FechaPuestoAplicado de Telefono es un campo obligatorio
            });
        }

    }
}
