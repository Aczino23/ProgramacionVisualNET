namespace Ejercicio01
{
    internal class Pelicula
    {
        private string _id_pelicula;
        private string _nombre;
        private string _genero;
        private string _director;
        private int _anio;
        
        public Pelicula(string id_pelicula, string nombre, string genero, string director, int anio)
        {
            this._id_pelicula = id_pelicula;
            this._nombre = nombre;
            this._genero = genero;
            this._director = director;
            this._anio = anio;
        }
        
        public string Id_pelicula
        {
            get { return _id_pelicula; }
            set { _id_pelicula = value; }
        }
        
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        
        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }
        
        public string Director
        {
            get { return _director; }
            set { _director = value; }
        }
        
        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        public override string ToString()
        {
            return "Id pelicula: " + _id_pelicula + 
                   "\nNombre: " + _nombre + 
                   "\nGenero: " + _genero + 
                   "\nDirector: " + _director + 
                   "\nAño: " + _anio + "\n";
        }
    }    
}
