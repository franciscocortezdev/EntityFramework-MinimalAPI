using CursoEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityFramework;

public class ContextDB : DbContext
{

  public DbSet<Categories> Categories { get; set; } = null!;
  public DbSet<Tasks> Tasks { get; set; } = null!;

  public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Categories>(categoria =>
    {
      categoria.ToTable("Categoria");
      categoria.HasKey(p => p.Id);

      categoria.Property(p => p.Name).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Description);

    });


    modelBuilder.Entity<Tasks>(tarea =>
    {
      tarea.ToTable("Tarea");
      tarea.HasKey(p => p.Id);

      tarea.Property(p => p.Title).IsRequired().HasMaxLength(200);

      tarea.Property(p => p.Description);

      tarea.Property(p => p.CreatedAt);

    });

  }

}
