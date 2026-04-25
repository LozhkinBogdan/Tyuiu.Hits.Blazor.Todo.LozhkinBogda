namespace Tyuiu.Hits.Blazor.Todo.LozhkinBogdan.Models;

public class Supply
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}