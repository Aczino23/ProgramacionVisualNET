namespace Examen01_v1.Models;

public class Jugador
{
    private int _id;
    private String _nickName;
    private double _cantiadDeDinero;
    
    public Jugador(int id, String nickName, double cantiadDeDinero)
    {
        this._id = id;
        this._nickName = nickName;
        this._cantiadDeDinero = cantiadDeDinero;
    }
    
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    
    public String NickName
    {
        get { return _nickName; }
        set { _nickName = value; }
    }
    
    public double CantiadDeDinero
    {
        get { return _cantiadDeDinero; }
        set { _cantiadDeDinero = value; }
    }
    
    public override string ToString()
    {
        return "Id: " + _id + ", NickName: " + _nickName + ", Cantiad De Dinero: " + _cantiadDeDinero;
    }
}