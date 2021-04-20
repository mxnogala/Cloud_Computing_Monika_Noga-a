using Microsoft.EntityFrameworkCore;
using PeopleStorageApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleStorageApp.Web
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> PeopleMobile { get; set; }
    }
}
