namespace Ejercicio02;

public class ControlTienda
{
    private List<Producto> _productos;
    private List<Cliente> _clientes;
    private List<Venta> _ventas;
    
    public ControlTienda()
    {
        _productos = new List<Producto>();
        _clientes = new List<Cliente>();
        _ventas = new List<Venta>();
    }
    
    public void showMenuPrincipal()
    {
        int opcionSeleccionada = 0;
        Console.Clear();
        do
        {
            Console.WriteLine("1) Administrar Productos");
            Console.WriteLine("2) Administrar Clientes");
            Console.WriteLine("3)Administrar Ventas");
            Console.WriteLine("4) Salir");
            Console.Write("Seleccione una opción: ");
        } while (!validaMenu(4, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                showMenuProductos();
                break;
            case 2:
                showMenuClientes();
                break;
            case 3:
                showMenuVentas();
                break;
            case 4:
                Console.WriteLine("Saliendo...");
                break;
        }
        
    }

    private void showMenuProductos()
    {
        int opcionSeleccionada = 0;
        Console.Clear();
        do
        {
            Console.WriteLine("--- Adminstración de Productos ---");
            Console.WriteLine("1) Listar Productos");
            Console.WriteLine("2) Agregar Producto");
            Console.WriteLine("3) Editar Producto");
            Console.WriteLine("4) Eliminar Producto");
            Console.WriteLine("5) Regresar...");
            Console.Write("Seleccione una opción: ");
        } while (!validaMenu(4, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                listarProductos();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadLine();
                showMenuProductos();
                break;
            case 2:
                agregarProducto();
                break;
            case 3:
                editarProducto();
                break;
            case 4:
                eliminarProducto();
                break;
            case 5:
                showMenuPrincipal();
                break;
        }
    }

    private void editarProducto()
    {
        int id;
        string? nombre;
        float precio;
        int cantidad;
        string? categoria;
        listarProductos();
        Console.WriteLine("--- Editar Producto ---");
        id = pedirValorInt("Ingrese el ID del producto a editar: ");
        Producto? productoEditar = _productos.FirstOrDefault(p => p.Id_producto == id);
        if (productoEditar == null)
        {
            Console.WriteLine("No se encontró el producto con el ID ingresado.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            showMenuProductos();
        }
        else
        {
            nombre = pedirValorString("Ingrese el nombre del producto: ");
            precio = pedirValorFloat("Ingrese el precio del producto: ");
            cantidad = pedirValorInt("Ingrese la cantidad del producto: ");
            categoria = pedirValorString("Ingrese la categoria del producto: ");
            productoEditar.Nombre = nombre;
            productoEditar.Precio = precio;
            productoEditar.Cantidad = cantidad;
            productoEditar.Categoria = categoria;
            Console.WriteLine("Producto editado correctamente, presione una tecla para continuar...");
            Console.ReadLine();
            showMenuProductos();
        }
    }

    private void agregarProducto()
    {
        int id;
        string? nombre;
        float precio;
        int cantidad;
        string? categoria;
        Console.Write("--- Agregar Producto ---");
        id = _productos.Count() + 1;
        nombre = pedirValorString("Nombre del producto");
        precio = pedirValorFloat("Precio del producto");
        cantidad = pedirValorInt("Cantidad del producto");
        categoria = pedirValorString("Categoria del producto");
        Producto nuevoProducto = new Producto(id, nombre, precio, cantidad, categoria);
        _productos.Add(nuevoProducto);
        Console.WriteLine("Producto agregado exitosamente, presione una tecla para continuar...");
        Console.ReadLine();
        showMenuProductos();
    }

    private void listarProductos()
    {
        Console.WriteLine("--- Lista de Productos ---");
        foreach (Producto producto in _productos)
        {
            Console.WriteLine(producto.ToString());
        }
    }

    private bool validaMenu(int opciones, ref int opcionSeleccionada)
    {
        int n;
        if (int.TryParse(Console.ReadLine(), out n))
        {
            if (n <= opciones)
            {
                opcionSeleccionada = n;
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opción Invalida.");
                return false;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("El valor ingresado no es válido, debes ingresar un número.");
            return false;
        }
    }
    
    // Este método se encarga de pedirle al usuario un valor de tipo string y lo devuelve
    private string pedirValorString(string texto)
    {
        string? valor;
        do
        {
            Console.Write($"{texto}: ");
            valor = Console.ReadLine();
            if (valor == null || valor == "")
            {
                Console.WriteLine("Valor inválido.");
            }
        } while (valor == null || valor == "");
        return valor;
    }
        
    // Este método nos ayuda a leer y validar un valor entero
    private int pedirValorInt(string texto)
    {
        int valor;
        do
        {
            Console.Write($"{texto}: ");
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                if (valor < 0)
                {
                    Console.WriteLine("Valor inválido.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        } while (valor < 0);
        return valor;
    }
    
    // Este método nos ayuda a leer y validar un valor flotante
    private float pedirValorFloat(string texto)
    {
        float valor;
        do
        {
            Console.Write($"{texto}: ");
            if (float.TryParse(Console.ReadLine(), out valor))
            {
                if (valor < 0)
                {
                    Console.WriteLine("Valor inválido.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        } while (valor < 0);
        return valor;
    }
    
}

