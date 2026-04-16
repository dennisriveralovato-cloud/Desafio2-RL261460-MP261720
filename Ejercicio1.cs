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
