using System;
using System.Collections.Generic;

Inventory miInventario = new Inventory();

while (true)
{
    Console.WriteLine("\n--- MENU INVENTARIO ---");
    Console.WriteLine("1. Agregar nuevo producto");
    Console.WriteLine("2. Salir");
    Console.Write("Elige una opcion: ");
    string opcion = Console.ReadLine();

    if (opcion == "2")
    {
        break;
    }
    else if (opcion == "1")
    {
        Console.Write("ID del producto (numero): ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Precio (usa coma para decimales si es necesario): ");
        decimal precio = decimal.Parse(Console.ReadLine());

        Item nuevoProducto = new Item(id, nombre, cantidad, precio);
        miInventario.AddItem(nuevoProducto);
        
        Console.WriteLine("\n¡Producto agregado correctamente al inventario!");
    }
}

public class Item
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Item(int itemId, string name, int quantity, decimal price)
    {
        ItemId = itemId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}

public class Inventory
{
    private Dictionary<int, Item> items;

    public Inventory()
    {
        items = new Dictionary<int, Item>();
    }

    public void AddItem(Item item)
    {
        if (!items.ContainsKey(item.ItemId))
        {
            items.Add(item.ItemId, item);
        }
    }

    public void RemoveItem(int itemId)
    {
        if (items.ContainsKey(itemId))
        {
            items.Remove(itemId);
        }
    }

    public void UpdateQuantity(int itemId, int newQuantity)
    {
        if (items.ContainsKey(itemId))
        {
            items[itemId].Quantity = newQuantity;
        }
    }

    public Item GetItem(int itemId)
    {
        if (items.ContainsKey(itemId))
        {
            return items[itemId];
        }
        return null;
    }
}