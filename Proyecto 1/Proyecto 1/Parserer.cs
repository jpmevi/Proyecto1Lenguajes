using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Proyecto_1
{
    class Parserer
    {
        private Stack pila = new Stack();
        public bool si;

        public Parserer()
        {
            pila.Push("A");
        }
        public void automataPila(Token token)
        {
            string peek = (string)pila.Peek();
            switch (peek)
            {
                case "A":
                    if (token.getToken().Equals("Principal"))
                    {
                        pila.Pop();
                        pila.Push("B");
                        pila.Push("{");
                        pila.Push("Principal");
                    }
                    break;
                case "B":
                    if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter") || token.getToken().Equals("leer") || token.getToken().Equals("imprimir"))
                    {
                        pila.Pop();
                        pila.Push("}");
                        pila.Push("L");
                    }
                    break;
                case "L":
                    if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter") )
                    {
                        pila.Pop();
                        pila.Push("D");
                        pila.Push("L");
                    }
                    else if (token.getToken().Equals("leer") || token.getToken().Equals("imprimir"))
                    {
                        pila.Pop();
                        pila.Push("G");
                        pila.Push("L");
                    }
                    else if (token.getTipo().Equals("ID"))
                    {
                        pila.Pop();
                        pila.Push("Z");
                        pila.Push("L");
                    }
                    break;
            }
        }
    }
}
