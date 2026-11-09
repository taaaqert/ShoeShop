using ShoeShop;

var shop = new Shop();
shop.SeedDemoData();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== 🥿 МАГАЗИН ОБУВИ ===");
    Console.WriteLine("1. Каталог");
    Console.WriteLine("2. Добавить в корзину");
    Console.WriteLine("3. Корзина");
    Console.WriteLine("4. Удалить из корзины");
    Console.WriteLine("5. Очистить корзину");
    Console.WriteLine("0. Выход");
    Console.Write("Выбор: ");

    var choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            PrintCatalog(shop);
            break;
        case "2":
            AddToCartFlow(shop);
            break;
        case "3":
            PrintCart(shop);
            break;
        case "4":
            RemoveFromCartFlow(shop);
            break;
        case "5":
            shop.ClearCart();
            Console.WriteLine("Корзина очищена.");
            break;
        case "0":
            //Console.WriteLine("До свидания!");
            return;
        default:
            Console.WriteLine("Неизвестная команда.");
            break;
    }

    Console.WriteLine("\nНажмите Enter...");
    Console.ReadLine();
}

static void PrintCatalog(Shop shop)
{
    Console.WriteLine("--- КАТАЛОГ ---");
    if (shop.Catalog.Count == 0)
    {
        Console.WriteLine("Каталог пуст.");
        return;
    }
    foreach (var shoe in shop.Catalog)
        Console.WriteLine(shoe);
}

static void PrintCart(Shop shop)
{
    Console.WriteLine("--- КОРЗИНА ---");
    if (shop.Cart.Count == 0)
    {
        Console.WriteLine("Корзина пуста.");
        return;
    }
    foreach (var item in shop.Cart)
        Console.WriteLine(item);
    Console.WriteLine($"\nИтого: {shop.CartTotal():C}");
}

static void AddToCartFlow(Shop shop)
{
    PrintCatalog(shop);
    Console.Write("\nID товара: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Некорректный ID.");
        return;
    }
    Console.Write("Количество: ");
    if (!int.TryParse(Console.ReadLine(), out var qty))
    {
        Console.WriteLine("Некорректное количество.");
        return;
    }

    Console.WriteLine(shop.AddToCart(id, qty)
        ? "Добавлено в корзину."
        : "Не удалось добавить (нет на складе или неверные данные).");
}

static void RemoveFromCartFlow(Shop shop)
{
    PrintCart(shop);
    Console.Write("\nID товара для удаления: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Некорректный ID.");
        return;
    }
    Console.WriteLine(shop.RemoveFromCart(id)
        ? "Удалено из корзины."
        : "Такого товара в корзине нет.");
}