using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperMvaWepForm.Models
{
    public class AlbumContext : DbContext
    {
        public AlbumContext (DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public DbSet<SuperMvaWepForm.Models.Album> Album { get; set; }
    }
}
