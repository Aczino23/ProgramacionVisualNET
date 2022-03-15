using Examen01_v1.Models;

namespace Examen01_v1;
public class JuegoDeDados
{
    // dados
    private int _dado1;
    private int _dado2;
    
    // jugador
    private Jugador _jugador;
    
    // lista para guardar el historial de jugadas
    private List<string> _historial;
    
    // lista para guardar los resultados de cada tirada
    private List<int> _resultados;
    
    // cantidad de dinero inicial del jugador
    private double _cantidadDeDineroInicial;
    
    // arreglo para almacenar los numeros de cada tipo de apuesta
    private int[] _valoresEspecificos = {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    private int[] _valoresExtremos = {2, 3, 4, 10, 11, 12};
    private int[] _valoresMedios = {5, 6, 7, 8, 9};
        
   // variables para las estadisticas
    private int _gananciasTotales;
    private int _perdidasTotales;
    private double _cantidadTiradas = 0;
    private double _numeroDeTiradasGanadas = 0;
    private int _numeroDeTiradasPerdidas = 0;
    private int _cantidadExtremos = 0;
    private int _cantidadMedios = 0;
    private int _cantidadPares = 0;
    private int _cantidadImpares = 0;


    public JuegoDeDados(Jugador jugador)
    {
        _jugador = jugador;
        _historial = new List<string>();
        _resultados = new List<int>();
        _dado1 = 0;
        _dado2 = 0;
        _cantidadDeDineroInicial = _jugador.CantiadDeDinero;
    }

    public void ShowMenuPrincipal()
    {
        int opcionSeleccionada = 0;
        Console.Clear();
        do
        {
            Console.WriteLine("--- Bienvenido al juego de dados ---");
            Console.WriteLine("1) Comenzar juego");
            Console.WriteLine("2) Ver historial de tiradas");
            Console.WriteLine("3) Ver estadisticas");
            Console.WriteLine("4) Salir");
            Console.Write("Seleccione una opcion: ");
        } while (!validaMenu(4, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                Console.WriteLine("--- Bienvenido al juego de dados: " + _jugador.NickName+ " ---");
                ComenzarJuego();
                break;
            case 2:
                if (_historial.Count == 0)
                {
                    Console.WriteLine("No hay historial de tiradas");
                }
                else
                {
                   VerHistorial();
                }
                Console.WriteLine("Presione 'Enter' para continuar...");
                Console.ReadLine();
                ShowMenuPrincipal();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("--- Estadisticas del juego ---");
                VerEstadisticas();
                break;
            case 4:
                Console.WriteLine("--- Gracias por jugar " + _jugador.NickName + " ---");
                Console.WriteLine("Dinero inicial: " + _cantidadDeDineroInicial);
                Console.WriteLine("Dinero final: " + _jugador.CantiadDeDinero);
                // calculara la ganancia o perdida
                if (_jugador.CantiadDeDinero > _cantidadDeDineroInicial)
                {
                    Console.WriteLine("Ganancia: " + (_jugador.CantiadDeDinero - _cantidadDeDineroInicial));
                }
                else
                {
                    Console.WriteLine("Perdida: " + (_cantidadDeDineroInicial - _jugador.CantiadDeDinero));
                }
                break;
        }
        
    }

    private void VerEstadisticas()
    {
        Console.WriteLine("-> Dinero Actual: " + _jugador.CantiadDeDinero);
        Console.WriteLine("-> Ganancias totales: " + _gananciasTotales);
        Console.WriteLine("-> Perdidas totales: " + _perdidasTotales);
        Console.WriteLine("-> Cantidad de tiradas: " + _cantidadTiradas);
        Console.WriteLine("-> Cantidad de tiradas ganadas: " + _numeroDeTiradasGanadas);
        Console.WriteLine("-> Cantidad de tiradas perdidas: " + _numeroDeTiradasPerdidas);
        Console.WriteLine("-> Número que más veces se ha tirado: " + ValorMasTirado());
        Console.WriteLine("-> Número que menos veces se ha tirado: " + ValorMenosTirado());
        double porcentajeEfectividad = 0;
        if (_cantidadTiradas > 0)
        {
            porcentajeEfectividad = (_numeroDeTiradasGanadas / _cantidadTiradas) * 100;
        }
        Console.WriteLine("-> Porcentaje de efectividad: " + Math.Round(porcentajeEfectividad, 2) + "%");
        Console.WriteLine("-> Cantidad de resultados extremos: " + _cantidadExtremos);
        Console.WriteLine("-> Cantidad de resultados medios: " + _cantidadMedios);
        Console.WriteLine("-> Cantidad de resultados pares: " + _cantidadPares);
        Console.WriteLine("-> Cantidad de resultados impares: " + _cantidadImpares);
        Console.WriteLine("Presione 'Enter' para continuar...");
        Console.ReadLine();
        ShowMenuPrincipal();
    }
    
    private int ValorMasTirado()
    {
        int dos, tres, cuatro, cinco, seis;
        int siete, ocho, nueve, diez, once, doce;
        dos = tres = cuatro = cinco = seis = 0;
        siete = ocho = nueve = diez = once = doce = 0;
        
        // recorrer la lista _resultados y contar que numero es el mas tirado
        if (_resultados.Count > 0)
        {
            foreach (var resultado in _resultados)
            {
                switch (resultado)
                {
                    case 2:
                        dos++;
                        break;
                    case 3:
                        tres++;
                        break;
                    case 4:
                        cuatro++;
                        break;
                    case 5:
                        cinco++;
                        break;
                    case 6:
                        seis++;
                        break;
                    case 7:
                        siete++;
                        break;
                    case 8:
                        ocho++;
                        break;
                    case 9:
                        nueve++;
                        break;
                    case 10:
                        diez++;
                        break;
                    case 11:
                        once++;
                        break;
                    case 12:
                        doce++;
                        break;
                }
            }
            // comparar los valores y devolver el mas tirado 
            if (dos > tres && dos > cuatro && dos > cinco && dos > seis && dos > siete && dos > ocho && dos > nueve && dos > diez && dos > once && dos > doce)
            {
                return 2;
            }
            else if (tres > dos && tres > cuatro && tres > cinco && tres > seis && tres > siete && tres > ocho && tres > nueve && tres > diez && tres > once && tres > doce)
            {
                return 3;
            }
            else if (cuatro > dos && cuatro > tres && cuatro > cinco && cuatro > seis && cuatro > siete && cuatro > ocho && cuatro > nueve && cuatro > diez && cuatro > once && cuatro > doce)
            {
                return 4;
            }
            else if (cinco > dos && cinco > tres && cinco > cuatro && cinco > seis && cinco > siete && cinco > ocho && cinco > nueve && cinco > diez && cinco > once && cinco > doce)
            {
                return 5;
            }
            else if (seis > dos && seis > tres && seis > cuatro && seis > cinco && seis > siete && seis > ocho && seis > nueve && seis > diez && seis > once && seis > doce)
            {
                return 6;
            }
            else if (siete > dos && siete > tres && siete > cuatro && siete > cinco && siete > seis && siete > ocho && siete > nueve && siete > diez && siete > once && siete > doce)
            {
                return 7;
            }
            else if (ocho > dos && ocho > tres && ocho > cuatro && ocho > cinco && ocho > seis && ocho > siete && ocho > nueve && ocho > diez && ocho > once && ocho > doce)
            {
                return 8;
            }
            else if (nueve > dos && nueve > tres && nueve > cuatro && nueve > cinco && nueve > seis && nueve > siete && nueve > ocho && nueve > diez && nueve > once && nueve > doce)
            {
                return 9;
            }
            else if (diez > dos && diez > tres && diez > cuatro && diez > cinco && diez > seis && diez > siete && diez > ocho && diez > nueve && diez > once && diez > doce)
            {
                return 10;
            }
            else if (once > dos && once > tres && once > cuatro && once > cinco && once > seis && once > siete && once > ocho && once > nueve && once > diez && once > doce)
            {
                return 11;
            }
            else if (doce > dos && doce > tres && doce > cuatro && doce > cinco && doce > seis && doce > siete && doce > ocho && doce > nueve && doce > diez && doce > once)
            {
                return 12;
            }
            else
            {
                return 0;
            }
        } 
        else
        {
            return 0;
        }
    }
    
    private object ValorMenosTirado()
    {
        int dos, tres, cuatro, cinco, seis;
        int siete, ocho, nueve, diez, once, doce;
        dos = tres = cuatro = cinco = seis = 0;
        siete = ocho = nueve = diez = once = doce = 0;

        return 0;
    }

    private void VerHistorial()
    {
        Console.WriteLine("--- Historial de tiradas ---");
        foreach (string tirada in _historial)
        {
            Console.WriteLine(tirada + "\n");
        }
    }

    private void ComenzarJuego()
    {
        Console.Clear();
        string respuesta = "";
        if (_jugador.CantiadDeDinero >= 300 )
        {
            do
            {
                respuesta = pedirValorString(_jugador.NickName + " ¿Deseas Jugar? (S/N)");
                respuesta = respuesta.ToUpper();
            } while (respuesta != "S" && respuesta != "N");
            Console.Clear();
            switch (respuesta)
            {
                case "S":
                    if (_jugador.CantiadDeDinero >= 10)
                    {
                        ShowMenuDeApuestas();
                    }
                    else
                    {
                        Console.WriteLine(_jugador.NickName + " no tiene suficiente dinero para apostar, su saldo es de: $" 
                                                            + _jugador.CantiadDeDinero);
                        Console.WriteLine("Presione 'Enter' para continuar...");
                        Console.ReadLine();
                        ShowMenuPrincipal();
                    }
                    break;
                case "N":
                    Console.WriteLine("--- Gracias por jugar " + _jugador.NickName + " ---");
                    Console.WriteLine("Presione 'Enter' para continuar...");
                    Console.ReadLine();
                    ShowMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }

    private void ShowMenuDeApuestas()
    {
        int opcionSeleccionada = 0;
        do
        {
            Console.WriteLine("--- ¿Qué Tipo de Apuesta Desea Hacer? ---");
            Console.WriteLine("1) Apostar a un número específico (2-12). x10");
            Console.WriteLine("2) Apostar a que el número es un extremo (2, 3, 4, 10, 11 ó 12). x8");
            Console.WriteLine("3) Apostar a que el número es un medio (5, 6, 7, 8 ó 9). x4");
            Console.WriteLine("4) Apostar si el número será par o impar. x2");
            Console.WriteLine("5) Regresar...");
            Console.Write("Seleccione una opcion: ");
        } while (!validaMenu(5, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                if (_jugador.CantiadDeDinero >= 10)
                {
                    Console.WriteLine("--- Apuesta a un número específico (2-12) ---");
                    Console.WriteLine("-> Cantidad de dinero disponible: $" + _jugador.CantiadDeDinero);
                    ApostarNumeroEspecifico();
                }
                else
                {
                    Console.WriteLine(_jugador.NickName + " no tiene suficiente dinero para apostar, su saldo es de: $"
                                                        + _jugador.CantiadDeDinero);
                    Console.WriteLine("Presione 'Enter' para continuar...");
                    Console.ReadLine();
                    ShowMenuPrincipal();
                }
                break;
            case 2:
                if (_jugador.CantiadDeDinero >= 10)
                {
                    Console.WriteLine("--- Apuesta a que el número sea un extremo ---");
                    Console.WriteLine("-> Cantidad de dinero disponible: $" + _jugador.CantiadDeDinero);
                    ApostarExtremo();
                }
                else
                {
                    Console.WriteLine(_jugador.NickName + " no tiene suficiente dinero para apostar, su saldo es de: $"
                                                        + _jugador.CantiadDeDinero);
                    Console.WriteLine("Presione 'Enter' para continuar...");
                    Console.ReadLine();
                    ShowMenuPrincipal();
                }
                break;
            case 3:
                if (_jugador.CantiadDeDinero >= 10)
                {
                    Console.WriteLine("--- Apostar a que el número es un medio ---");
                    Console.WriteLine("-> Cantidad de dinero disponible: $" + _jugador.CantiadDeDinero);
                    ApostarMedio();
                }
                else
                {
                    Console.WriteLine(_jugador.NickName + " no tiene suficiente dinero para apostar, su saldo es de: $"
                                                        + _jugador.CantiadDeDinero);
                    Console.WriteLine("Presione 'Enter' para continuar...");
                    Console.ReadLine();
                    ShowMenuPrincipal();
                }
                break;
            case 4:
                if (_jugador.CantiadDeDinero >= 10)
                {
                    Console.WriteLine("--- Apostar a que el número sea par o impar ---");
                    Console.WriteLine("-> Cantidad de dinero disponible: $" + _jugador.CantiadDeDinero);
                    ApostarParImpar();
                }
                else
                {
                    Console.WriteLine(_jugador.NickName + " no tiene suficiente dinero para apostar, su saldo es de: $"
                                                        + _jugador.CantiadDeDinero);
                    Console.WriteLine("Presione 'Enter' para continuar...");
                    Console.ReadLine();
                    ShowMenuPrincipal();
                }
                break;
            case 5:
                ShowMenuPrincipal();
                break;
        }
    }

    private void ApostarParImpar()
    {
        Console.Clear();
        int opcionSeleccionada = 0;
        do
        {
            Console.WriteLine("--- ¿Qué tipo de apuesta desea hacer? ---");
            Console.WriteLine("1) Par");
            Console.WriteLine("2) Impar");
            Console.WriteLine("3) Regresar...");
            Console.Write("Seleccione una opcion: ");
        } while (!validaMenu(3, ref opcionSeleccionada));
        Console.Clear();
        switch (opcionSeleccionada)
        {
            case 1:
                Console.WriteLine("--- Apostar a que el número sea par ---");
                Console.WriteLine("-> Cantidad de dinero disponible: $" + _jugador.CantiadDeDinero);
                ApuestaPar();
                break;
            case 2:
                Console.WriteLine("--- Apostar a que el número sea impar ---");
                Console.WriteLine("-> Cantidad de dinero disponible: $" + _jugador.CantiadDeDinero);
                ApuestaImpar();
                break;
            case 3:
                ShowMenuPrincipal();
                break;
        }
    }

    private void ApuestaImpar()
    {
        int apuesta = 0;
        string respuesta = "";
        string historial = "";
        do
        {
            apuesta = pedirValorInt(_jugador.NickName + " ¿Cuánto deseas apostar?");
        } while (!validaApuesta(apuesta));
        Console.Clear();
        TirarDados();
        int numeroTirado = _dado1 + _dado2;
        _cantidadTiradas++;
        _cantidadImpares++;
        if (numeroTirado % 2 != 0)
        {
            _jugador.CantiadDeDinero += apuesta * 2; 
            Console.WriteLine("--- Apostar a que el número es impar ---");
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + numeroTirado);
            Console.WriteLine("--- ¡Felicidades! ¡Has ganado $" + apuesta * 2 + "! ---");
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es impar" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nApostar: Impar" + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nGanancia: +$" + apuesta * 2;
            _historial.Add(historial);
            _numeroDeTiradasGanadas++;
            _gananciasTotales += apuesta * 2;
            validarNumeroTirado(numeroTirado);
        }
        else
        {
            _jugador.CantiadDeDinero -= apuesta;
            Console.WriteLine("--- Apostar a que el número es impar ---");
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + numeroTirado);
            Console.WriteLine("--- ¡Lo siento! ¡Perdiste! ---, su saldo es de: $" + _jugador.CantiadDeDinero);
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es impar" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nApostar: Par" +
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nPerdida: -$" + apuesta;
            _historial.Add(historial);
            _numeroDeTiradasPerdidas++;
            _perdidasTotales += apuesta;
            validarNumeroTirado(numeroTirado);
        }
        _resultados.Add(numeroTirado);
        do
        {
            respuesta = pedirValorString(_jugador.NickName + " ¿Desea apostar otra vez? (S/N)");
            respuesta = respuesta.ToUpper();
        } while (respuesta != "S" && respuesta != "N");
        Console.Clear();
        switch (respuesta)
        {
            case "S":
                ShowMenuDeApuestas();
                break;
            case "N":
                ShowMenuPrincipal();
                break;
            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }

    private void ApuestaPar()
    {
        int apuesta = 0;
        string respuesta = "";
        string historial = "";
        do 
        { 
            apuesta = pedirValorInt(_jugador.NickName + " ¿Cuánto deseas apostar?");
        } while (!validaApuesta(apuesta));
        Console.Clear();
        TirarDados();
        int numeroTirado = _dado1 + _dado2;
        _cantidadTiradas++;
        _cantidadPares++;
        if (numeroTirado % 2 == 0)
        {
            _jugador.CantiadDeDinero += apuesta * 2; 
            Console.WriteLine("--- Apostar a que el número es par ---");
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + numeroTirado);
            Console.WriteLine("--- ¡Felicidades! ¡Has ganado $" + apuesta * 2 + "! ---");
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es par" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nApostar: Par" + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nGanancia: +$" + apuesta * 2;
            _historial.Add(historial);
            _numeroDeTiradasGanadas++;
            _gananciasTotales += apuesta * 2;
            validarNumeroTirado(numeroTirado);
        }
        else
        {
            _jugador.CantiadDeDinero -= apuesta;
            Console.WriteLine("--- Apostar a que el número es par ---");
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + numeroTirado);
            Console.WriteLine("--- ¡Lo siento! ¡Perdiste! ---, su saldo es de: $" + _jugador.CantiadDeDinero);
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es par" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nApostar: Par" +
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nPerdida: -$" + apuesta;
            _historial.Add(historial);
            _numeroDeTiradasPerdidas++;
            _perdidasTotales += apuesta;
            validarNumeroTirado(numeroTirado);
        }
        _resultados.Add(numeroTirado);
        do
        {
            respuesta = pedirValorString(_jugador.NickName + " ¿Desea apostar otra vez? (S/N)");
            respuesta = respuesta.ToUpper();
        } while (respuesta != "S" && respuesta != "N");
        Console.Clear();
        switch (respuesta)
        {
            case "S":
                ShowMenuDeApuestas();
                break;
            case "N":
                ShowMenuPrincipal();
                break;
            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }

    private void ApostarMedio()
    {
        int numeroApostado = 0;
        int apuesta = 0;
        string respuesta = "";
        string historial = "";
        do
        {
            numeroApostado = pedirValorInt(_jugador.NickName + " ¿Cuál es el número al que desea apostar?");
        } while (!validaNumeroMedio(numeroApostado));
        do
        {
            apuesta = pedirValorInt(_jugador.NickName + " ¿Cuánto deseas apostar?");
        } while (!validaApuesta(apuesta));
        Console.Clear();
        TirarDados();
        int numeroTirado = _dado1 + _dado2;
        _cantidadTiradas++;
        _cantidadMedios++;
        if (numeroApostado == numeroTirado)
        {
            
            _jugador.CantiadDeDinero += apuesta * 4; 
            Console.WriteLine("--- Apostar a que el número es un medio ---");
            Console.WriteLine("-> Valor apostado: " + numeroApostado);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + (_dado1 + _dado2));
            Console.WriteLine("--- ¡Felicidades! ¡Has ganado $" + apuesta * 4 + "! ---");
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es un medio" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nValor apostado: " + numeroApostado + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nGanancia: +$" + apuesta * 4;
            _historial.Add(historial);
            _numeroDeTiradasGanadas++;
            _gananciasTotales += apuesta * 4;
            validarNumeroTirado(numeroTirado);
        }
        else
        {
            _jugador.CantiadDeDinero -= apuesta;
            Console.WriteLine("--- Apostar a que el número es un medio ---");
            Console.WriteLine("-> Valor apostado: " + numeroApostado);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + (_dado1 + _dado2));
            Console.WriteLine("--- ¡Lo siento! ¡Perdiste! ---, su saldo es de: $" + _jugador.CantiadDeDinero);
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es un medio" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nValor apostado: " + numeroApostado + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nPerdida: -$" + apuesta;
            _historial.Add(historial);
            _numeroDeTiradasPerdidas++;
            _perdidasTotales += apuesta;
            validarNumeroTirado(numeroTirado);
        }
        _resultados.Add(numeroTirado);
        do
        {
            respuesta = pedirValorString(_jugador.NickName + " ¿Desea apostar otra vez? (S/N)");
            respuesta = respuesta.ToUpper();
        } while (respuesta != "S" && respuesta != "N");
        Console.Clear();
        switch (respuesta)
        {
            case "S":
                ShowMenuDeApuestas();
                break;
            case "N":
                ShowMenuPrincipal();
                break;
            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }

    private bool validaNumeroMedio(int numeroApostado)
    {
        if (_valoresMedios.Contains(numeroApostado))
        {
            return true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("-> El número ingresado no es un medio. Valores válidos: (5, 6, 7, 8 ó 9)" );
            return false;
        }
    }

    private void ApostarExtremo()
    {
        int numeroApostado = 0;
        int apuesta = 0;
        string respuesta = "";
        string historial = "";
        do
        {
            numeroApostado = pedirValorInt(_jugador.NickName + " ¿Cuál es el número al que desea apostar?");
        } while (!validaNumeroExtremo(numeroApostado));
        do
        {
            apuesta = pedirValorInt(_jugador.NickName + " ¿Cuánto deseas apostar?");
        } while (!validaApuesta(apuesta));
        Console.Clear();
        TirarDados();
        int numeroTirado = _dado1 + _dado2;
        _cantidadTiradas++;
        _cantidadExtremos++;
        if (numeroApostado == numeroTirado)
        {
            
            _jugador.CantiadDeDinero += apuesta * 8; 
            Console.WriteLine("--- Apuesta a que el número sea un extremo ---");
            Console.WriteLine("-> Valor apostado: " + numeroApostado);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + (_dado1 + _dado2));
            Console.WriteLine("--- ¡Felicidades! ¡Has ganado $" + apuesta * 8 + "! ---");
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es un extremo" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nValor apostado: " + numeroApostado + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nGanancia: +$" + apuesta * 8;
            _historial.Add(historial);
            _numeroDeTiradasGanadas++;
            _gananciasTotales += apuesta * 8;
            validarNumeroTirado(numeroTirado);
        }
        else
        {
            _jugador.CantiadDeDinero -= apuesta;
            Console.WriteLine("--- Apuesta a que el número sea un extremo ---");
            Console.WriteLine("-> Valor apostado: " + numeroApostado);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + (_dado1 + _dado2));
            Console.WriteLine("--- ¡Lo siento! ¡Perdiste! ---, su saldo es de: $" + _jugador.CantiadDeDinero);
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número es un extremo" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nValor apostado: " + numeroApostado + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor de tirada: " + numeroTirado + 
                        "\nPerdida: -$" + apuesta;
            _historial.Add(historial);
            _numeroDeTiradasPerdidas++;
            _perdidasTotales += apuesta;
            validarNumeroTirado(numeroTirado);
        }
        _resultados.Add(numeroTirado);
        do
        {
            respuesta = pedirValorString(_jugador.NickName + " ¿Desea apostar otra vez? (S/N)");
            respuesta = respuesta.ToUpper();
        } while (respuesta != "S" && respuesta != "N");
        Console.Clear();
        switch (respuesta)
        {
            case "S":
                ShowMenuDeApuestas();
                break;
            case "N":
                ShowMenuPrincipal();
                break;
            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }

    private bool validaNumeroExtremo(int numeroApostado)
    {
        if (_valoresExtremos.Contains(numeroApostado))
        {
            return true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("-> El número ingresado no es un extremo, Valor válido: (2, 3, 4, 10, 11 ó 12)" );
            return false;
        }
    }

    private void ApostarNumeroEspecifico()
    {
        int numeroEspecifico = 0;
        int apuesta = 0;
        string respuesta = "";
        string historial = "";
        do
        {
            numeroEspecifico = pedirValorInt(_jugador.NickName + " ¿Cuál es el número al que desea apostar? (2-12)");
        } while (!validaNumeroEspecifico(ref numeroEspecifico));
        do
        {
            apuesta = pedirValorInt(_jugador.NickName + " ¿Cuánto deseas apostar?");
        } while (!validaApuesta(apuesta));
        Console.Clear();
        TirarDados();
        int numeroTirado = _dado1 + _dado2;
        _cantidadTiradas++;
        if (numeroEspecifico == numeroTirado)
        {
            _jugador.CantiadDeDinero += apuesta * 10;
            Console.WriteLine("--- Apuesta a un número específico (2-12) ---");
            Console.WriteLine("-> Valor apostado: " + numeroEspecifico);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + numeroTirado);
            Console.WriteLine("--- ¡Felicidades! ¡Has ganado $" + apuesta * 10 + "! ---");
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número específico" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nValor apostado: " + numeroEspecifico + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor aleatorio: " + (_dado1 + _dado2) + 
                        "\nGanancia: +$" + apuesta * 10;
            _historial.Add(historial);
            _numeroDeTiradasGanadas++;
            _gananciasTotales += apuesta * 10;
            validarNumeroTirado(numeroTirado);
        }
        else
        {
            _jugador.CantiadDeDinero -= apuesta;
            Console.WriteLine("--- Apuesta a un número específico (2-12) ---");
            Console.WriteLine("-> Valor apostado: " + numeroEspecifico);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + numeroTirado);
            Console.WriteLine("--- ¡Lo siento! ¡Perdiste! ---, su saldo es de: $" + _jugador.CantiadDeDinero);
            DateTime fecha = DateTime.Now;
            historial = "Tipo de apuesta: Número específico" + 
                        "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                        "\nHora: " + fecha.ToString("HH:mm:ss") + 
                        "\nValor apostado: " + numeroEspecifico + 
                        "\nDado1: " + _dado1 + ", Dado2: " + _dado2 + 
                        "\nValor aleatorio: " + (_dado1 + _dado2) + 
                        "\nPerdida: -$" + apuesta;
            _historial.Add(historial);
            _numeroDeTiradasPerdidas++;
            validarNumeroTirado(numeroTirado);
            _perdidasTotales += apuesta;
        }
        _resultados.Add(numeroTirado);
        do
        {
            respuesta = pedirValorString(_jugador.NickName + " ¿Desea apostar otra vez? (S/N)");
            respuesta = respuesta.ToUpper();
        } while (respuesta != "S" && respuesta != "N");
        Console.Clear();
        switch (respuesta)
        {
            case "S":
                ShowMenuDeApuestas();
                break;
            case "N":
                ShowMenuPrincipal();
                break;
            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }

