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
        private string padre;
        private ArrayList hijos = new ArrayList();

        public Nodo(string padre)
        {
            this.padre = padre;
        }

        public void agregarHijo(string hijo)
        {
            hijos.Add(hijo);
        }

        public ArrayList getHijos()
        {
            return this.hijos;
        }

        public string getPadre()
        {
            return this.padre;
        }
    }
}
