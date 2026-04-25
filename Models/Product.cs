namespace Tyuiu.Hits.Blazor.Todo.LozhkinBogdan.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Quantity { get; set; }

    // Минимальный уровень для предупреждения
    public int MinStockLevel { get; set; }
}