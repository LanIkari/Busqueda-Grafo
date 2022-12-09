using Grafobuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* INTEGRANTES:

->Avendaño Villegas Brandon
->Rojo Hernandez Andrea Susana
->Trejo Martinez Jorge Joshua

*/
namespace Grafo
{
    public class Grafo
    {
        /*Creamos una lista llamada vertices que contendra todos los vertices de nuestro grafo. De esta forma 
        lo podemos mandar a llamar mas adelante.*/
        private List<Vertice> vertices;

        /*Clase donde creamos el grafo. Debido a que en su mayoria el grafo solo contiene vertices.
        Creamos una variable llamada grafo, que contendra la lista de todos los vertices de nuestro grafo.*/
        public Grafo()
        {
            vertices = new List<Vertice>();
        }

        /*Getter y Setter de nuestra lista vertices.*/
        public List<Vertice> Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }

        /*Comprueba que nuestra lista de vertices este vacia o no.*/
        public bool EstaVacio()
        {
            return vertices.Count == 0;
        }

        /*Validamos que los elementos que se agregan a nuestra lista no se hayan repetido
        si se repiten manda un mensaje a consula, sino lo agrega.*/
        public void AgregarVertice(Vertice vertice)
        {
            if (vertices.Contains(vertice)) Console.WriteLine("¡El vértice ya existe, intenta con otro nombre!");
            else vertices.Add(vertice);
        }

        /*Metodo que nos ayuda a eliminar un elemento de nuestra lista de vertices*/
        public void EliminarVertice(Vertice vABorrar)
        {
            int i = 0;
            foreach (var element in vertices)
            {
                if (element.Equals(vABorrar))
                    break;
                i++;
            }
            Console.WriteLine(i);
            vertices.Remove(vertices.ElementAt(i));
        }

        /*Metodo que utilizamos para mandar a imprimir el grafo completo, osea todos los elementos 
        dentro de nuestra lista vertices*/
        public void imprimeGrafo()
        {
            foreach (var x in vertices)
            {
                Console.WriteLine(x.ToString());
            }
        }

        /*Mandamos a imprimir a consola un elemento en espesifico de nuestra lista vertices*/
        public void imprimeVertices()
        {
            foreach (var x in vertices)
            {
                Console.WriteLine(x.Nombre);
            }
        }

        /*Dado un elemento (vertice) nos devuleve el elemento anterior de nuestra lista de vertices */
        public Vertice GetElementAtPos(int pos)
        {

            return vertices.ElementAt(pos);
        }

        /*Dado un elemento (vertice) nos devuleve el elemento siguiente de nuestra lista de vertices */
        public int obtenerPosicionDe(string nombre)
        {
            int i = 0;
            foreach (var e in vertices)
            {
                if (e.Nombre.Equals(nombre))
                    return i;

                i++;
            }
            return i;
        }

        /*Metodo que comprueba si un numero dado se encuentra dentro de nuestra lista de vertices*/
        public bool Contiene(string nombre)
        {
            foreach (var x in vertices)
            {
                if (x.Nombre.Equals(nombre)) return true;
            }
            return false;
        }

        /*Metodod que comprueba que tanto el nodo inicio y nodo final de la busqueda se encuentren dentro 
        de nuestra lista para posterior a ello, encontrar la secuencia de nodos, en la que cada par de 
        nodos son adyacentes considerando su peso.*/
        public void crearArco(string inicial, string destino, int peso)
        {
            if (Contiene(inicial) && Contiene(destino))
            {
                vertices[obtenerPosicionDe(inicial)].AgregarArco(vertices[obtenerPosicionDe(destino)], peso);
            }
        }

        /*Este metodo nos ayuda a imprimir los elemntos de nuestra lista como si fuera una Pila:
         El primero en entrar es el ultimo en salir*/
        public string imprimePila(Stack<Vertice> e)
        {
            Stack<Vertice> auxy = new Stack<Vertice>();
            auxy = e;
            string aux = "";
            var x = e.GetEnumerator();

            while (x.MoveNext())
            {
                aux += x.Current.Nombre + ", ";
            }
            return aux;
        }

