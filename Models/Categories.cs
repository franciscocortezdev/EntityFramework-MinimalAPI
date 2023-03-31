
using System.Text.Json.Serialization;

namespace CursoEntityFramework.Models;

public class Categories{
  public int Id {get; set;}

  public string? Name {get; set;}
  public string? Description {get; set;}

  public List<Tasks>? Tasks { get; set; }

}