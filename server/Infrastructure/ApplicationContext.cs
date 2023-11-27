using Microsoft.EntityFrameworkCore;
using UniversityProcessing.API.Infrastructure.Entities;

namespace UniversityProcessing.API.Infrastructure
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}
