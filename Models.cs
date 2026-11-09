namespace ShoeShop;

public class Shoe
{
    public int Id { get; set; }
    public string Brand { get; set; } = "";
    public string Model { get; set; } = "";
    public int Size { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public override string ToString() =>
        $"[{Id}] {Brand} {Model} | размер {Size} | {Price:C} | на складе: {Stock}";
}

public class CartItem
{
    public Shoe Shoe { get; set; } = null!;
    public int Quantity { get; set; }

    public decimal Total => Shoe.Price * Quantity;

    public override string ToString() =>
        $"{Shoe.Brand} {Shoe.Model} (размер {Shoe.Size}) x{Quantity} = {Total:C}";
}