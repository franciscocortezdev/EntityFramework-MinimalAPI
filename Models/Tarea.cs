using System.Text.Json.Serialization;

namespace CursoEntityFramework.Models;

public class Tarea
{
  public enum Prioridad
  {
    Baja, Meida, Alta
  }
  public Guid TareaId { get; set; }


  public Guid CategoriaId { get; set; }

  public string? Titulo { get; set; }
  public string? Descripcion { get; set; }
  public Prioridad PrioridadTarea {get; set;}

  public DateTime FechaCreacion {get;set;}

  public virtual Categoria? Categoria {get; set;}

  [JsonIgnore]
  public string? Resumen {get; set;}
}