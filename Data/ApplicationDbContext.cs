using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LIONFIT.Models;

namespace LIONFIT.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<producto> Dataproducto {get;set;}
    public DbSet<categoria> Datacategoria {get;set;}
    public DbSet<boleta> Databoleta {get;set;}
    public DbSet<registro_usuario> Dataregistro_usuario {get;set;}
}
