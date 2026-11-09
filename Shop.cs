namespace ShoeShop;

public class Shop
{
    private readonly List<Shoe> _catalog = new();
    private readonly List<CartItem> _cart = new();
    private int _nextId = 1;

    public IReadOnlyList<Shoe> Catalog => _catalog;
    public IReadOnlyList<CartItem> Cart => _cart;

    public void SeedDemoData()
    {
        AddShoe("Nike", "Air Max 90", 42, 12990m, 5);
        AddShoe("Adidas", "Ultraboost 22", 43, 15990m, 3);
        AddShoe("Puma", "Suede Classic", 41, 7490m, 8);
        AddShoe("New Balance", "574", 44, 9990m, 2);
        AddShoe("Ecco", "Soft 7", 40, 13490m, 4);
    }

    public Shoe AddShoe(string brand, string model, int size, decimal price, int stock)
    {
        var shoe = new Shoe
        {
            Id = _nextId++,
            Brand = brand,
            Model = model,
            Size = size,
            Price = price,
            Stock = stock
        };
        _catalog.Add(shoe);
        return shoe;
    }

    public bool AddToCart(int shoeId, int quantity)
    {
        var shoe = _catalog.FirstOrDefault(s => s.Id == shoeId);
        if (shoe == null || quantity <= 0 || quantity > shoe.Stock) return false;

        var existing = _cart.FirstOrDefault(c => c.Shoe.Id == shoeId);
        if (existing != null) existing.Quantity += quantity;
        else _cart.Add(new CartItem { Shoe = shoe, Quantity = quantity });

        shoe.Stock -= quantity;
        return true;
    }

    public bool RemoveFromCart(int shoeId)
    {
        var item = _cart.FirstOrDefault(c => c.Shoe.Id == shoeId);
        if (item == null) return false;

        item.Shoe.Stock += item.Quantity;
        _cart.Remove(item);
        return true;
    }

    public decimal CartTotal() => _cart.Sum(c => c.Total);

    public void ClearCart()
    {
        foreach (var item in _cart) item.Shoe.Stock += item.Quantity;
        _cart.Clear();
    }
}