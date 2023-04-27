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

    public DbSet<Producto> Dataproducto {get;set;}
    public DbSet<Categoria> Datacategoria {get;set;}
    public DbSet<Boleta> Databoleta {get;set;}
    public DbSet<Registro_usuario> Dataregistro_usuario {get;set;}
}
