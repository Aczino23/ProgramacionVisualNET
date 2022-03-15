// See https://aka.ms/new-console-template for more information

using Examen01_v1;
using Examen01_v1.Models;

// Jugador
Jugador jugador = new Jugador(1, "Juan", 500);

// inicializar el juego
JuegoDeDados juegoDados = new JuegoDeDados(jugador);
juegoDados.ShowMenuPrincipal();