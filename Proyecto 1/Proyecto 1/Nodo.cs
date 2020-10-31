using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Nodo
    {
        private Nodo nodo_padre;
        private string nombre;
        private int nivel;
        private ArrayList hijos = new ArrayList();

        public Nodo(string nombre)
        {
            this.nombre = nombre;
        }

        public Nodo(string nombre, Nodo nodo_padre, int nivel)
        {
            this.nombre = nombre;
            this.nodo_padre = nodo_padre;
            this.nivel = nivel;
        }

        public void agregarHijo(string hijo)
        {
            hijos.Add(hijo);
        }

        public ArrayList getHijos()
        {
            return this.hijos;
        }

        public Nodo getPadre()
        {
            return this.nodo_padre;
        }

        public int getNivel()
        {
            return this.nivel;
        }
        public string getNombre()
        {
            return this.nombre;
        }

        public void setNivel(int nivel)
        {
            this.nivel = nivel;
        }
    }
}
