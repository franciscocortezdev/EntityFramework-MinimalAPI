using CursoEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityFramework;

public class TareasContext : DbContext
{

  public DbSet<Categoria> Categorias { get; set; } = null!;
  public DbSet<Tarea> Tareas { get; set; } = null!;

  public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Categoria> categoriasInit = new List<Categoria>();
    categoriasInit.Add(new Categoria(){CategoriaId = Guid.Parse("42fb1aad174e47b581b7038b6a23da01"), Nombre = "Actividades Pendientes", Peso=20});
    categoriasInit.Add(new Categoria(){CategoriaId = Guid.Parse("42fb1aad174e47b581b7038b6a23da02"), Nombre = "Actividades Personales", Peso=50});


    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("Categoria");
      categoria.HasKey(p=>p.CategoriaId);

      categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p=>p.Descripcion);
      categoria.Property(p=>p.Peso);

      categoria.HasData(categoriasInit);

    });


    List<Tarea> tareasInit = new List<Tarea>();
    tareasInit.Add(new Tarea()
    {
      TareaId = Guid.Parse("42fb1aad174e47b581b7038b6a23da03"),
      CategoriaId = Guid.Parse("42fb1aad174e47b581b7038b6a23da01"),
      PrioridadTarea = Tarea.Prioridad.Meida,
      Titulo = "Pago de servicios publicos",
      FechaCreacion = DateTime.Now
    });
    tareasInit.Add(new Tarea()
    {
      TareaId = Guid.Parse("42fb1aad174e47b581b7038b6a23da04"),
      CategoriaId = Guid.Parse("42fb1aad174e47b581b7038b6a23da02"),
      PrioridadTarea = Tarea.Prioridad.Baja,
      Titulo = "Terminar de ver pelicula",
      FechaCreacion = DateTime.Now
    });




    modelBuilder.Entity<Tarea>(tarea=>{
      tarea.ToTable("Tarea");
      tarea.HasKey(p=>p.TareaId);

      tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);

      tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);

      tarea.Property(p=>p.Descripcion);

      tarea.Property(p=>p.PrioridadTarea);
      tarea.Property(p=>p.FechaCreacion);

      tarea.Ignore(p=>p.Resumen);

      tarea.HasData(tareasInit);

    });

  }

}
