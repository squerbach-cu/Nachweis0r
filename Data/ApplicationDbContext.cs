using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nachweis0r.Models;

namespace Nachweis0r.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<NotesModel> Notes { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
}