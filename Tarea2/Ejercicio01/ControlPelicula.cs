namespace Ejercicio01
{
    internal class ControlPelicula
    {
        private List<Pelicula> _peliculas;

        public ControlPelicula()
        {
            _peliculas = new List<Pelicula>();
        }
        
        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("--- MENU PRINCIPAL: CONTROL DE PELICULAS ---");
                Console.WriteLine("1) Agregar pelicula");
                Console.WriteLine("2) Eliminar pelicula");
                Console.WriteLine("3) Mostrar peliculas");
                Console.WriteLine("4) Salir");
                Console.Write("Ingrese una opcion: ");
            } while (!validarMenu(4, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {
                case 1:
                    agregarPelicula();
                    break;
                case 2:
                    eliminarPeliculaMenu();
                    break;
                case 3:
                    ListarPeliculasMenu();
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
        }

        private void eliminarPeliculaMenu()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {   Console.WriteLine("--- Eliminar pelicula ---");
                Console.WriteLine("1) Accion");
                Console.WriteLine("2) Terror");
                Console.WriteLine("3) Comedia");
                Console.WriteLine("4) Drama");
                Console.WriteLine("5) Regresar...");
                Console.Write("Ingrese una opcion: ");
            } while (!validarMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {
                case 1:
                    eliminarPelicula("Accion");
                    break;
                case 2:
                    eliminarPelicula("Terror");
                    break;
                case 3:
                    eliminarPelicula("Comedia");
                    break;
                case 4:
                    eliminarPelicula("Drama");
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    Console.Clear();
                    eliminarPeliculaMenu();
                    break;
            }
            
        }
        
        private void eliminarPelicula(string genero)
        {
            string? id = null;
            if (_peliculas.FirstOrDefault( p => p.Genero == genero) != null)
            {
                Console.WriteLine("--- Eliminar pelicula De {0} ---", genero);
                mostrarPelicula(genero);
                id = pedirValorString("Ingrese el id de la pelicula a eliminar"); 
                Pelicula? peliculaEliminar = _peliculas.Find(p => p.Id_pelicula == id && p.Genero.Equals(genero)); 
                if (peliculaEliminar != null) 
                { 
                    _peliculas.Remove(peliculaEliminar); 
                    Console.WriteLine($"La pelicula con id: {peliculaEliminar.Id_pelicula} ha sido eliminada"); 
                    Console.WriteLine("Presione 'Enter' para continuar...");
                }
                else 
                { 
                    Console.WriteLine("No se encontro la pelicula, presione 'Enter' para continuar...");
                }
            }
            else
            {
                Console.WriteLine("No hay peliculas de este genero, presione 'Enter' para continuar...");
            }
            Console.ReadLine(); 
            eliminarPeliculaMenu();
        }
        

        private void ListarPeliculasMenu()
        {
            // menu para mostrar peliculas de cada genero
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("--- Mostrar peliculas ---");
                Console.WriteLine("1) Accion");
                Console.WriteLine("2) Terror");
                Console.WriteLine("3) Comedia");
                Console.WriteLine("4) Drama");
                Console.WriteLine("5) Regresar...");
                Console.Write("Ingrese una opcion: ");
            } while (!validarMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {
                case 1:
                    mostrarPelicula("Accion");
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    ListarPeliculasMenu();
                    break;
                case 2:
                    mostrarPelicula("Terror");
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    ListarPeliculasMenu();
                    break;
                case 3:
                    mostrarPelicula("Comedia");
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    ListarPeliculasMenu();
                    break;
                case 4:
                    mostrarPelicula("Drama");
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    ListarPeliculasMenu();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opcion invalida...");
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    ListarPeliculasMenu();
                    break;
            }
        }

        private void mostrarPelicula(string genero)
        {
            genero = genero.ToLower();
            if (_peliculas.Count > 0) 
            {
                // buscar todas las peliculas que coincidan con el genero
                var peliculasGenero = _peliculas.Where(p => p.Genero.ToLower() == genero);
                if (peliculasGenero.Count() > 0)
                {
                    foreach (var pelicula in peliculasGenero)
                    {
                        Console.WriteLine(pelicula.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"No hay peliculas de {genero} registradas");
                }
            }
            else
            {
                Console.WriteLine("No hay peliculas registradas en el sistema");

            }
        }
        
        private void agregarPelicula()
        {
            Console.WriteLine("--- Agregar Pelicula ---");
            
            // variable para los datos de la pelicula
            string? id;
            string? nombre;
            string? genero;
            string? director;
            int anio;
            
            // pedir los datos
            id = pedirValorString("Id");
            nombre = pedirValorString("Nombre");
            genero = pedirValorString("Genero");
            director = pedirValorString("Director");
            anio = pedirValorInt("Año");
            
            // crear la pelicula
            Pelicula nuevaPelicula = new Pelicula(id, nombre, genero, director, anio);
            _peliculas.Add(nuevaPelicula);
            Console.WriteLine("Pelicula creada correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            showMenuPrincipal();
        }
        
        private bool validarMenu(int opciones, ref int opcionSeleccionada)
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

        public void inicializarDatos()
        {
            // peliculas de accion
            Pelicula pelicula1 = new Pelicula("1", "Spider-Man: Sin Camino a Casa", "Accion", "David H. Venghaus Jr.", 2021);
            Pelicula pelicula2 = new Pelicula("2", "Venom 2", "Accion", "Andy Serkis", 2021);
            // peliculas de drama
            Pelicula pelicula3 = new Pelicula("3", "Chernóbil: la película", "Drama", "Danila Kozlovski", 2021);
            Pelicula pelicula4 = new Pelicula("4", "La hija oscura", "Drama", "Maggie Gyllenhaal", 2020);
            // peliculas de comedia
            Pelicula pelicula5 = new Pelicula("5", "The Adam Project", "Comedia", "Shawn Levy", 2022);
            Pelicula pelicula6 = new Pelicula("6", "Marry Me", "Comedia", "Kat Coiro", 2022);
            // peliculas de terror
            Pelicula pelicula7 = new Pelicula("7", "Espíritus oscuros", "Terror", "Scott Cooper", 2021);
            Pelicula pelicula8 = new Pelicula("8", "Separation", "Terror", "William Brent Bell", 1974);
            
            // agregar peliculas
            _peliculas.Add(pelicula1);
            _peliculas.Add(pelicula2);
            _peliculas.Add(pelicula3);
            _peliculas.Add(pelicula4);
            _peliculas.Add(pelicula5);
            _peliculas.Add(pelicula6);
            _peliculas.Add(pelicula7);
            _peliculas.Add(pelicula8);
        }
    }
}