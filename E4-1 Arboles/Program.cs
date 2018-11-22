using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_1_Arboles
{
    class Program
    {
        static void Main(string[] args)
        {

            Arbol arbolBinario = new Arbol();
            arbolBinario.Insertar(100);
            arbolBinario.Insertar(50);
            arbolBinario.Insertar(25);
            arbolBinario.Insertar(75);
            arbolBinario.Insertar(150);
            Console.WriteLine("Impresion preorden: ");
            arbolBinario.ImprimirPreorden();
            Console.WriteLine("Impresion entreorden: ");
            arbolBinario.ImprimirInorden();
            Console.WriteLine("Impresion postorden: ");
            arbolBinario.ImprimirPostorden();
            Console.WriteLine("Cantidad de nodos del árbol:" + arbolBinario.Cantidad());
            Console.WriteLine("Cantidad de nodos hoja:" + arbolBinario.CantidadNodosHoja());
            Console.WriteLine("Impresion en entreorden junto al nivel del nodo.");
            arbolBinario.ImprimirEntreConNivel();
            Console.Write("Artura del arbol:");
            Console.WriteLine(arbolBinario.RetornarAltura());
            arbolBinario.MayorValorl();

            Console.ReadKey();
        }
    }
}
