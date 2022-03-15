using Examen01_v1.Models;

namespace Examen01_v1;
// El juego consistirá en simular el lanzamiento de dos dados (dados de 6).
// El jugador deberá iniciar con un monto de dinero inicial ($300).
// El jugador podrá apostar la cantidad de dinero que quiera en sus apuestas, siempre
// y cuando sean múltiplos de 10.
// El jugador podrá elegir una de 4 formas diferentes de apostar:
// 1. Apostar a un número específico (2-12), que multiplicará su apuesta por 10.
// 2. Apostar a que el número es un extremo (2, 3, 4, 10, 11 ó 12), que multiplicará su apuesta por 8.
// 3. Apostar a que el número es un medio (5, 6, 7, 8 ó 9), que multiplicará su apuesta por 4.
// 4. Apostar si el número será par o impar, que multiplicará su apuesta por 2.
// El juego almacenará cada tirada realizada y el jugador podrá revisar el historial de tiradas.
// El jugador podrá revisar las siguientes estadísticas de sus tiradas:
// 1. Balance.
// 2. Cantidad de tiradas realizadas.
// 3. Número que más veces se ha tirado
// 4. Número que menos veces se ha tirado.
// 5. Cantidad de resultados extremos
// 6. Cantidad de resultados medios
// 7. Cantidad de resultados pares
// 8. Cantidad de resultados impares
// El jugador podrá retirarse en el momento que quiera y al final se le deberá mostrar
// un mensaje que le muestre cuánto dinero ganó o perdió, según sea el caso.
// En caso de que el jugador se quede sin dinero, el juego terminará automáticamente.

public class JuegoDeDados
{
    private int _dado1;
    private int _dado2;
    private Jugador _jugador;
    private List<string> _historial;
    
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
    private int _cantidadExtremosGanados = 0;
    private int _cantidadExtremosPerdidos = 0;
    private int _cantidadMedios = 0;
    private int _cantidadMediosGanados = 0;
    private int _cantidadMediosPerdidos = 0;
    private int _cantidadPares = 0;
    private int _cantidadParesGanados = 0;
    private int _cantidadParesPerdidos = 0;
    private int _cantidadImpares = 0;
    private int _cantidadImparesGanados = 0;
    private int _cantidadImparesPerdidos = 0;


    public JuegoDeDados(Jugador jugador)
    {
        _jugador = jugador;
        _historial = new List<string>();
        _dado1 = 0;
        _dado2 = 0;
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
        double porcentajeEfectividad = 0;
        if (_cantidadTiradas > 0)
        {
            porcentajeEfectividad = (_numeroDeTiradasGanadas / _cantidadTiradas) * 100;
        }
        Console.WriteLine("-> Porcentaje de efectividad: " + Math.Round(porcentajeEfectividad, 2) + "%");
        Console.WriteLine("----- Estadisticas de extremos ------");
        Console.WriteLine("-> Cantidad de extremos: " + _cantidadExtremos);
        Console.WriteLine("-> Cantidad de extremos ganados: " + _cantidadExtremosGanados);
        Console.WriteLine("-> Cantidad de extremos perdidos: " + _cantidadExtremosPerdidos);
        Console.WriteLine("------ Estadisticas de medios -------");
        Console.WriteLine("-> Cantidad de medios: " + _cantidadMedios);
        Console.WriteLine("-> Cantidad de medios ganados: " + _cantidadMediosGanados);
        Console.WriteLine("-> Cantidad de medios perdidos: " + _cantidadMediosPerdidos);
        Console.WriteLine("------- Estadisticas de pares ----------");
        Console.WriteLine("-> Cantidad de pares: " + _cantidadPares);
        Console.WriteLine("-> Cantidad de pares ganados: " + _cantidadParesGanados);
        Console.WriteLine("-> Cantidad de pares perdidos: " + _cantidadParesPerdidos);
        Console.WriteLine("------ Estadisticas de impares ------");
        Console.WriteLine("-> Cantidad de impares: " + _cantidadImpares);
        Console.WriteLine("-> Cantidad de impares ganados: " + _cantidadImparesGanados);
        Console.WriteLine("-> Cantidad de impares perdidos: " + _cantidadImparesPerdidos);
        Console.WriteLine("Presione 'Enter' para continuar...");
        Console.ReadLine();
        ShowMenuPrincipal();
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
                //ApostarParImpar();
                break;
            case 5:
                ShowMenuPrincipal();
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
            _cantidadMediosGanados++;
            _gananciasTotales += apuesta * 4;
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
            _cantidadMediosPerdidos++;
            _perdidasTotales += apuesta;
        }
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
            _cantidadExtremosGanados++;
            _gananciasTotales += apuesta * 8;
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
            _cantidadExtremosPerdidos++;
            _perdidasTotales += apuesta;
        }
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
        _cantidadTiradas++;
        if (numeroEspecifico == _dado1 + _dado2)
        {
            _jugador.CantiadDeDinero += apuesta * 10;
            Console.WriteLine("--- Apuesta a un número específico (2-12) ---");
            Console.WriteLine("-> Valor apostado: " + numeroEspecifico);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + (_dado1 + _dado2));
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
        }
        else
        {
            _jugador.CantiadDeDinero -= apuesta;
            Console.WriteLine("--- Apuesta a un número específico (2-12) ---");
            Console.WriteLine("-> Valor apostado: " + numeroEspecifico);
            Console.WriteLine("-> Dado1: " + _dado1 + ", Dado2: " + _dado2);
            Console.WriteLine("-> Valor de los dados: " + (_dado1 + _dado2));
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
            _perdidasTotales += apuesta;
        }
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
}