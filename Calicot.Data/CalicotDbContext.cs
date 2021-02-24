using Calicot.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calicot.Data
{
    public class CalicotDbContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }

        public CalicotDbContext(DbContextOptions<CalicotDbContext> options) : base(options)
        {
      

        }
    }

}