using System.Text.Json.Serialization;

namespace CursoEntityFramework.Models;

public class Tasks
{
  public int Id { get; set; }

  public string? Title { get; set; }
  public string? Description { get; set; }

  public DateTime CreatedAt {get;set;}

   public int CategoryId { get; set; }
    public Categories? Category { get; set; }


}