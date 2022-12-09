using Grafo;
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
namespace Grafobuild

{
    /*Clase que nos ayudara darle forma de grafo a nuestra lsita de vertices declarada en la clase Grafo
    dandole caracteristicas a cada elemento de la lista, pudiendo asi identificar y distinguir entre 
    vertices que son padres e hijos.*/
    class VerticeConPadre
    {
        /*Se declaran variables fijas de la clase*/
        Vertice papa;
        Vertice hijo;

        /*Declaramos una clase que identifica un vertice que esta relacionado con otro con la caracteristica
        de ser padre.   */
        public VerticeConPadre(Vertice papa, Vertice hijo)
        {
            this.papa = papa;
            this.hijo = hijo;
        }
        /*Dado un vertice cual sea nos devuelve los vertices que son hijos de dicho vertice*/
        public VerticeConPadre(Vertice hijo)
        {

            this.hijo = hijo;
        }
        /*Creacion de los Setters and Getters de los vertices que son catalogados como Padres*/
        public Vertice Papa
        {
            get { return papa; }
            set { papa = value; }
        }
        /*Creacion de los Setters and Getters de los vertices que son catalogados como Hijos*/
        public Vertice Hijo
        {
            get { return hijo; }
            set { hijo = value; }
        }
        /*Metodo de sobre escritura que si un vertice catalogado como padre se encuentra nulo el elemnto 
        considerado como su hijo pasa a tomar la posicion de padre.*/
        public override string ToString()
        {
            if (papa == null)
            {
                return hijo.Nombre;
            }
            return papa.Nombre + " <- " + hijo.Nombre;
        }
    }
}
