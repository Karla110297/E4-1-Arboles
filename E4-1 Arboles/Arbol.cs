using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_1_Arboles
{
   public class Arbol
    {
        class Nodo
        {
            public int info;
            public Nodo izquierda, derecha;
        }
        private Nodo raiz;
        private int cant;
        private int altura;

        public Arbol()
        {
            raiz = null;
        }

        public void Insertar(int info)
        {
            if (!Existe(info))
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
                    Nodo anterior = null, reco;
                    reco = raiz;
                    while (reco != null)
                    {
                        anterior = reco;
                        if (info < reco.info)
                            reco = reco.izquierda;
                        else
                            reco = reco.derecha;
                    }
                    if (info < anterior.info)
                        anterior.izquierda = nuevo;
                    else
                        anterior.derecha = nuevo;
                }
            }
        }

        public bool Existe(int info)
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                if (info == reco.info)
                    return true;
                else
                    if (info > reco.info)
                    reco = reco.derecha;
                else
                    reco = reco.izquierda;
            }
            return false;
        }

      

        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.info + " ");
                ImprimirPre(reco.izquierda);
                ImprimirPre(reco.derecha);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
            Console.WriteLine();
        }


        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izquierda);
                Console.Write(reco.info + " ");
                ImprimirEntre(reco.derecha);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);
            Console.WriteLine();
        }
        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izquierda);
                ImprimirPost(reco.derecha);
                Console.Write(reco.info + " ");
            }
        }

        public void ImprimirPost()
        {
            ImprimirPost(raiz);
            Console.WriteLine();
        }


        private void Cantidad(Nodo reco)
        {
            if (reco != null)
            {
                cant++;
                Cantidad(reco.izquierda);
                Cantidad(reco.derecha);
            }
        }

        public int Cantidad()
        {
            cant = 0;
            Cantidad(raiz);
            return cant;
        }

        private void CantidadNodosHoja(Nodo reco)
        {
            if (reco != null)
            {
                if (reco.izquierda == null && reco.derecha == null)
                    cant++;
                CantidadNodosHoja(reco.izquierda);
                CantidadNodosHoja(reco.derecha);
            }
        }

        public int CantidadNodosHoja()
        {
            cant = 0;
            CantidadNodosHoja(raiz);
            return cant;
        }

        private void ImprimirEntreConNivel(Nodo reco, int nivel)
        {
            if (reco != null)
            {
                ImprimirEntreConNivel(reco.izquierda, nivel + 1);
                Console.Write(reco.info + " (" + nivel + ") - ");
                ImprimirEntreConNivel(reco.derecha, nivel + 1);
            }
        }

        public void ImprimirEntreConNivel()
        {
            ImprimirEntreConNivel(raiz, 1);
            Console.WriteLine();
        }

        private void RetornarAltura(Nodo reco, int nivel)
        {
            if (reco != null)
            {
                RetornarAltura(reco.izquierda, nivel + 1);
                if (nivel > altura)
                    altura = nivel;
                RetornarAltura(reco.derecha, nivel + 1);
            }
        }

        public int RetornarAltura()
        {
            altura = 0;
            RetornarAltura(raiz, 1);
            return altura;
        }

        public void MayorValorl()
        {
            if (raiz != null)
            {
                Nodo reco = raiz;
                while (reco.derecha != null)
                    reco = reco.derecha;
                Console.WriteLine("Mayor valor del árbol:" + reco.info);
            }
        }

        public void BorrarMenor()
        {
            if (raiz != null)
            {
                if (raiz.izquierda == null)
                    raiz = raiz.derecha;
                else
                {
                    Nodo atras = raiz;
                    Nodo reco = raiz.izquierda;
                    while (reco.izquierda != null)
                    {
                        atras = reco;
                        reco = reco.izquierda;
                    }
                    atras.izquierda = reco.derecha;
                }
            }
        }
    }
}
