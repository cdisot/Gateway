using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solution.Models;

    public class dddContext : DbContext
    {
        public dddContext (DbContextOptions<dddContext> options)
            : base(options)
        {
        }

        public DbSet<Solution.Models.GatewayDto> GatewayDto { get; set; }
    }
