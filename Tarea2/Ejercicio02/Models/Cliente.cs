namespace Ejercicio02;

public class Cliente
{
    private int _idCliente;
    private string _nombre;
    private string _apellido;
    private string _direccion;
    private string _telefono;
    
    public Cliente(int idCliente, string nombre, string apellido, string direccion, string telefono)
    {
        this._idCliente = idCliente;
        this._nombre = nombre;
        this._apellido = apellido;
        this._direccion = direccion;
        this._telefono = telefono;
    }
    
    public int IdCliente
    {
        get { return _idCliente; }
        set { _idCliente = value; }
    }
    
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }
    
    public string Apellido
    {
        get { return _apellido; }
        set { _apellido = value; }
    }
    
    public string Direccion
    {
        get { return _direccion; }
        set { _direccion = value; }
    }
    
    public string Telefono
    {
        get { return _telefono; }
        set { _telefono = value; }
    }
    
    public override string ToString()
    {
        return "Id_Cliente: " + _idCliente + 
               "\nNombre: " + _nombre + 
               "\nApellido: " + _apellido + 
               "\nDireccion: " + _direccion + 
               "\nTelefono: " + _telefono + "\n";
    }
}