using Tyuiu.Hits.Blazor.Todo.LozhkinBogdan.Models;

namespace Tyuiu.Hits.Blazor.Todo.LozhkinBogdan.Services;

public class InventoryService
{
    private readonly List<Product> _products = new();
    private readonly List<Supply> _supplies = new();

    private int _productId = 1;
    private int _supplyId = 1;

    public InventoryService()
    {
        // тестовые данные (можно убрать)
        _products.Add(new Product { Id = _productId++, Name = "Ноутбук", Quantity = 10, MinStockLevel = 3 });
        _products.Add(new Product { Id = _productId++, Name = "Мышь", Quantity = 25, MinStockLevel = 5 });
    }

    // 📌 READ
    public List<Product> GetProducts() => _products;
    public List<Supply> GetSupplies() => _supplies;

    // 📌 CREATE
    public void AddProduct(string name, int quantity, int minStock)
    {
        _products.Add(new Product
        {
            Id = _productId++,
            Name = name,
            Quantity = quantity,
            MinStockLevel = minStock
        });
    }

    // 📌 UPDATE
    public void UpdateProduct(int id, string name, int quantity, int minStock)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return;

        product.Name = name;
        product.Quantity = quantity;
        product.MinStockLevel = minStock;
    }

    // 📌 DELETE
    public void DeleteProduct(int id)
    {
        _products.RemoveAll(p => p.Id == id);
        _supplies.RemoveAll(s => s.ProductId == id);
    }

    // 📦 поставки (оставляем)
    public void AddSupply(int productId, int quantity)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return;

        product.Quantity += quantity;

        _supplies.Add(new Supply
        {
            Id = _supplyId++,
            ProductId = productId,
            Quantity = quantity,
            Date = DateTime.Now
        });
    }
    private readonly List<WriteOff> _writeOffs = new();
private int _writeOffId = 1;

public List<WriteOff> GetWriteOffs() => _writeOffs;

    public void WriteOff(int productId, int quantity)
{
    var product = _products.FirstOrDefault(p => p.Id == productId);
    if (product == null || quantity <= 0) return;

    product.Quantity = Math.Max(0, product.Quantity - quantity);

    if (product.Quantity <= 3)
{
    AddNotification(productId, $"⚠ Критический остаток: {product.Name} ({product.Quantity})");
}
else if (product.Quantity <= product.MinStockLevel)
{
    AddNotification(productId, $"⚠ Низкий остаток: {product.Name} ({product.Quantity})");
}

    _writeOffs.Add(new WriteOff
    {
        Id = _writeOffId++,
        ProductId = productId,
        Quantity = quantity,
        Date = DateTime.Now
    });

    
}
private readonly List<Notification> _notifications = new();
private int _notificationId = 1;

public void AddNotification(int productId, string message)
{
    _notifications.Add(new Notification
    {
        Id = _notificationId++,
        ProductId = productId,
        Message = message,
        Date = DateTime.Now
    });

    
}

public List<Notification> GetNotifications() => _notifications;

    public bool IsLowStock(Product product)
        => product.Quantity <= product.MinStockLevel;
}