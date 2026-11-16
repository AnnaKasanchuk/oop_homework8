using System;
using System.Collections.Generic;
using System.Linq;

class Item
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}

class Order
{
    private readonly List<Item> itemList = new List<Item>();

    public IReadOnlyList<Item> Items => itemList;
    public int ItemCount => itemList.Count;

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void DeleteItem(Item item)
    {
        itemList.Remove(item);
    }

    public decimal CalculateTotalSum()
    {
        return itemList.Sum(i => i.Price);
    }
}

class OrderPrinter
{
    public void PrintOrder(Order order)
    {
        Console.WriteLine("=== Замовлення ===");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"{item.Name}: {item.Price}");
        }
        Console.WriteLine($"Разом: {order.CalculateTotalSum()}");
    }
}

class OrderViewer
{
    public void ShowOrder(Order order)
    {
        Console.WriteLine($"Товарів у замовленні: {order.ItemCount}");
    }
}

interface IOrderRepository
{
    Order Load(int id);
    void Save(Order order);
    void Update(Order order);
    void Delete(Order order);
}

class OrderRepository : IOrderRepository
{
    public Order Load(int id)
    {
        Console.WriteLine($"Завантаження замовлення {id}...");
        return new Order();
    }

    public void Save(Order order)
    {
        Console.WriteLine("Замовлення збережено.");
    }

    public void Update(Order order)
    {
        Console.WriteLine("Замовлення оновлено.");
    }

    public void Delete(Order order)
    {
        Console.WriteLine("Замовлення видалено.");
    }
}

class Program
{
    static void Main()
    {
        var order = new Order();
        order.AddItem(new Item { Name = "Книга", Price = 100m });
        order.AddItem(new Item { Name = "Ручка", Price = 50.5m });

        var viewer = new OrderViewer();
        var printer = new OrderPrinter();
        IOrderRepository repository = new OrderRepository();

        viewer.ShowOrder(order);
        printer.PrintOrder(order);
        repository.Save(order);
    }
}