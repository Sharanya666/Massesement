using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovie.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {

        }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public DbSet<MovieModel> moviemodel { get; set; }
        public DbSet<UserInfo> userInfo {get;set;}
        
       
    }
}