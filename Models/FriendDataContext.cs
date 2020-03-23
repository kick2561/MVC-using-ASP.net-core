using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class FriendDataContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        public FriendDataContext(DbContextOptions<FriendDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
