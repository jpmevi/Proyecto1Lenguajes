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
        public bool automataPila(Token token)
        {

            while (true)
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
                        else
                        {
                            return false;
                        }
                        break;
                    case "B":
                        if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter") || token.getToken().Equals("leer") || token.getToken().Equals("imprimir"))
                        {
                            pila.Pop();
                            pila.Push("}");
                            pila.Push("L");
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "L":
                        if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter"))
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
                        else if (token.getToken().Equals("}"))
                        {
                            pila.Pop();
                        }
                        else
                        {
                            return false;
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
                        if (token.getTipo().Equals("Booleano") || token.getTipo().Equals("Cadena") || token.getTipo().Equals("Caracter"))
                        {
                            pila.Pop();
                            pila.Push(token.getTipo());
                        }
                        else if (token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("ID") || token.getToken().Equals("("))
                        {
                            pila.Pop();
                            pila.Push("O");
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
                        if (token.getTipo().Equals("Entero"))
                        {
                            pila.Pop();
                            pila.Push("P");
                            pila.Push("ID");
                            pila.Push("Entero");
                        }
                        else if (token.getTipo().Equals("Decimal"))
                        {
                            pila.Pop();
                            pila.Push("Q");
                            pila.Push("ID");
                            pila.Push("Decimal");
                        }
                        else if (token.getTipo().Equals("Booleano"))
                        {
                            pila.Pop();
                            pila.Push("R");
                            pila.Push("ID");
                            pila.Push("Booleano");
                        }
                        else if (token.getTipo().Equals("Cadena"))
                        {
                            pila.Pop();
                            pila.Push("S");
                            pila.Push("ID");
                            pila.Push("Cadena");
                        }
                        else if (token.getTipo().Equals("Caracter"))
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
                            pila.Push("Decimal");
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
                            pila.Push("Q'");
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
                    case "T":
                        if (token.getToken().Equals("="))
                        {
                            pila.Pop();
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
                    case "I":
                        if (token.getTipo().Equals("ID"))
                        {
                            pila.Pop();
                            pila.Push("I'");
                            pila.Push("ID");
                        }
                        else
                        {
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
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal")  || token.getTipo().Equals("Cadena"))
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
                         if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal")  || token.getTipo().Equals("Cadena"))
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
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
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
                        if (token.getTipo().Equals("ID") || token.getTipo().Equals("Entero") || token.getTipo().Equals("Decimal") || token.getTipo().Equals("Cadena"))
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
                        else{
                            return false;
                        }
                        break;
                    case "X'":
                        if (token.getToken().Equals("&&") || token.getToken().Equals("||"))
                        {
                            pila.Pop();
                            pila.Push("V");
                            pila.Push(token.getToken());
                        }else if(token.getToken().Equals(")")){
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
                            pila.Push("V");
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
                        if (token.getToken().Equals("decimal") || token.getToken().Equals("entero") || token.getToken().Equals("booleano") || token.getToken().Equals("cadena") || token.getToken().Equals("caracter") || token.getToken().Equals("imprimir") || token.getToken().Equals("leer") || token.getToken().Equals("SI") || token.getToken().Equals("SINO") || token.getToken().Equals("MIENTRAS") || token.getToken().Equals("HACER") || token.getToken().Equals("DESDE")|| token.getTipo().Equals("ID"))
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
                        else if (token.getTipo().Equals("Decimal") || token.getTipo().Equals("Booleano"))
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
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }
        }
    }
}
