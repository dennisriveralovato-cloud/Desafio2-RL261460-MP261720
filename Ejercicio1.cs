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