        /*Este metodo nos ayuda a imprimir los elemntos de nuestra lista como si fuera una cola:
         *El primero en entrar es el primero en salir. */
        public string imprimeCola(Queue<Vertice> ex)
        {
            string aux = "";
            var auxy = ex.GetEnumerator();

            while (auxy.MoveNext())
            {
                aux += auxy.Current.Nombre + ", ";
            }
            return aux;
        }

        /*Algoritmo que nos ayuda a buscar y trazar el camino de in noso inicio a un nodo fin con la
        ayuda de la Búsqueda primero mejor*/
        public void BusquedaPrimeroMejor(string inicial, string meta)
        {
            int[,] adyascencias = VARIABLESESTATICAS.MatrizDeAdyascencia;
            List<VerticeConPadre> generados = new List<VerticeConPadre>();
            if (Contiene(inicial) && Contiene(meta))
            {
                int i = obtenerPosicionDe(inicial);
                int z = obtenerPosicionDe(meta);
                Vertice final = vertices[z];
                List<KeyValuePair<Vertice, int>> verticesAbiertos = new List<KeyValuePair<Vertice, int>>();
                List<Vertice> verticesCerrados = new List<Vertice>();
                verticesAbiertos.Add(new KeyValuePair<Vertice, int>(vertices[i], 0));
                KeyValuePair<Vertice, int> mejors = new KeyValuePair<Vertice, int>();
                mejors = verticesAbiertos.Last();
                Vertice ini = new Vertice("");
                do
                {
                    Console.WriteLine("Revisando nodo:" + mejors.Key.Nombre);
                    foreach (var x in mejors.Key.Listuki)
                    {
                        bool esta = false;
                        foreach (var y in verticesAbiertos)
                        {
                            if (x.Key.Nombre.Equals(y.Key.Nombre) || verticesCerrados.Contains(x.Key))
                            {

                                esta = true;
                            }
                        }
                        if (!esta)
                        {
                            verticesAbiertos.Add(x);
                            generados.Add(new VerticeConPadre(mejors.Key, x.Key));
                        }


                    }
                    verticesCerrados.Add(mejors.Key);
                    foreach (var element in verticesCerrados)
                    {
                        Console.WriteLine("Cerrados:" + element.Nombre);
                    }
                    verticesAbiertos.Remove(mejors);
                    foreach (var element in verticesAbiertos)
                    {

                        Console.WriteLine("Abierto: " + element.Key.Nombre);
                    }
                    mejors = verticesAbiertos[0];
                    for (int ex = 0; ex < verticesAbiertos.Count; ex++)
                    {
                        if ((verticesAbiertos[ex].Value + adyascencias[int.Parse(verticesAbiertos[ex].Key.Nombre) - 1, int.Parse(meta) - 1])
                            < mejors.Value + adyascencias[int.Parse(mejors.Key.Nombre) - 1, int.Parse(meta) - 1])
                        {
                            mejors = verticesAbiertos[ex];
                        }
                    }
                    Console.WriteLine("Ahora el mejor es:" + mejors.Key.Nombre);
                    //foreach (var y in verticesAbiertos)
                    //{
                    //    if (y.Value.CompareTo(mejors.Value) < 0)
                    //    {
                    //        mejors = y;
                    //    }
                    //}
                    if (mejors.Key.Nombre.Equals(meta))
                    {
                        ini = mejors.Key;
                        Console.WriteLine("Mira mamá, lo encontré :,v.");
                        break;
                    }



                    Console.ReadKey();
                } while (verticesAbiertos.Count != 1);

                while (ini != null)
                {
                    Console.Write(ini.Nombre + " <- ");
                    if (generados.Where(VerticeConPadre => VerticeConPadre.Hijo.Equals(ini)).Count<VerticeConPadre>() != 0)
                        ini = generados.Where(VerticeConPadre => VerticeConPadre.Hijo.Equals(ini)).First().Papa;
                    else break;
                }
            }

        }

