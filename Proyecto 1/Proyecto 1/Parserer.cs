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
                        if (token.getToken().Equals("principal"))
                        {
                            pila.Pop();
                            pila.Push("B");
                            pila.Push("{");
                            pila.Push("principal");
                        }
                        else
                        {
                            pila.Pop();
                            pila.Push("B");
                            pila.Push("{");
                            return false;
                        }
                        break;
                    case "B":
                        if (token.getToken().Equals("entero") || token.getToken().Equals("decimal") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("leer") || token.getToken().Equals("imprimir") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE") || token.getToken().Equals("SI") || token.getTipo().Equals("Comentario"))
                        {
                            pila.Pop();
                            pila.Push("}");
                            pila.Push("L");
                        }
                        else if (token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                            pila.Push("}");
                            pila.Push("L");
                        }
                        else
                        {
                            pila.Pop();
                            pila.Push("}");
                            pila.Push("L");
                            return false;
                        }
                        break;
                    case "L":
                        if (token.getToken().Equals("entero") || token.getToken().Equals("decimal") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("D");
                        }
                        else if (token.getToken().Equals("leer") || token.getToken().Equals("imprimir"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("G");
                        }
                        else if (token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("Z");
                        }
                        else if (token.getToken().Equals("}") && contadorllave == 0)
                        {
                            pila.Pop();
                        }
                        else if (token.getToken().Equals("SI") || token.getToken().Equals("HACER") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("DESDE"))
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("F");
                        }
                        else if (token.getToken().Equals("}") && contadorllave != 0)
                        {
                            pila.Pop();
                            pila.Push("L");
                            pila.Push("}");
                            contadorllave--;
                        }
                        else
                        {
                            if (token.getToken().Equals("{"))
                            {
                                pila.Push("}");
                                pila.Push("L");
                                pila.Push("{");
                            }
                            else
                            {
                                pila.Pop();
                                pila.Push("L");
                                return false;
                            }
                        }
                        break;
                    case "Z":
                        if (token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                            pila.Push(";");
                            pila.Push("J");
                            pila.Push("ID");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "Z'":
                        if (token.getTipo().Equals("Booleano") || token.getTipo().Equals("Caracter"))
                        {
                            pila.Pop();
                            pila.Push(token.getTipo());
                        }
                        else if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("ID") || token.getToken().Equals("("))
                        {
                            pila.Pop();
                            pila.Push("O");
                        }
                        else if (token.getTipo().Equals("Cadena"))
                        {
                            pila.Pop();
                            pila.Push("O'");
                            pila.Push(token.getTipo());
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "D":
                        if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter"))
                        {
                            pila.Pop();
                            pila.Push(";");
                            pila.Push("D'");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "D'":
                        if (token.getToken().Equals("entero"))
                        {
                            pila.Pop();
                            pila.Push("P");
                            pila.Push("ID");
                            pila.Push("Entero");
                        }
                        else if (token.getToken().Equals("decimal"))
                        {
                            pila.Pop();
                            pila.Push("Q");
                            pila.Push("ID");
                            pila.Push("Decimal");
                        }
                        else if (token.getToken().Equals("booleano"))
                        {
                            pila.Pop();
                            pila.Push("R");
                            pila.Push("ID");
                            pila.Push("Booleano");
                        }
                        else if (token.getToken().Equals("cadena"))
                        {
                            pila.Pop();
                            pila.Push("S");
                            pila.Push("ID");
                            pila.Push("Cadena");
                        }
                        else if (token.getToken().Equals("caracter"))
                        {
                            pila.Pop();
                            pila.Push("T");
                            pila.Push("ID");
                            pila.Push("Caracter");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "P":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("O");
                            pila.Push("=");
                        }
                        else if (token.getToken().Equals(","))
                        {
                            pila.Pop();
                            pila.Push("I");
                            pila.Push(",");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "Q":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("O");
                            pila.Push("=");
                        }
                        else if (token.getToken().Equals(","))
                        {
                            pila.Pop();
                            pila.Push("I");
                            pila.Push(",");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "R":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("Booleano");
                            pila.Push("=");
                        }
                        else if (token.getToken().Equals(","))
                        {
                            pila.Pop();
                            pila.Push("I");
                            pila.Push(",");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "S":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("O'");
                            pila.Push("Cadena");
                            pila.Push("=");
                        }
                        else if (token.getToken().Equals(","))
                        {
                            pila.Pop();
                            pila.Push("I");
                            pila.Push(",");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "T":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("Caracter");
                            pila.Push("=");
                        }
                        else if (token.getToken().Equals(","))
                        {
                            pila.Pop();
                            pila.Push("I");
                            pila.Push(",");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "I":
                        if (token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                            pila.Push("I'");
                            pila.Push("ID");
                        }
                        else
                        {
                            pila.Pop();
                            pila.Push("P");
                            return false;
                        }
                        break;
                    case "I'":
                        if (token.getToken().Equals(","))
                        {
                            pila.Pop();
                            pila.Push("I");
                            pila.Push(",");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();

                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "G":
                        if (token.getToken().Equals("leer"))
                        {
                            pila.Pop();
                            pila.Push(";");
                            pila.Push(")");
                            pila.Push("ID");
                            pila.Push("(");
                            pila.Push("leer");
                        }
                        else if (token.getToken().Equals("imprimir"))
                        {
                            pila.Pop();
                            pila.Push("C");
                            pila.Push("(");
                            pila.Push("imprimir");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "C":
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                        {
                            pila.Pop();
                            pila.Push(";");
                            pila.Push(")");
                            pila.Push("M");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "M":
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
                        {
                            pila.Pop();
                            pila.Push("M'");
                            pila.Push(token.getTipo());
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "M'":
                        if (token.getToken().Equals("+"))
                        {
                            pila.Pop();
                            pila.Push("M");
                            pila.Push("+");
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
                        break;
                    case "F":
                        if (token.getToken().Equals("SI"))
                        {
                            pila.Pop();
                            pila.Push("E'");
                            pila.Push("E");
                            pila.Push("S'");
                            pila.Push(")");
                            pila.Push("V");
                            pila.Push("(");
                            pila.Push("SI");
                        }
                        else if (token.getToken().Equals("MIENTRAS"))
                        {
                            pila.Pop();
                            pila.Push("S'");
                            pila.Push(")");
                            pila.Push("V");
                            pila.Push("(");
                            pila.Push("MIENTRAS");
                        }
                        else if (token.getToken().Equals("HACER"))
                        {
                            pila.Pop();
                            pila.Push(")");
                            pila.Push("V");
                            pila.Push("(");
                            pila.Push("MIENTRAS");
                            pila.Push("S'");
                            pila.Push("HACER");
                        }
                        else if (token.getToken().Equals("DESDE"))
                        {
                            pila.Pop();
                            pila.Push("S'");
                            pila.Push("ENTERO");
                            pila.Push("INCREMENTO");
                            pila.Push("ENTERO");
                            pila.Push("S''");
                            pila.Push("ID");
                            pila.Push("HASTA");
                            pila.Push("ENTERO");
                            pila.Push("=");
                            pila.Push("ID");
                            pila.Push("=DESDE");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "V":
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                        {
                            pila.Pop();
                            pila.Push("V'");
                            pila.Push("X");
                            pila.Push("V'");
                        }
                        else if (token.getToken().Equals("("))
                        {
                            pila.Pop();
                            pila.Push("X'");
                            pila.Push(")");
                            pila.Push("V'");
                            pila.Push("X");
                            pila.Push("V'");
                            pila.Push("(");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "V'":
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Booleano"))
                        {
                            pila.Pop();
                            pila.Push(token.getTipo());
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "X":
                        if (token.getToken().Equals(">") || token.getToken().Equals("<") || token.getToken().Equals("==") || token.getToken().Equals("<=") || token.getToken().Equals(">=") || token.getToken().Equals("!="))
                        {
                            pila.Pop();
                            pila.Push(token.getToken());
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "X'":
                        if (token.getToken().Equals("&&") || token.getToken().Equals("||"))
                        {
                            pila.Pop();
                            pila.Push("V");
                            pila.Push(token.getToken());
                        }
                        else if (token.getToken().Equals(")"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "S'":
                        if (token.getToken().Equals("{"))
                        {
                            pila.Pop();
                            pila.Push("}");
                            pila.Push("L");
                            pila.Push("{");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "S''":
                        if (token.getToken().Equals(">") || token.getToken().Equals("<") || token.getToken().Equals("<=") || token.getToken().Equals(">=") || token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push(token.getToken());
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "E":
                        if (token.getToken().Equals("decimal") || token.getToken().Equals("entero") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("imprimir") || token.getToken().Equals("leer") || token.getToken().Equals("SI") || token.getToken().Equals("SINO") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE") || token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                        }
                        else if (token.getToken().Equals("SINO_SI"))
                        {
                            pila.Pop();
                            pila.Push("E");
                            pila.Push("S'");
                            pila.Push(")");
                            pila.Push("V");
                            pila.Push("(");
                            pila.Push("SINO_SI");
                        }
                        else if (token.getTipo().Equals("Comentario"))
                        {
                            pila.Pop();
                            pila.Push("E");
                            pila.Push(token.getToken());
                        }
                        else if (token.getToken().Equals("}"))
                        {
                            pila.Pop();
                            pila.Push("}");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "E'":
                        if (token.getToken().Equals("decimal") || token.getToken().Equals("entero") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("imprimir") || token.getToken().Equals("leer") || token.getToken().Equals("SI") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE") || token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                        }
                        else if (token.getToken().Equals("SINO"))
                        {
                            pila.Pop();
                            pila.Push("S'");
                            pila.Push("SINO");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "O":
                        if (token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                            pila.Push("N");
                            pila.Push("ID");
                        }
                        else if (token.getTipo().Equals("Decimal") || token.getTipo().Equals("Entero"))
                        {
                            pila.Pop();
                            pila.Push("N");
                            pila.Push(token.getTipo());
                        }
                        else if (token.getToken().Equals("("))
                        {
                            pila.Pop();
                            pila.Push("N");
                            pila.Push(")");
                            pila.Push("O");
                            pila.Push("(");
                        }
                        else
                        {
                            pila.Pop();
                            pila.Push("N");
                            return false;
                        }
                        break;
                    case "N":
                        if (token.getToken().Equals("+") || token.getToken().Equals("-") || token.getToken().Equals("*") || token.getToken().Equals("/"))
                        {
                            pila.Pop();
                            pila.Push("O");
                            pila.Push(token.getToken());
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
                        break;
                    case "J":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
                            pila.Push("Z'");
                            pila.Push("=");
                        }
                        else if (token.getToken().Equals("++"))
                        {
                            pila.Pop();
                            pila.Push("++");
                        }
                        else if (token.getToken().Equals("--"))
                        {
                            pila.Pop();
                            pila.Push("--");
                        }
                        else
                        {
                            pila.Pop();
                            return false;
                        }
                        break;
                    case "Q'":
                        if (token.getToken().Equals("+") || token.getToken().Equals("-") || token.getToken().Equals("*"))
                        {
                            pila.Pop();
                            pila.Push("Q''");
                            pila.Push(token.getToken());
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
                        break;
                    case "Q''":
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero"))
                        {
                            pila.Pop();
                            pila.Push("Q'");
                            pila.Push(token.getTipo());
                        }
                        else if (token.getToken().Equals("("))
                        {
                            pila.Pop();
                            pila.Push("Q'");
                            pila.Push(")");
                            pila.Push("Q''");
                            pila.Push("(");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "O'":
                        if (token.getToken().Equals("+"))
                        {
                            pila.Pop();
                            pila.Push("N'");
                            pila.Push("+");
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "N'":
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Cadena"))
                        {
                            pila.Pop();
                            pila.Push("O'");
                            pila.Push(token.getTipo());
                        }
                        else if (token.getToken().Equals(";"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
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