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