        /*Algoritmo que nos ayuda a buscar y trazar el camino de in noso inicio a un nodo fin con la
        ayuda de la Busqueda en Profundidad*/
        public void BusquedaEnProfundidad(string inicial, string meta)
        {
            if (Contiene(inicial) && Contiene(meta))
            {
                int i = obtenerPosicionDe(inicial);
                int z = obtenerPosicionDe(meta);
                Vertice final = vertices[z];
                Vertice ini = vertices[i];

                Stack<Vertice> abiertos = new Stack<Vertice>();
                Stack<Vertice> cerrados = new Stack<Vertice>();
                List<VerticeConPadre> generados = new List<VerticeConPadre>();
                generados.Add(new VerticeConPadre(ini));
                abiertos.Push(ini);
                bool encontrado = false;
                while (abiertos.Count != 0 && encontrado == false)
                {

                    Console.WriteLine("ABIERTOS:" + imprimePila(abiertos));
                    ini = abiertos.Pop();
                    if (ini.Nombre.Equals(meta))
                    {
                        Console.WriteLine("Lo encontre.");
                        break;
                    }

                    Console.WriteLine("Revisando el nodo: " + ini.Nombre);
                    foreach (var x in ini.Listuki)
                    {
                        cerrados.Push(ini);


                        if (!cerrados.Contains(x.Key) && !abiertos.Contains(x.Key))
                        {
                            generados.Add(new VerticeConPadre(ini, x.Key));
                            abiertos.Push(x.Key);
                            Console.WriteLine(x.Key.Nombre + " Agregado");
                        }


                    }
                }
                while (ini != null)
                {
                    Console.Write(ini.Nombre + " <- ");
                    ini = generados.Where(VerticeConPadre => VerticeConPadre.Hijo.Equals(ini)).First().Papa;
                }




            }
            else
            {
                Console.WriteLine("El nodo inicial, o el final no existen en el gráfo.");
            }
        }

        /*Algoritmo que nos ayuda a buscar y trazar el camino de in noso inicio a un nodo fin con la
        ayuda de la Busqueda a lo ancho*/
        public void BusquedaEnAncho(string inicial, string meta)
        {
            if (Contiene(inicial) && Contiene(meta))
            {
                int i = obtenerPosicionDe(inicial);
                int z = obtenerPosicionDe(meta);
                Vertice final = vertices[z];
                Vertice ini = vertices[i];

                Queue<Vertice> abiertos = new Queue<Vertice>();
                Queue<Vertice> cerrados = new Queue<Vertice>();
                List<VerticeConPadre> generados = new List<VerticeConPadre>();
                generados.Add(new VerticeConPadre(ini));
                abiertos.Enqueue(ini);
                bool encontrado = false;
                while (abiertos.Count != 0 && encontrado == false)
                {
                    Console.WriteLine("ABIERTOS: " + imprimeCola(abiertos));
                    ini = abiertos.Dequeue();
                    if (ini.Nombre.Equals(meta))
                    {
                        Console.WriteLine("Lo encontrè.");
                        break;
                    }
                    Console.WriteLine("Revisando el nodo: " + ini.Nombre);
                    foreach (var x in ini.Listuki)
                    {
                        cerrados.Enqueue(ini);


                        if (!cerrados.Contains(x.Key) && !abiertos.Contains(x.Key))
                        {
                            generados.Add(new VerticeConPadre(ini, x.Key));
                            abiertos.Enqueue(x.Key);
                            Console.WriteLine(x.Key.Nombre + " Agregado");

                        }

                    }
                }
                while (ini != null)
                {
                    Console.Write(ini.Nombre + " <- ");
                    ini = generados.Where(VerticeConPadre => VerticeConPadre.Hijo.Equals(ini)).First().Papa;
                }




            }
            else
            {
                Console.WriteLine("El nodo inicial, o el final no existen en el gráfo.");
            }
        }

