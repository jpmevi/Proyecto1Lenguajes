using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    class GeneradorTokens
    {
        Token tokenObjeto;
        private int contador = 0;
        private int actualEstado = 0;
        private ArrayList listaTokens = new ArrayList();

        public void separarTokens(String texto)
        {
            texto = texto + " ";
            char caracter;
            string concatToken = "";

            for (int i = 0; i < texto.Length; i++)
            {

                caracter = texto[i];
                switch (actualEstado)
                {
                    //Estado inicial
                    case 0:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                case '-':
                                    concatToken += caracter;
                                    setActualEstado(4);
                                    break;
                                case '"':
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case 'v':
                                    concatToken += caracter;
                                    setActualEstado(9);
                                    break;
                                case 'f':
                                    concatToken += caracter;
                                    setActualEstado(17);
                                    break;
                                case '+':
                                    concatToken += caracter;
                                    setActualEstado(24);
                                    break;
                                case '*':
                                    concatToken += caracter;
                                    setActualEstado(28);
                                    break;
                                case '/':
                                    concatToken += caracter;
                                    setActualEstado(77);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;
                            }
                            break;
                        }
                    case 1:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '+':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(24);
                                    break;
                                case '-':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(4);
                                    break;
                                case '*':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(28);
                                    break;
                                case '/':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(77);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':

                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                case '.':
                                    concatToken += caracter;
                                    setActualEstado(2);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            switch (caracter)
                            {
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(3);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 3:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':

                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(3);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 4:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                case '-':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case 'f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(17);
                                    break;
                                case 'v':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(9);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;
                            }
                            break;
                        }
                    case 6:
                        {
                            switch (caracter)
                            {
                                case '"':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    if (i + 1 == texto.Length)
                                    {
                                        insertarToken(concatToken, 62);
                                        concatToken = "";
                                        setActualEstado(0);
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(6);

                                    }
                                    break;
                            }
                            break;
                        }
                    case 9:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case 'e':
                                    concatToken += caracter;
                                    setActualEstado(10);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 10:
                        {
                            switch (caracter)
                            {
                                case 'r':
                                    concatToken += caracter;
                                    setActualEstado(11);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 11:
                        {
                            switch (caracter)
                            {
                                case 'd':
                                    concatToken += caracter;
                                    setActualEstado(12);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 12:
                        {
                            switch (caracter)
                            {
                                case 'a':
                                    concatToken += caracter;
                                    setActualEstado(13);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 13:
                        {
                            switch (caracter)
                            {
                                case 'd':
                                    concatToken += caracter;
                                    setActualEstado(14);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 14:
                        {
                            switch (caracter)
                            {
                                case 'e':
                                    concatToken += caracter;
                                    setActualEstado(15);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 15:
                        {
                            switch (caracter)
                            {
                                case 'r':
                                    concatToken += caracter;
                                    setActualEstado(16);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 16:
                        {
                            switch (caracter)
                            {
                                case 'o':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 17:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case 'a':
                                    concatToken += caracter;
                                    setActualEstado(18);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 18:
                        {
                            switch (caracter)
                            {
                                case 'l':
                                    concatToken += caracter;
                                    setActualEstado(19);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 19:
                        {
                            switch (caracter)
                            {
                                case 's':
                                    concatToken += caracter;
                                    setActualEstado(20);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 20:
                        {
                            switch (caracter)
                            {
                                case 'o':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 23:
                        {
                            switch (caracter)
                            {

                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '+':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(24);
                                    break;
                                case '*':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(28);
                                    break;
                                case '-':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(4);
                                    break;
                                case '/':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(77);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    case 24:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '+':
                                case '\f':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    

                                    setActualEstado(0);
                                    break;
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case 'f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(17);
                                    break;
                                case 'v':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(9);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;

                            }
                            break;

                        }
                    case 28:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':

                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case 'f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(17);
                                    break;
                                case 'v':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(9);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;

                            }
                            break;

                        }
                    case 77:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '/':
                                case '\f':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case 'f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(17);
                                    break;
                                case 'v':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(9);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;

                            }
                            break;

                        }
                    case 62:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':

                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '+':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(24);
                                    break;
                                case '-':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(4);
                                    break;
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case '*':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(28);
                                    break;
                                case '/':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(77);
                                    break;
                                default:
                                    concatToken += caracter;
                                    break;
                            }
                            break;
                        }
                }
            }

        }


        public void setActualEstado(int estado)
        {
            this.actualEstado = estado;
        }
        public int getActualEstado()
        {
            return this.actualEstado;
        }

        public void insertarToken(string palabra, int estado)
        {
            Token tokenNuevo;
            switch (estado)
            {
                case 1:
                    tokenNuevo = new Token(palabra, "Morado", "Entero");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 3:
                    tokenNuevo = new Token(palabra, "Celeste", "Decimal");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 4:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorAritmetico");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 6:
                    tokenNuevo = new Token(palabra, "Gris", "Cadena");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 9:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 17:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 23:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 24:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorMate");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 28:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorMate");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 77:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorMate");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 786:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 8:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorMate");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 11:
                    tokenNuevo = new Token(palabra, "Gris", "Cadena");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 16:
                    tokenNuevo = new Token(palabra, "Naranja", "Booleano");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 20:
                    tokenNuevo = new Token(palabra, "Naranja", "Booleano");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 62:
                    tokenNuevo = new Token(palabra, "Blanco", "Error");
                    listaTokens.Add(tokenNuevo);
                    break;
            }
        }

        public ArrayList getTokens()
        {
            return listaTokens;
        }
        public string operadores(char caracter, string concatToken)
        {
            switch (caracter)
            {
                case ' ':
                case '\r':
                case '\t':
                case '\n':
                case '\b':
                case '+':
                case '-':
                case '&':
                case '\f':

                    insertarToken(concatToken, getActualEstado());
                    concatToken = "";
                    concatToken += caracter;

                    setActualEstado(0);
                    break;
                case '"':
                    insertarToken(concatToken, getActualEstado());
                    concatToken = "";
                    concatToken += caracter;
                    setActualEstado(6);
                    break;
                case 'f':
                    insertarToken(concatToken, getActualEstado());
                    concatToken = "";
                    concatToken += caracter;
                    setActualEstado(17);
                    break;
                case 'v':
                    insertarToken(concatToken, getActualEstado());
                    concatToken = "";
                    concatToken += caracter;
                    setActualEstado(9);
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    insertarToken(concatToken, getActualEstado());
                    concatToken = "";
                    concatToken += caracter;
                    setActualEstado(1);
                    MessageBox.Show(concatToken);
                    break;
                default:
                    insertarToken(concatToken, getActualEstado());
                    concatToken = "";
                    concatToken += caracter;
                    setActualEstado(23);
                    break;

            }
            return concatToken;

        }
    }
}
