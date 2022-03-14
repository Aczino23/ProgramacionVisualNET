namespace Ejercicio02;

public class Venta
{
    private int _idVenta;
    private Cliente _cliente;
    private Producto _producto;
    private int _cantidad;
    private double _total;
    private DateTime _fecha;
    public Venta(int idVenta, Cliente cliente, Producto producto, int cantidad, double total, DateTime fecha)
    {
        this._idVenta = idVenta;
        this._cliente = cliente;
        this._producto = producto;
        this._cantidad = cantidad;
        this._total = total;
        this._fecha = fecha;
    }
    
    public int IdVenta
    {
        get { return _idVenta; }
        set { _idVenta = value; }
    }
    
    public Cliente Cliente
    {
        get { return _cliente; }
        set { _cliente = value; }
    }
    
    public Producto Producto
    {
        get { return _producto; }
        set { _producto = value; }
    }
    
    public int Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }

    public double Total
    {
        get { return _total; }
        set { _total = value; }
    }

    public override string ToString()
    {
        return "Id_Venta: " + _idVenta +
               "\nId_Cliente: " + _cliente.IdCliente +
               "\nId_Producto: " + _producto.Id_producto+
               "\nCantidad_Comprada: " + _cantidad +
               "\nPrecio_Unitario:"  + "$" + _producto.Precio +
               "\nTotal: " + "$" + _total +
               "\nFecha: " + _fecha + "\n";
    }
}