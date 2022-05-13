using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevOpsServiceAPI.Models;

namespace DevOpsServiceAPI.Data
{
    public class DevOpsServiceAPIContext : DbContext
    {
        public DevOpsServiceAPIContext (DbContextOptions<DevOpsServiceAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DevOpsServiceAPI.Models.Pension>? Pension { get; set; }
    }
}
