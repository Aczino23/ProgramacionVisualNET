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
        Console.Clear();
        int opcionSeleccionada = 0;
        do
        {
            Console.WriteLine("--- MENU PRINCIPAL DE LA TIENDA ---");
            Console.WriteLine("1) Administrar Productos");
            Console.WriteLine("2) Administrar Clientes");
            Console.WriteLine("3) Administrar Ventas");
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

    private void showMenuVentas()
    {
        Console.Clear();
        int opcionSeleccionada = 0;
        do
        {
            Console.WriteLine("--- Administración de Ventas ---");
            Console.WriteLine("1) Listar Ventas");
            Console.WriteLine("2) Realizar Venta");
            Console.WriteLine("3) Informe De Ventas");
            Console.WriteLine("4) Regresar...");
            Console.Write("Seleccione una opción: ");
        } while (!validaMenu(4, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                Console.WriteLine("--- Listado de Ventas ---");
                listarVentas();
                Console.WriteLine("Presione 'Enter' para continuar...");
                Console.ReadLine();
                showMenuVentas();
                break;
            case 2:
                if (_clientes.Count == 0 || _productos.Count == 0)
                {
                    Console.WriteLine("No hay clientes o productos registrados, presione 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuVentas();
                }
                else
                {
                    realizarVenta();
                }
                break;
            case 3:
                informeVentas();
                break;
            case 4:
                showMenuPrincipal();
                break;
        }
    }

    private void informeVentas()
    {
        // bucara el producto mas vendido
        double ganancias = 0;

        Console.WriteLine("Total de ventas realizadas: {0}", _ventas.Count);
        
        // obtener la galancia total
        foreach (Venta venta in _ventas)
        {
            ganancias += venta.Total;
        }
        Console.WriteLine("Ganancias totales: ${0}", ganancias);
        
        // contar los cada producto vendido y su cantidad vendida y mostrarlo
        Dictionary<Producto, int> productosVendidos = new Dictionary<Producto, int>();
        foreach (Venta venta in _ventas)
        {
            foreach (Producto producto in _productos)
            {
                if (venta.Producto == producto)
                {
                    if (productosVendidos.ContainsKey(producto))
                    {
                        productosVendidos[producto]++;
                    }
                    else
                    {
                        productosVendidos.Add(producto, 1);
                    }
                }
            }
        }
        Console.WriteLine("--- Ventas realizadas por producto ---");
        foreach (KeyValuePair<Producto, int> producto in productosVendidos)
        {
            Console.WriteLine("{0}: {1} ventas", producto.Key.Nombre, producto.Value);
        }
        Console.WriteLine("Presione 'Enter' para continuar...");
        Console.ReadLine();
        showMenuVentas();
    }

    private void realizarVenta()
    {
        int? idCliente;
        int? idProducto;
        double totalVenta = 0;

        listarClientes();
        idCliente = pedirValorInt("Seleccione al cliente");
        Cliente? clienteVen = _clientes.FirstOrDefault(c => c.IdCliente == idCliente);
        if (clienteVen != null)
        {
            Console.Clear();
            listarProductos();
            idProducto = pedirValorInt("Seleccione el producto");
            Producto? productoVen = _productos.FirstOrDefault(p => p.Id_producto == idProducto);
            if (productoVen != null)
            {
                Console.Clear();
                Console.WriteLine("Cantidad en stock: {0}", productoVen.Cantidad);
                Console.WriteLine("Cliente seleccionado: " + clienteVen.Nombre + " " + clienteVen.Apellido);
                Console.WriteLine("Producto seleccionado: " + productoVen.Nombre);
                int cantidad = pedirValorInt("Ingrese la cantidad a vender");
                if (cantidad > 0 && cantidad <= productoVen.Cantidad)
                {
                    // Se realiza el calculo del total de la venta
                    totalVenta = productoVen.Precio * cantidad;
                    Console.WriteLine("Total a pagar: $" + totalVenta);
                    // obtener la feccha actual
                    DateTime fecha = DateTime.Now;
                    // Se crea la venta
                    Venta venta = new Venta(_ventas.Count + 1, clienteVen, productoVen, cantidad, totalVenta, fecha);
                    _ventas.Add(venta);
                    // Se actualiza la cantidad de productos
                    productoVen.Cantidad -= cantidad;
                    Console.WriteLine("Venta realizada con éxito, presione 'Enter' para continuar...");
                }
                else
                {
                    Console.WriteLine("La cantidad ingresada no es válida, presione 'Enter' para continuar...");
                }
               
            }
            else
            {
                Console.WriteLine("Producto no encontrado, presione 'Enter' para continuar...");
                
            }
        }
        else
        {
            Console.WriteLine("Cliente no encontrado, presione 'Enter' para continuar...");
        }
        Console.ReadLine();
        showMenuVentas();
    }

    private void listarVentas()
    {
        if (_ventas.Count > 0)
        {
            foreach (Venta venta in _ventas)
            {
                Console.WriteLine(venta.ToString());
            }
        }
        else
        {
            Console.WriteLine("No hay ventas registradas");
        }
    }

    private void showMenuClientes()
    {
        Console.Clear();
        int opcionSeleccionada = 0;
        do
        {
            Console.WriteLine("--- Administración de Clientes ---");
            Console.WriteLine("1) Listar Clientes");
            Console.WriteLine("2) Agregar Cliente");
            Console.WriteLine("3) Editar Cliente");
            Console.WriteLine("4) Eliminar Cliente");
            Console.WriteLine("5) Regresar...");
            Console.Write("Seleccione una opción: ");
        } while (!validaMenu(5, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                Console.WriteLine("--- Listado de Clientes ---");
                listarClientes();
                Console.WriteLine("Presione 'Enter' para continuar...");
                Console.ReadLine();
                showMenuClientes();
                break;
            case 2:
                agregarCliente();
                break;
            case 3:
                editarCliente();
                break;
            case 4:
                eliminarCliente();
                break;
            case 5:
                showMenuPrincipal();
                break;
        }
    }

    private void eliminarCliente()
    {
        Console.Clear();
        int? id;
        listarClientes();
        id = pedirValorInt("Ingrese el ID del cliente a eliminar");
        Cliente? clienteEliminar = _clientes.FirstOrDefault(c => c.IdCliente == id);
        if (clienteEliminar != null)
        {
            _clientes.Remove(clienteEliminar);
            Console.WriteLine("Cliente eliminado correctamente, presione 'Enter' para continuar...");
        }
        else
        {
            Console.WriteLine("No se encontró el cliente, presione 'Enter' para continuar...");
        }
        Console.ReadLine();
        showMenuClientes();
    }

    private void editarCliente()
    {
        int? id;
        string? nombre;
        string? apellido;
        string? direccion;
        string? telefono;
        listarClientes();
        id = pedirValorInt("Ingrese el ID del cliente a editar");
        Cliente? clienteEditar = _clientes.FirstOrDefault(c => c.IdCliente == id);
        if (clienteEditar == null)
        {
            Console.WriteLine("No se encontró el cliente, presione 'Enter' para continuar...");
            
        }
        else
        {
            nombre = pedirValorString("Ingrese el nombre del cliente");
            apellido = pedirValorString("Ingrese el apellido del cliente");
            direccion = pedirValorString("Ingrese la dirección del cliente");
            telefono = pedirValorString("Ingrese el teléfono del cliente");
            clienteEditar.Nombre = nombre;
            clienteEditar.Apellido = apellido;
            clienteEditar.Direccion = direccion;
            clienteEditar.Telefono = telefono;
            Console.WriteLine("Cliente editado correctamente, presione 'Enter' para continuar...");
        }
        Console.ReadLine();
        showMenuClientes();
    }

    private void agregarCliente()
    {
        string? nombre;
        string? apellido;
        string? direccion;
        string? telefono;
        
        Console.Write("--- Agregar Cliente ---\n");
        nombre = pedirValorString("Nombre del cliente");
        apellido = pedirValorString("Apellido del cliente");
        direccion = pedirValorString("Dirección del cliente");
        telefono = pedirValorString("Teléfono del cliente");
        Cliente? nuevoCliente = new Cliente(_clientes.Count() + 1,nombre, apellido, direccion, telefono);
        _clientes.Add(nuevoCliente);
        Console.WriteLine("Cliente agregado con éxito, presione 'Enter' para continuar...");
        Console.ReadLine();
        showMenuClientes();
    }

    private void listarClientes()   
    {
        if (_clientes.Count > 0)
        {
            Console.WriteLine("--- Listado de Clientes ---");
            foreach (Cliente cliente in _clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }
        else
        {
            Console.WriteLine("No hay clientes registrados");
        }
    }

    private void showMenuProductos()
    { 
        Console.Clear();
        int opcionSeleccionada = 0;
        do
        {
            Console.WriteLine("--- Adminstración de Productos ---");
            Console.WriteLine("1) Listar Productos");
            Console.WriteLine("2) Agregar Producto");
            Console.WriteLine("3) Editar Producto");
            Console.WriteLine("4) Eliminar Producto");
            Console.WriteLine("5) Regresar...");
            Console.Write("Seleccione una opción: ");
        } while (!validaMenu(5, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                Console.WriteLine("--- Listado de Productos ---");
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

    private void eliminarProducto()
    {
        int? id;
        listarProductos();
        id = pedirValorInt("Ingrese el ID del producto a eliminar");
        if (id != null)
        {
            Producto? producto = _productos.Find(x => x.Id_producto == id);
            if (producto != null)
            {
                _productos.Remove(producto);
                Console.WriteLine("Producto eliminado correctamente, presione 'Enter' para continuar...");
            }
            else
            {
                Console.WriteLine("No se encontró el producto, presione 'Enter' para continuar...");
            }
        }
        Console.ReadLine();
        showMenuProductos();
        
    }

    private void editarProducto()
    {
        int? id;
        string? nombre;
        float precio;
        int cantidad;
        string? categoria;
        listarProductos();
        id = pedirValorInt("Ingrese el ID del producto a editar");
        Producto? productoEditar = _productos.FirstOrDefault(p => p.Id_producto == id);
        if (productoEditar == null)
        {
            Console.WriteLine("No se encontró el producto, presione 'Enter' para continuar...");
          
        }
        else
        {
            nombre = pedirValorString("Ingrese el nombre del producto");
            precio = pedirValorFloat("Ingrese el precio del producto");
            cantidad = pedirValorInt("Ingrese la cantidad del producto");
            categoria = pedirValorString("Ingrese la categoria del producto");
            productoEditar.Nombre = nombre;
            productoEditar.Precio = precio;
            productoEditar.Cantidad = cantidad;
            productoEditar.Categoria = categoria;
            Console.WriteLine("Producto editado correctamente, presione 'Enter' para continuar...");
        }
        Console.ReadLine();
        showMenuProductos();
    }

    private void agregarProducto()
    {
        string? nombre;
        float precio;
        int cantidad;
        string? categoria;
        Console.Write("--- Agregar Producto ---" + "\n");
        nombre = pedirValorString("Nombre del producto");
        precio = pedirValorFloat("Precio del producto");
        cantidad = pedirValorInt("Cantidad del producto");
        categoria = pedirValorString("Categoria del producto");
        Producto nuevoProducto = new Producto(_productos.Count() + 1, nombre, precio, cantidad, categoria);
        _productos.Add(nuevoProducto);
        Console.WriteLine("Producto agregado exitosamente, presione 'Enter' para continuar...");
        Console.ReadLine();
        showMenuProductos();
    }

    private void listarProductos()
    {
        Console.WriteLine("--- Lista de Productos ---");
        if (_productos.Count > 0)
        {
            foreach (Producto producto in _productos)
            {
                Console.WriteLine(producto.ToString());
            }
        }
        else
        {
            Console.WriteLine("No hay productos registrados");
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
                if (valor < 0 )
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

    public void inicializarDatos()
    {
        // Creamos varios productos para probar el programa
        Producto producto1 = new Producto(1, "Leche", 20f, 10, "Alimento");
        Producto producto2 = new Producto(2, "Arroz", 10.5f, 20, "Alimento");
        Producto producto3 = new Producto(3, "Jabon", 5.5f, 5, "Limpieza");
        Producto producto4 = new Producto(4, "Cloro", 12.5f, 3, "Limpieza");
        Producto producto5 = new Producto(5, "Café", 20.39f, 15, "Alimento");
        
        // agregamos los productos a la lista
        _productos.Add(producto1);
        _productos.Add(producto2);
        _productos.Add(producto3);
        _productos.Add(producto4);
        _productos.Add(producto5);
        
        // Creamos varios clientes para probar
        Cliente cliente1 = new Cliente(1, "Juan", "Perez", "Zacatecas", "4927896464");
        Cliente cliente2 = new Cliente(2, "Pedro", "Gonzalez", "Sinaloa", "8787590834");
        Cliente cliente3 = new Cliente(3, "Ana", "Lopez", "Chihuahua", "758790834");
        
        // agregamos los clientes a la lista
        _clientes.Add(cliente1);
        _clientes.Add(cliente2);
        _clientes.Add(cliente3);
        
        // Inzializamos algunos ventas de prueba
        double totalVenta1 = producto1.Precio * 5;
        Venta venta1 = new Venta(1, cliente1, producto1, 5, totalVenta1, DateTime.Now);
        producto1.Cantidad -= 5;
        
        double totalVenta2 = producto1.Precio * 2;
        Venta venta2 = new Venta(2, cliente2, producto1, 2, totalVenta2, DateTime.Now);
        producto1.Cantidad -= 2;
        
        double totalVenta3 = producto2.Precio * 3;
        Venta venta3 = new Venta(3, cliente3, producto2, 3, totalVenta3, DateTime.Now);
        producto2.Cantidad -= 3;
        
        double totalVenta4 = producto3.Precio * 1;
        Venta venta4 = new Venta(4, cliente1, producto3, 1, totalVenta4, DateTime.Now);
        producto3.Cantidad -= 1;
        
        // agregamos las ventas a la lista
        _ventas.Add(venta1);
        _ventas.Add(venta2);
        _ventas.Add(venta3);
        _ventas.Add(venta4);
    }
}