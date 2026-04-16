using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Sistema de registro de notas estudiantiles
namespace Desafío#2_Ejercicio2 
{
  internal class Program 
  {
    static void Main(string[] args) 
    {
            // Configuración de la consola (tamaño y colores)
            Console.WindowHeight = 40;
            Console.WindowWidth = 80;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            // Solicita la cantidad de estudiantes
            Console.Write("Ingrese la cantidad de estudiantes a registrar: ");
            int n = int.Parse(Console.ReadLine());

            // Arreglos paralelos para almacenar nombres y notas
            string[] nombres = new string[n];
            double[] notas = new double[n];

            // Llamada a función para ingresar datos
            IngresarDatos(nombres, notas);

            // Cálculos principales
            double promedio = CalcularPromedio(notas);
            double mayor = ObtenerMayor(notas);
            double menor = ObtenerMenor(notas);

            // Mostrar resultados finales
            MostrarReporte(nombres, notas, promedio, mayor, menor);

            Console.ReadKey();
        }

        static void IngresarDatos(string[] nombres, double[] notas)
        {
            // Recorre cada estudiante para ingresar sus datos
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.Write("Nombre del estudiante " + (i + 1) + ": ");
                nombres[i] = Console.ReadLine();

                // Validación de la nota (debe estar entre 0 y 10)
                do
                {
                    Console.Write("Ingrese la nota (0 - 10): ");
                    notas[i] = double.Parse(Console.ReadLine());

                    if (notas[i] < 0 || notas[i] > 10)
                    {
                        Console.WriteLine("Nota inválida, ingrese nuevamente.");
                    }

                } while (notas[i] < 0 || notas[i] > 10);
            }
        }

        static double CalcularPromedio(double[] notas)
        {
            double suma = 0;

            // Suma todas las notas del arreglo
            for (int i = 0; i < notas.Length; i++)
            {
                suma += notas[i];
            }

            // Retorna el promedio
            return suma / notas.Length;
        }

        static double ObtenerMayor(double[] notas)
        {
            double mayor = notas[0];

            // Busca la nota más alta
            for (int i = 0; i < notas.Length; i++)
            {
                if (notas[i] > mayor)
                {
                    mayor = notas[i];
                }
            }

            return mayor;
        }

        static double ObtenerMenor(double[] notas)
        {
            double menor = notas[0];

            // Busca la nota más baja
            for (int i = 0; i < notas.Length; i++)
            {
                if (notas[i] < menor)
                {
                    menor = notas[i];
                }
            }

            return menor;
        }

        static string ConvertirLetra(double nota)
        {
            // Convierte la nota numérica a letra según la escala dada
            if (nota >= 9)
                return "A";
            else if (nota >= 8)
                return "B";
            else if (nota >= 7)
                return "C";
            else if (nota >= 6)
                return "D";
            else
                return "F";
        }

        static void MostrarReporte(string[] nombres, double[] notas, double promedio, double mayor, double menor)
        {
            int aprobados = 0;
            int reprobados = 0;

            Console.WriteLine("\n- REPORTE FINAL DE ESTUDIANTES -");

            // Recorre los estudiantes para mostrar su información
            for (int i = 0; i < nombres.Length; i++)
            {
                string letra = ConvertirLetra(notas[i]);

                // Determina si el estudiante aprueba o reprueba
                string estado;
                if (notas[i] >= 6)
                {
                    estado = "Aprobado";
                    aprobados++;
                }
                else
                {
                    estado = "Reprobado";
                    reprobados++;
                }

                Console.WriteLine(nombres[i] + " - " + notas[i] + " - " + letra + " - " + estado);
            }

            // Resumen final
            Console.WriteLine("\nPromedio: " + promedio);
            Console.WriteLine("Nota mayor: " + mayor);
            Console.WriteLine("Nota menor: " + menor);
            Console.WriteLine("Aprobados: " + aprobados);
            Console.WriteLine("Reprobados: " + reprobados);
        }
    }
}
