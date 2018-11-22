using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_1_Arboles
{
   public class Arbol
    {
        class Nodo//se crea una clase nodo con los siguientes atributos
        {
            public int info;
            public Nodo izquierda, derecha;
        }
        private Nodo raiz;
        private int cantidad;
        private int altura;

        public Arbol()
        {
            raiz = null;
        }

        public void Insertar(int info)//se crea un nodo y se guarda la informacion que llega en dicho nodo
        {
            if (!Existe(info)) //accion en caso de que  no exista la info
            {
                Nodo nuevo;
                nuevo = new Nodo();
                nuevo.info = info;
                nuevo.izquierda = null;
                nuevo.derecha = null;
                if (raiz == null)
                    raiz = nuevo;
                else
                {
                    Nodo anterior = null, recorrido;
                    recorrido = raiz;
                    while (recorrido != null)
                    {
                        anterior = recorrido;
                        if (info < recorrido.info)
                            recorrido = recorrido.izquierda;
                        else
                            recorrido = recorrido.derecha;
                    }
                    if (info < anterior.info)
                        anterior.izquierda = nuevo;
                    else
                        anterior.derecha = nuevo;
                }
            }
        }

        public bool Existe(int info)//revisa si la info ya esta en guardadada en nodo y si no es asi depende si la cantidad es mayor o menor para ver en que rama se va a agregar
        {
            Nodo recorrido = raiz;
            while (recorrido != null)
            {
                if (info == recorrido.info)
                    return true;
                else
                    if (info > recorrido.info)
                    recorrido = recorrido.derecha;
                else
                    recorrido = recorrido.izquierda;
            }
            return false;
        }

      

        private void ImprimirPreorden(Nodo recorrido)//recorrido impreso en preorden 
        {
            if (recorrido != null)
            {
                Console.Write(recorrido.info + " ");
                ImprimirPreorden(recorrido.izquierda);
                ImprimirPreorden(recorrido.derecha);
            }
        }

        public void ImprimirPreorden()
        {
            ImprimirPreorden(raiz);
            Console.WriteLine();
        }


        private void ImprimirInorden(Nodo recorrido)//recorrido impreso en Inorden
        {
            if (recorrido != null)
            {
                ImprimirInorden(recorrido.izquierda);
                Console.Write(recorrido.info + " ");
                ImprimirInorden(recorrido.derecha);
            }
        }

        public void ImprimirInorden()
        {
            ImprimirInorden(raiz);
            Console.WriteLine();
        }
        private void ImprimirPostorden(Nodo recorrido)//recorrido impreso en postorden
        {
            if (recorrido != null)
            {
                ImprimirPostorden(recorrido.izquierda);
                ImprimirPostorden(recorrido.derecha);
                Console.Write(recorrido.info + " ");
            }
        }

        public void ImprimirPostorden()
        {
            ImprimirPostorden(raiz);
            Console.WriteLine();
        }


        private void Cantidad(Nodo recorrido)//Contabiliza la cantidad de nodos en arbol de forma recursiva
        {
            if (recorrido != null)
            {
                cantidad++;
                Cantidad(recorrido.izquierda);
                Cantidad(recorrido.derecha);
            }
        }

        public int Cantidad()
        {
            cantidad = 0;
            Cantidad(raiz);
            return cantidad;
        }

        private void CantidadNodosHoja(Nodo recorrido)
        {
            if (recorrido != null)
            {
                if (recorrido.izquierda == null && recorrido.derecha == null)
                    cantidad++;
                CantidadNodosHoja(recorrido.izquierda);
                CantidadNodosHoja(recorrido.derecha);
            }
        }

        public int CantidadNodosHoja()
        {
            cantidad = 0;
            CantidadNodosHoja(raiz);
            return cantidad;
        }

        private void ImprimirEntreConNivel(Nodo recorrido, int nivel)
        {
            if (recorrido != null)
            {
                ImprimirEntreConNivel(recorrido.izquierda, nivel + 1);
                Console.Write(recorrido.info + " (" + nivel + ") - ");
                ImprimirEntreConNivel(recorrido.derecha, nivel + 1);
            }
        }

        public void ImprimirEntreConNivel()
        {
            ImprimirEntreConNivel(raiz, 1);
            Console.WriteLine();
        }

        private void RetornarAltura(Nodo recorrido, int nivel)//Para averiguar la altura del arbol
        {
            if (recorrido != null)
            {
                RetornarAltura(recorrido.izquierda, nivel + 1);//se utiliza recursividad
                if (nivel > altura)
                    altura = nivel;
                RetornarAltura(recorrido.derecha, nivel + 1);
            }
        }

        public int RetornarAltura()
        {
            altura = 0;
            RetornarAltura(raiz, 1);
            return altura;
        }

        public void MayorValorl()//Para imprimir el mayor valor del árbol debemos recorrer siempre por derecha hasta encontrar un nodo que almacene null en derecha
        {
            if (raiz != null)
            {
                Nodo recorrido = raiz;
                while (recorrido.derecha != null)
                    recorrido = recorrido.derecha;
                Console.WriteLine("Mayor valor del árbol:" + recorrido.info);
            }
        }

     
    }
}