    private bool validaApuesta(int apuesta)
    {
        if (apuesta > _jugador.CantiadDeDinero)
        {
            Console.WriteLine("-> No tiene suficiente dinero para apostar, su dinero disponible es: $" + _jugador.CantiadDeDinero);
            return false;
        }
        else if (apuesta < 10 )
        {
            
            Console.WriteLine("-> La apuesta debe ser de al menos $10.");
            return false;
        }
        else if (apuesta % 10 != 0)
        {
            Console.Clear();
            Console.WriteLine("-> La apuesta debe ser multiplo de 10.");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void validarNumeroTirado(int numeroTirado)
    {
        if (_valoresExtremos.Contains(numeroTirado))
        {
            _cantidadExtremos++;
        }
        else if (_valoresMedios.Contains(numeroTirado))
        {
            _cantidadMedios++;     
        }
        else if (numeroTirado % 2 == 0)
        {
            _cantidadPares++;
        }
        else
        {
            _cantidadImpares++;
        }
    }

    private bool validaNumeroEspecifico(ref int numeroEspecifico)
    {
        if (_valoresEspecificos.Contains(numeroEspecifico))
        {
            return true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("-> El número especifico no es válido.");
            return false;
        }
    }
    
    private void TirarDados()
    {
        Random rnd = new Random();
        _dado1 = rnd.Next(1, 7);
        _dado2 = rnd.Next(1, 7);
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

    public void inizializarDatos()
    {   
        // Inicializcion de algunos datos para pruebas
        _cantidadTiradas = 15;
        _numeroDeTiradasGanadas = 6;
        _numeroDeTiradasPerdidas = 9;
        _gananciasTotales = 1500;
        _perdidasTotales = 1000;
        
        // historial de tiradas de prueba
        DateTime fecha = DateTime.Now;
        string historial1 = "Tipo de apuesta: Número específico" + 
                    "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                    "\nHora: " + fecha.ToString("HH:mm:ss") + 
                    "\nValor apostado: " + 6 + 
                    "\nDado1: " + 4 + ", Dado2: " + 2 + 
                    "\nValor aleatorio: " + 6 + 
                    "\nGanancia: +$" +  500;
        
        
        string historial2 = "Tipo de apuesta: Número es par" + 
                    "\nFecha: " + fecha.ToString("dd/MM/yyyy") + 
                    "\nHora: " + fecha.ToString("HH:mm:ss") + 
                    "\nApostar: Par" +
                    "\nDado1: " + 5 + ", Dado2: " + 4 + 
                    "\nValor de tirada: " + 9 + 
                    "\nPerdida: -$" + 100;
        
        _historial.Add(historial1);
        _historial.Add(historial2);
        
        // algunos resultados de prueba para los valores que mas se repiten
        _resultados.Add(5);
        _resultados.Add(5);
        _resultados.Add(5);
        
        validarNumeroTirado(5);
        validarNumeroTirado(5);
        validarNumeroTirado(5);
    }
}