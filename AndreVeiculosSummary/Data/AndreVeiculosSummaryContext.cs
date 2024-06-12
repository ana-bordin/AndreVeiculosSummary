using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVeiculosSummary.Data
{
    public class AndreVeiculosSummaryContext : DbContext
    {
        public AndreVeiculosSummaryContext (DbContextOptions<AndreVeiculosSummaryContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Customer> Customer { get; set; } = default!;

        public DbSet<Models.Address>? Address { get; set; }
    }
}
