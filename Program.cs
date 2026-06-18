using System;
using System.Collections.Generic;

GestorInventario miAlmacen = new GestorInventario();

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

        Producto nuevoProducto = new Producto(id, nombre, cantidad, precio);
        miAlmacen.AgregarProducto(nuevoProducto);
        
        Console.WriteLine("\n¡Producto agregado correctamente al inventario!");
    }
}

public class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    public Producto(int idProducto, string nombre, int cantidad, decimal precio)
    {
        IdProducto = idProducto;
        Nombre = nombre;
        Cantidad = cantidad;
        Precio = precio;
    }
}

public class GestorInventario
{
    private Dictionary<int, Producto> productos;

    public GestorInventario()
    {
        productos = new Dictionary<int, Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        if (!productos.ContainsKey(producto.IdProducto))
        {
            productos.Add(producto.IdProducto, producto);
        }
    }

    public void EliminarProducto(int idProducto)
    {
        if (productos.ContainsKey(idProducto))
        {
            productos.Remove(idProducto);
        }
    }

    public void ActualizarCantidad(int idProducto, int nuevaCantidad)
    {
        if (productos.ContainsKey(idProducto))
        {
            productos[idProducto].Cantidad = nuevaCantidad;
        }
    }

    public Producto ObtenerProducto(int idProducto)
    {
        if (productos.ContainsKey(idProducto))
        {
            return productos[idProducto];
        }
        return null;
    }
}