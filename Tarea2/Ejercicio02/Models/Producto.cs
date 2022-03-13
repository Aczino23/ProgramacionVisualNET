namespace Ejercicio02;

public class Producto
{
    private int _idProducto;
    private string _nombre;
    private float _precio;
    private int _cantidad;
    private string _categoria;
    
    public Producto(int id, string nombre, float precio, int cantidad, string categoria)
    {
        this._idProducto = id;
        this._nombre = nombre;
        this._precio = precio;
        this._cantidad = cantidad;
        this._categoria = categoria;
    }
    
    public int Id_producto
    {
        get { return _idProducto; }
        set { _idProducto = value; }
    }
    
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }
    
    public float Precio
    {
        get { return _precio; }
        set { _precio = value; }
    }
    
    public int Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }
    
    public string Categoria
    {
        get { return _categoria; }
        set { _categoria = value; }
    }

    public override string ToString()
    {
        return "Id_producto: " + _idProducto + 
               "\nNombre: " + _nombre + 
               "\nPrecio: " + _precio + 
               "\nCantidad: " + _cantidad + 
               "\nCatetgoria: " + _categoria + "\n";
    }
}