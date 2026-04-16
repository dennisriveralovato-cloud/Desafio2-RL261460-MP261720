using System;
using System.Collections.Generic;

namespace Desafio2_Ejercicio1_Ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                int opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        JugarAhorcado();
                        break;
                    case 2:
                        MostrarInstrucciones();
                        break;
                    case 3:
                        salir = true;
                        Console.WriteLine("¡Gracias por jugar! Hasta pronto.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione 1, 2 o 3.");
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        ///<summary>
        /// Muestra el menú principal del juego
        ///</summary>
        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("     JUEGO DEL AHORCADO");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Ver instrucciones");
            Console.WriteLine("3. Salir");
            Console.WriteLine("====================================");
            Console.Write("Seleccione una opción (1-3): ");
        }

        ///<summary>
        /// Lee y valida la opción del menú principal
        ///</summary>
        static int LeerOpcionMenu()
        {
            string input = Console.ReadLine()?.Trim() ?? "";
            if (int.TryParse(input, out int opcion) && opcion >= 1 && opcion <= 3)
            {
                return opcion;
            }
            return 0;
        }
        ///<summary>
        /// Muestra las instrucciones del juego 
        ///</summary>
        static void MostrarInstrucciones()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("     INSTRUCCIONES DEL JUEGO");
            Console.WriteLine("====================================");
            Console.WriteLine("I Se selecciona automáticamente una palabra de un banco de 10 palabras.");
            Console.WriteLine("II Debes adivinar la palabra ingresando una letra a la vez.");
            Console.WriteLine("III La palabra se muestra con guiones (_) para las letras no descubiertas.");
            Console.WriteLine("IV Tienes máximo 6 intentos (dibujo del ahorcado se actualiza).");
            Console.WriteLine("V No puedes repetir letras ya usadas.");
            Console.WriteLine("VI Solo se aceptan letras del alfabeto (A-Z).");
            Console.WriteLine("VII Ganas si descubres toda la palabra antes de los 6 intentos.");
            Console.WriteLine("VIII Pierdes si se completan los 6 intentos (se revela la palabra).");
            Console.WriteLine("IX Al final de cada partida puedes elegir jugar de nuevo.");
            Console.WriteLine("====================================");
            Console.WriteLine("Presione Enter para volver al menú...");
            Console.ReadLine();
        }
        ///<summary>
        /// Función principal del juego del Ahorcado
        ///</summary>
        static void JugarAhorcado()
        {
            // Banco de 10 palabras
            string[] bancoPalabras = 
            {
                "AHORCADO", "PROGRAMA", "VECTOR",   "FUNCION", 
                "CONSOLA",  "ALGORITMO", "ESTRUCTURA", "VALIDAR",
                "INTENTOS", "DIBUJO"
            };

            Random random = new Random();
            bool jugarDeNuevo = true;

            while (jugarDeNuevo)
            {
                // Selección automática de 1 palabra 
                string palabraSecreta = bancoPalabras[random.Next(bancoPalabras.Length)].ToUpper();

                // Vector unidimensional para mostrar el estado de la palabra
                char[] palabraMostrada = new char[palabraSecreta.Length];
                for (int i = 0; i < palabraMostrada.Length; i++)
                {
                    palabraMostrada[i] = '_';
                }

                List<char> letrasUsadas = new List<char>(); // Para mostrar letras ya ingresadas
                int intentosFallidos = 0;
                const int MAX_INTENTOS = 6;
                bool haGanado = false;

                // Bucle principal del juego
                while (intentosFallidos < MAX_INTENTOS && !haGanado)
                {
                    Console.Clear();

                    // Mostrar dibujo del ahorcado actualizado
                    DibujarAhorcado(intentosFallidos);

                    // Mostrar estado de la palabra con guiones
                    Console.WriteLine("\nPalabra: " + new string(palabraMostrada));

                    // Mostrar letras ya ingresadas
                    Console.WriteLine("Letras usadas: " + (letrasUsadas.Count > 0 ? string.Join(", ", letrasUsadas) : "Ninguna"));

                    // Mostrar intentos restantes
                    Console.WriteLine($"Intentos restantes: {MAX_INTENTOS - intentosFallidos}/6");

                    Console.Write("\nIngresa una letra: ");
                    string entrada = Console.ReadLine()?.Trim().ToUpper() ?? "";

                    // Validación: letra válida y no usada antes
                    if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
                    {
                        Console.WriteLine("ERROR: Debe ingresar una sola letra del alfabeto (A-Z).");
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        continue;
                    }

                    char letra = entrada[0];

                    if (letrasUsadas.Contains(letra))
                    {
                        Console.WriteLine("ERROR: Esa letra ya fue usada anteriormente.");
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        continue;
                    }

                    // Registrar la letra usada
                    letrasUsadas.Add(letra);

                    // Verificar si la letra está en la palabra
                    bool acierto = false;
                    for (int i = 0; i < palabraSecreta.Length; i++)
                    {
                        if (palabraSecreta[i] == letra)
                        {
                            palabraMostrada[i] = letra;
                            acierto = true;
                        }
                    }

                    if (!acierto)
                    {
                        intentosFallidos++;
                    }

                    // Verificar si ganó
                    haGanado = !new string(palabraMostrada).Contains("_");
                }

                // Mostrar resultado final
                Console.Clear();
                DibujarAhorcado(intentosFallidos);
                Console.WriteLine("\nPalabra: " + new string(palabraMostrada));

                if (haGanado)
                {
                    Console.WriteLine("\n¡FELICIDADES! ¡Has ganado!");
                }
                else
                {
                    Console.WriteLine("\n¡LO SENTIMOS! Has perdido.");
                    Console.WriteLine($"La palabra secreta era: {palabraSecreta}");
                }

                Console.WriteLine("Letras usadas: " + string.Join(", ", letrasUsadas));

                // Preguntar si quiere jugar de nuevo
                Console.Write("\n¿Quieres jugar de nuevo? (si/no): ");
                string respuesta = Console.ReadLine()?.Trim().ToLower() ?? "";
                jugarDeNuevo = (respuesta == "si");
            }

            Console.WriteLine("\nVolviendo al menú principal...");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
