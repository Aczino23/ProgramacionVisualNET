namespace Ejercicio02;

public class Venta
{
    private string _idVenta;
    private string _idCliente;
    private string _idProducto;
    private int _cantidad;
    private double _precio;
    private double _total;
    
    public Venta(string idVenta, string idCliente, string idProducto, int cantidad, double precio, double total)
    {
        this._idVenta = idVenta;
        this._idCliente = idCliente;
        this._idProducto = idProducto;
        this._cantidad = cantidad;
        this._precio = precio;
        this._total = total;
    }
    
    public string IdVenta
    {
        get { return _idVenta; }
        set { _idVenta = value; }
    }
    
    public string IdCliente
    {
        get { return _idCliente; }
        set { _idCliente = value; }
    }
    
    public string IdProducto
    {
        get { return _idProducto; }
        set { _idProducto = value; }
    }
    
    public int Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }
    
    public double Precio
    {
        get { return _precio; }
        set { _precio = value; }
    }
    
    public double Total
    {
        get { return _total; }
        set { _total = value; }
    }
}