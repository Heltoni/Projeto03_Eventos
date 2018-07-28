using Microsoft.EntityFrameworkCore;
using Projeto03_Eventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto03_Eventos.Dados
{
    public class EventosContext : DbContext
    {

        public EventosContext(DbContextOptions<EventosContext> opcoes) : base(opcoes){}
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Evento>().ToTable("TBEventos");
            modelBuilder.Entity<Participante>().ToTable("TBParticipantes");
        }
    }
}
