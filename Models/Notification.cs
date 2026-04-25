namespace Tyuiu.Hits.Blazor.Todo.LozhkinBogdan.Models;

public class Notification
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Message { get; set; } = "";
    public DateTime Date { get; set; }
}