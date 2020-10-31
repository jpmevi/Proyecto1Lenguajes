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
        private string[] valores = new string[3];
        private int contadorllave;

        public Parserer()
        {
            pila.Push("A");
        }
        public bool automataPila(Token token)
        {
            while (pila.Count != 0)
            {
                string peek = (string)pila.Peek();
                switch (peek)
                {
                        
                    case "A":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("principal"))
                            {
                                pila.Pop();
                                pila.Push("B");
                                nod.agregarHijo("B");
                                pila.Push("{");
                                nod.agregarHijo("{");
                                pila.Push("principal");
                                nod.agregarHijo("principal");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("B");
                                nod.agregarHijo("B");
                                pila.Push("{");
                                nod.agregarHijo("{");
                                IDE.nodos.Add(nod);
                                return false;
                            }
                        }
                        break;
                    case "B":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("entero") || token.getToken().Equals("decimal") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("leer") || token.getToken().Equals("imprimir") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE") || token.getToken().Equals("SI") || token.getTipo().Equals("Comentario"))
                            {

                                pila.Pop();
                                pila.Push("}");
                                nod.agregarHijo("}");
                                pila.Push("L");
                                nod.agregarHijo("L");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                nod.agregarHijo("}");
                                pila.Push("L");
                                nod.agregarHijo("L");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("}");
                                nod.agregarHijo("}");
                                pila.Push("L");
                                nod.agregarHijo("L");
                                IDE.nodos.Add(nod);
                                return false;
                            }
                        }
                        break;
                    case "L":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("entero") || token.getToken().Equals("decimal") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                nod.agregarHijo("L");
                                pila.Push("D");
                                nod.agregarHijo("D");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("leer") || token.getToken().Equals("imprimir"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                nod.agregarHijo("L");
                                pila.Push("G");
                                nod.agregarHijo("G");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                nod.agregarHijo("L");
                                pila.Push("Z");
                                nod.agregarHijo("Z");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("}") && contadorllave == 0)
                            {
                                pila.Pop();
                            }
                            else if (token.getToken().Equals("SI") || token.getToken().Equals("HACER") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("DESDE"))
                            {
                                pila.Pop();
                                pila.Push("L");
                                nod.agregarHijo("L");
                                pila.Push("F");
                                nod.agregarHijo("F");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("}") && contadorllave != 0)
                            {
                                pila.Pop();
                                pila.Push("L");
                                nod.agregarHijo("L");
                                pila.Push("}");
                                nod.agregarHijo("}");
                                IDE.nodos.Add(nod);
                                contadorllave--;
                            }
                            else
                            {
                                if (token.getToken().Equals("{"))
                                {
                                    pila.Push("}");
                                    nod.agregarHijo("}");
                                    pila.Push("L");
                                    nod.agregarHijo("L");
                                    pila.Push("{");
                                    nod.agregarHijo("{");
                                    IDE.nodos.Add(nod);
                                }
                                else
                                {
                                    pila.Pop();
                                    pila.Push("L");
                                    nod.agregarHijo("L");
                                    IDE.nodos.Add(nod);
                                    return false;
                                }
                            }
                        }
                        break;
                    case "Z":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                nod.agregarHijo(";");
                                pila.Push("J");
                                nod.agregarHijo("J");
                                pila.Push("ID");
                                nod.agregarHijo("ID");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "Z'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("Booleano") || token.getTipo().Equals("Caracter"))
                            {
                                pila.Pop();
                                pila.Push(token.getTipo());
                                nod.agregarHijo(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("ID") || token.getToken().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nod.agregarHijo("O");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                nod.agregarHijo("O'");
                                pila.Push(token.getTipo());
                                nod.agregarHijo(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "D":
                        {
                            Nodo nod = new Nodo(peek);
                        if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter"))
                        {
                            pila.Pop();
                            pila.Push(";");
                            nod.agregarHijo(";");
                            pila.Push("D'");
                            nod.agregarHijo("D'");
                            IDE.nodos.Add(nod);
                        }
                        else
                        {
                            return false;
                        }
                        }
                        break;
                    case "D'":
                        {
                            Nodo nod = new Nodo(peek);
                        if (token.getToken().Equals("entero"))
                        {
                            pila.Pop();
                            pila.Push("P");
                            nod.agregarHijo("P");
                            pila.Push("ID");
                            nod.agregarHijo("ID");
                            pila.Push("Entero");
                            nod.agregarHijo("Entero");
                            IDE.nodos.Add(nod);
                        }
                        else if (token.getToken().Equals("decimal"))
                        {
                            pila.Pop();
                            pila.Push("Q");
                            nod.agregarHijo("Q");
                            pila.Push("ID");
                            nod.agregarHijo("ID");
                            pila.Push("Decimal");
                            nod.agregarHijo("Decimal");
                            IDE.nodos.Add(nod);
                        }
                        else if (token.getToken().Equals("booleano"))
                        {
                            pila.Pop();
                            pila.Push("R");
                            nod.agregarHijo("R");
                            pila.Push("ID");
                            nod.agregarHijo("ID");
                            pila.Push("Booleano");
                            nod.agregarHijo("Booleano");
                            IDE.nodos.Add(nod);
                        }
                        else if (token.getToken().Equals("cadena"))
                        {
                            pila.Pop();
                            pila.Push("S");
                            nod.agregarHijo("S");
                            pila.Push("ID");
                            nod.agregarHijo("ID");
                            pila.Push("Cadena");
                            nod.agregarHijo("Cadena");
                            IDE.nodos.Add(nod);
                        }
                        else if (token.getToken().Equals("caracter"))
                        {
                            pila.Pop();
                            pila.Push("T");
                            nod.agregarHijo("T");
                            pila.Push("ID");
                            nod.agregarHijo("ID");
                            pila.Push("Caracter");
                            nod.agregarHijo("Caracter");
                            IDE.nodos.Add(nod);
                        }
                        else
                        {
                            return false;
                        }
                        }
                        break;
                    case "P":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nod.agregarHijo("O");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                nod.agregarHijo("I");
                                pila.Push(",");
                                nod.agregarHijo(",");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "Q":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nod.agregarHijo("O");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                nod.agregarHijo("I");
                                pila.Push(",");
                                nod.agregarHijo(",");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();

                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "R":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Booleano");
                                nod.agregarHijo("Booleano");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                nod.agregarHijo("I");
                                pila.Push(",");
                                nod.agregarHijo(",");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "S":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                nod.agregarHijo("O'");
                                pila.Push("Cadena");
                                nod.agregarHijo("Cadena");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                nod.agregarHijo("I");
                                pila.Push(",");
                                nod.agregarHijo(",");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "T":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Caracter");
                                nod.agregarHijo("Caracter");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                nod.agregarHijo("I");
                                pila.Push(",");
                                nod.agregarHijo(",");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "I":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("I'");
                                nod.agregarHijo("I'");
                                pila.Push("ID");
                                nod.agregarHijo("ID");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("P");
                                nod.agregarHijo("P");
                                IDE.nodos.Add(nod);
                                return false;
                            }
                            break;
                        }
                    case "I'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals(","))
                            {
                                pila.Pop();
                                pila.Push("I");
                                nod.agregarHijo("I");
                                pila.Push(",");
                                nod.agregarHijo(",");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();

                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "G":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("leer"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                nod.agregarHijo(";");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("ID");
                                nod.agregarHijo("ID");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                pila.Push("leer");
                                nod.agregarHijo("leer");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("imprimir"))
                            {
                                pila.Pop();
                                pila.Push("C");
                                nod.agregarHijo("C");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                pila.Push("imprimir");
                                nod.agregarHijo("imprimir");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "C":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push(";");
                                nod.agregarHijo(";");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("M");
                                nod.agregarHijo("M");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "M":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("M'");
                                nod.agregarHijo("M'");
                                pila.Push(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "M'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("M");
                                nod.agregarHijo("M");
                                pila.Push("+");
                                nod.agregarHijo("+");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "F":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("SI"))
                            {
                                pila.Pop();
                                pila.Push("E'");
                                nod.agregarHijo("E'");
                                pila.Push("E");
                                nod.agregarHijo("E");
                                pila.Push("S'");
                                nod.agregarHijo("S'");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("V");
                                nod.agregarHijo("V");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                pila.Push("SI");
                                nod.agregarHijo("SI");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("MIENTRAS"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                nod.agregarHijo("S'");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("V");
                                nod.agregarHijo("V");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                pila.Push("MIENTRAS");
                                nod.agregarHijo("MIENTRAS");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("HACER"))
                            {
                                pila.Pop();
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("V");
                                nod.agregarHijo("V");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                pila.Push("MIENTRAS");
                                nod.agregarHijo("MIENTRAS");
                                pila.Push("S'");
                                nod.agregarHijo("S'");
                                pila.Push("HACER");
                                nod.agregarHijo("HACER");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("DESDE"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                nod.agregarHijo("S'");
                                pila.Push("ENTERO");
                                nod.agregarHijo("ENTERO");
                                pila.Push("INCREMENTO");
                                nod.agregarHijo("INCREMENTO");
                                pila.Push("ENTERO");
                                nod.agregarHijo("ENTERO");
                                pila.Push("S''");
                                nod.agregarHijo("S''");
                                pila.Push("ID");
                                nod.agregarHijo("ID");
                                pila.Push("HASTA");
                                nod.agregarHijo("HASTA");
                                pila.Push("ENTERO");
                                nod.agregarHijo("ENTERO");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                pila.Push("ID");
                                nod.agregarHijo("ID");
                                pila.Push("DESDE");
                                nod.agregarHijo("DESDE");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "V":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                            {
                                pila.Pop();
                                pila.Push("V'");
                                nod.agregarHijo("V'");
                                pila.Push("X");
                                nod.agregarHijo("X");
                                pila.Push("V'");
                                nod.agregarHijo("V'");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("X'");
                                nod.agregarHijo("X'");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("V'");
                                nod.agregarHijo("V'");
                                pila.Push("X");
                                nod.agregarHijo("X");
                                pila.Push("V'");
                                nod.agregarHijo("V'");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "V'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                            {
                                pila.Pop();
                                pila.Push(token.getTipo());
                                nod.agregarHijo(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "X":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals(">") || token.getToken().Equals("<") || token.getToken().Equals("==") || token.getToken().Equals("<=") || token.getToken().Equals(">=") || token.getToken().Equals("!="))
                            {
                                pila.Pop();
                                pila.Push(token.getToken());
                                nod.agregarHijo(token.getToken());
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "X'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("&&") || token.getToken().Equals("||"))
                            {
                                pila.Pop();
                                pila.Push("V");
                                nod.agregarHijo("V");
                                pila.Push(token.getToken());
                                nod.agregarHijo(token.getToken());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "S'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("{"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                nod.agregarHijo("}");
                                pila.Push("L");
                                nod.agregarHijo("L");
                                pila.Push("{");
                                nod.agregarHijo("{");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "S''":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals(">") || token.getToken().Equals("<") || token.getToken().Equals("<=") || token.getToken().Equals(">=") || token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push(token.getToken());
                                nod.agregarHijo(token.getToken());
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "E":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("decimal") || token.getToken().Equals("entero") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("imprimir") || token.getToken().Equals("leer") || token.getToken().Equals("SI") || token.getToken().Equals("SINO") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE") || token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                            }
                            else if (token.getToken().Equals("SINO_SI"))
                            {
                                pila.Pop();
                                pila.Push("E");
                                nod.agregarHijo("E");
                                pila.Push("S'");
                                nod.agregarHijo("S'");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("V");
                                nod.agregarHijo("V");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                pila.Push("SINO_SI");
                                nod.agregarHijo("SINO_SI");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getTipo().Equals("Comentario"))
                            {
                                pila.Pop();
                                pila.Push("E");
                                nod.agregarHijo("E");
                                pila.Push(token.getToken());
                                nod.agregarHijo(token.getToken());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("}"))
                            {
                                pila.Pop();
                                pila.Push("}");
                                nod.agregarHijo("}");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "E'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("decimal") || token.getToken().Equals("entero") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("imprimir") || token.getToken().Equals("leer") || token.getToken().Equals("SI") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE") || token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                            }
                            else if (token.getToken().Equals("SINO"))
                            {
                                pila.Pop();
                                pila.Push("S'");
                                nod.agregarHijo("S'");
                                pila.Push("SINO");
                                nod.agregarHijo("SINO");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "O":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                nod.agregarHijo("N");
                                pila.Push("ID");
                                nod.agregarHijo("ID");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getTipo().Equals("Decimal") || token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("N");
                                nod.agregarHijo("N");
                                pila.Push(token.getTipo());
                                nod.agregarHijo(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("N");
                                nod.agregarHijo("N");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("O");
                                nod.agregarHijo("O");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("N");
                                nod.agregarHijo("N");
                                IDE.nodos.Add(nod);
                                return false;
                            }
                        }
                        break;
                    case "N":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("+") || token.getToken().Equals("-") || token.getToken().Equals("*") || token.getToken().Equals("/"))
                            {
                                pila.Pop();
                                pila.Push("O");
                                nod.agregarHijo("O");
                                pila.Push(token.getToken());
                                nod.agregarHijo(token.getToken());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "J":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("="))
                            {
                                pila.Pop();
                                pila.Push("Z'");
                                nod.agregarHijo("Z'");
                                pila.Push("=");
                                nod.agregarHijo("=");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("++"))
                            {
                                pila.Pop();
                                pila.Push("++");
                                nod.agregarHijo("++");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("--"))
                            {
                                pila.Pop();
                                pila.Push("--");
                                nod.agregarHijo("--");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                pila.Pop();
                                return false;
                            }
                        }
                        break;
                    case "Q'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("+") || token.getToken().Equals("-") || token.getToken().Equals("*"))
                            {
                                pila.Pop();
                                pila.Push("Q''");
                                nod.agregarHijo("Q''");
                                pila.Push(token.getToken());
                                nod.agregarHijo(token.getToken());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(")"))
                            {
                                pila.Pop();
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "Q''":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero"))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                nod.agregarHijo("Q'");
                                pila.Push(token.getTipo());
                                nod.agregarHijo(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals("("))
                            {
                                pila.Pop();
                                pila.Push("Q'");
                                nod.agregarHijo("Q'");
                                pila.Push(")");
                                nod.agregarHijo(")");
                                pila.Push("Q''");
                                nod.agregarHijo("Q''");
                                pila.Push("(");
                                nod.agregarHijo("(");
                                IDE.nodos.Add(nod);
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "O'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getToken().Equals("+"))
                            {
                                pila.Pop();
                                pila.Push("N'");
                                nod.agregarHijo("N'");
                                pila.Push("+");
                                nod.agregarHijo("+");
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case "N'":
                        {
                            Nodo nod = new Nodo(peek);
                            if (token.getTipo().Equals("ID") || token.getTipo().Equals("Cadena"))
                            {
                                pila.Pop();
                                pila.Push("O'");
                                nod.agregarHijo("O'");
                                pila.Push(token.getTipo());
                                nod.agregarHijo(token.getTipo());
                                IDE.nodos.Add(nod);
                            }
                            else if (token.getToken().Equals(";"))
                            {
                                pila.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    default:
                        if (peek.Equals(token.getToken()) || peek.Equals(token.getTipo()))
                        {
                            pila.Pop();


                            if (token.getToken().Equals("decimal") || token.getToken().Equals("entero") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter"))
                            {
                                valores[0] = token.getToken();
                            }
                            else if (token.getTipo().Equals("ID"))
                            {
                                valores[1] = token.getToken();
                            }
                            else if (valores[1] != null)
                            {
                                switch (valores[0])
                                {
                                    case "entero":
                                        if (token.getTipo().Equals("Entero"))
                                        {
                                            valores[2] = valores[2] + token.getToken();
                                        }
                                        break;
                                    case "decimal":
                                        if (token.getTipo().Equals("Decimal"))
                                        {
                                            valores[2] = valores[2] + token.getToken();
                                        }
                                        break;
                                    case "cadena":
                                        if (token.getTipo().Equals("Cadena"))
                                        {
                                            valores[2] = valores[2] + token.getToken();
                                        }
                                        break;
                                    case "caracter":
                                        if (token.getTipo().Equals("Caracter"))
                                        {
                                            valores[2] = valores[2] + token.getToken();
                                        }
                                        break;
                                    case "booleano":
                                        if (token.getTipo().Equals("Booleano"))
                                        {
                                            valores[2] = valores[2] + token.getToken();
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            }
                            else if (token.getToken().Equals(";") && valores[1] != null)
                            {
                                if (valores[2] == null)
                                {
                                    valores[2] = "null";
                                }
                                if (valores[0] == null)
                                {
                                    valores[0] = "null";
                                }
                                TablaSimbolos tabla = new TablaSimbolos(valores[0], valores[1], valores[2]);

                            }
                            return true;
                        }
                        else
                        {
                            if (token.getToken().Equals("{"))
                            {
                                contadorllave++;
                            }
                                return false;
                            

                        }
                }

            }
           
            return true;
        }

    }
}