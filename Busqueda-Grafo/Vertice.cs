using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* INTEGRANTES:

->Avendaño Villegas Brandon
->Rojo Hernandez Andrea Susana
->Trejo Martinez Jorge Joshua

*/
namespace Grafo
{
    /*Clase que nos ayudara a recorer los elementos de nuestra lista una vez llena de Vertices, 
    y dado el formato de nodo de la clase de VerticeCon Padre. */
    public class Vertice : IComparable
    {
        /*Declaramos las variables de la clase. Es importante notar que creamos un 
        diccionario de vertices llamado listuki*/
        private string nombre;
        private Dictionary<Vertice, int> listuki;

        /*Nuestra clase Vertice recivira un 'nombre', para posterior a ello crear 
        un elemento de tipo vertice en el diccionario*/
        public Vertice(string nombre)
        {
            this.nombre = nombre;
            listuki = new Dictionary<Vertice, int>();
        }
        /*Creamos el Setter y Getter de nuestra variable 'Nombre'*/
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /*Esta clase nos ayudara a mostrar en consola los objetos de tipo vertice 
        que existen dentro de nuestra lista.*/
        public Dictionary<Vertice, int> Listuki
        {
            get { return listuki; }
        }
        /*Clase que se encarga de agregar el nodo destino o final a nuestra lista.
        Este elemento que se agrega es de tipo vertice.*/
        public void AgregarArco(Vertice destino, int peso)
        {


            listuki.Add(destino, peso);

        }


        public override string ToString()
        {
            string aux = "";
            if (listuki.Count == 0)
            {
                aux += nombre + " Sin nodos hijos";
            }
            else
            {
                foreach (var element in listuki)
                {
                    aux += nombre + " -->" + element.Key.nombre + "(" + element.Value + ")\n";
                }
            }
            return aux;
        }
        /*Algoritmo para obtener los nodos hijo de nuestra lista de objetos tipo vertice*/
        public Vertice[] obtenerHijos()
        {
            Vertice[] aux = new Vertice[listuki.Count];
            int i = 0;
            foreach (var element in listuki)
            {
                aux[i] = element.Key;
                i++;
            }

            return aux;
        }

        /*Obtener un objeto vertice de nuestra lista, y retornando el numero de elemnto
        de dicho objeto en la lista. Ademas nos encargamos de validar si existe el
        vertice ingresado*/
        public int getPositionOf(string nombre)
        {
            int i = 0;
            foreach (var v in listuki)
            {
                if (v.Key.nombre.Equals(nombre))
                {
                    return i;
                }
                i++;
            }
            throw new Exception("El elemento no existe");
        }

        /**/
        public KeyValuePair<Vertice, int>[] obtenerArray()
        {
            return listuki.ToArray();
        }

        /**/
        public override bool Equals(object obj)
        {
            var x = (Vertice)obj;

            return x.nombre.Equals(nombre);
        }

        /**/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /**/
        public int CompareTo(object obj)
        {
            Vertice x = (Vertice)obj;
            if (this.Nombre.Equals(x.nombre)) return 1;
            return 0;
        }
    }
}
