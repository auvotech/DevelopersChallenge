using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AuvoContext : DbContext

    {
        public AuvoContext(DbContextOptions<AuvoContext> option) : base(option)
        {
            
        }

        public DbSet<Transacao> Transacao { get; set; }

    }

}
