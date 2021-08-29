using System;
using DockerCores.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerCores
{
    public class CoresContext : DbContext
    {
        public DbSet<Cores> Cores { get; set; }

        public CoresContext(DbContextOptions<CoresContext> options) : base(options)
        {
            
        }
    }
}