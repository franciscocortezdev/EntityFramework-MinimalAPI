using CursoEntityFramework;
using CursoEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos creada ");
});



app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) =>
{


  return Results.Ok(dbContext.Tareas.Include(c => c.Categoria));


});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{

  tarea.TareaId = Guid.NewGuid();
  tarea.FechaCreacion = DateTime.Now;
  await dbContext.AddAsync(tarea);

  await dbContext.SaveChangesAsync();

  return Results.Ok();


});


app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{

  var tareaActual = await dbContext.Tareas.FindAsync(id);

  if (tareaActual != null)
  {

    tareaActual.CategoriaId = tarea.CategoriaId;
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;
    tareaActual.Descripcion = tarea.Descripcion;

    await dbContext.SaveChangesAsync();

    return Results.Ok();

  }
  return Results.NotFound();
});



app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{

  var tareaActual = await dbContext.Tareas.FindAsync(id);

  if (tareaActual != null)
  {
    dbContext.Remove(tareaActual);

    await dbContext.SaveChangesAsync();

    return Results.Ok();

  }
  return Results.NotFound();
});



app.Run();