        /*Algoritmo que nos ayuda a buscar y trazar el camino de in noso inicio a un nodo fin con la
       ayuda de la Búsqueda escalada máxima pendiente*/
        public void BusquedaCimaMejorada(string inicial, string meta)
        {
            if (Contiene(inicial) && Contiene(meta))
            {
                int i = obtenerPosicionDe(inicial);
                int z = obtenerPosicionDe(meta);
                Vertice final = vertices[z];
                Vertice ini = vertices[i];
                List<Vertice> revisados = new List<Vertice>();
                List<Vertice> ruta = new List<Vertice>();
                int count = 0;
                while (ini != null)
                {
                    if (ruta.Contains(ini))
                    {
                        Console.WriteLine("Bucle infinito. Ruta parcial:");
                        break;
                    }
                    ruta.Add(ini);
                    if (ini.Nombre.Equals(meta))
                    {
                        Console.WriteLine("Lo encontré :D");
                        break;
                    }
                    Console.WriteLine("Lista de: " + ini.Nombre);
                    Vertice mejor = ini.Listuki.First().Key;
                    foreach (var x in ini.Listuki)
                    {
                        Console.WriteLine(x.Key.Nombre + " ->" + meta + " = " + VARIABLESESTATICAS.MatrizDeAdyascencia[int.Parse(x.Key.Nombre) - 1, int.Parse(meta) - 1]);

                        if ((VARIABLESESTATICAS.MatrizDeAdyascencia[int.Parse(mejor.Nombre) - 1, int.Parse(meta) - 1]) > VARIABLESESTATICAS.MatrizDeAdyascencia[int.Parse(x.Key.Nombre) - 1, int.Parse(meta) - 1])
                        {
                            mejor = x.Key;
                        }
                    }
                    Console.WriteLine();
                    ini = mejor;
                    count++;

                }
                foreach (var x in ruta)
                {
                    if (!x.Equals(ruta.Last()))
                        Console.Write(x.Nombre + "-->");
                    else
                        Console.WriteLine(x.Nombre);
                }
                Console.WriteLine();

            }

            else { Console.WriteLine("No existe el nodo inicial, o meta."); }
        }

        /*Algoritmo que nos ayuda a buscar y trazar el camino de in noso inicio a un nodo fin con la
        ayuda de la Búsqueda escalada simple*/
        public void busquedaCima(string inicial, string meta)
        {
            if (Contiene(inicial) && Contiene(meta))
            {
                int i = obtenerPosicionDe(inicial);
                int z = obtenerPosicionDe(meta);
                Vertice final = vertices[z];
                Vertice ini = vertices[i];
                List<Vertice> revisados = new List<Vertice>();
                List<Vertice> ruta = new List<Vertice>();
                int count = 0;
                while (ini != null)
                {
                    if (ruta.Contains(ini))
                    {
                        Console.WriteLine("Bucle infinito. Ruta parcial:");
                        break;
                    }
                    ruta.Add(ini);
                    if (ini.Nombre.Equals(meta))
                    {
                        Console.WriteLine("Lo encontré :D");
                        break;
                    }
                    Console.WriteLine("Lista de: " + ini.Nombre);
                    Vertice mejor = ini.Listuki.First().Key;
                    foreach (var x in ini.Listuki)
                    {
                        Console.WriteLine(x.Key.Nombre + " ->" + meta + " = " + VARIABLESESTATICAS.MatrizDeAdyascencia[int.Parse(x.Key.Nombre) - 1, int.Parse(meta) - 1]);

                        if ((VARIABLESESTATICAS.MatrizDeAdyascencia[int.Parse(mejor.Nombre) - 1, int.Parse(meta) - 1]) > VARIABLESESTATICAS.MatrizDeAdyascencia[int.Parse(x.Key.Nombre) - 1, int.Parse(meta) - 1])
                        {
                            mejor = x.Key;
                        }
                    }
                    Console.WriteLine();
                    ini = mejor;
                    count++;

                }
                foreach (var x in ruta)
                {
                    if (!x.Equals(ruta.Last()))
                        Console.Write(x.Nombre + "-->");
                    else
                        Console.WriteLine(x.Nombre);
                }
                Console.WriteLine();

            }
            else { Console.WriteLine("No existe el nodo inicial, o meta."); }

        }
    }
}
