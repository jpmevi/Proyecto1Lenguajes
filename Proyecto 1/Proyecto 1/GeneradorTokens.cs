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
        private int contadorfila = 1;
        private int contadorcolumna = 0;
        private int columnatemp = 0;
        private int actualEstado = 0;
        private ArrayList listaTokens = new ArrayList();
        private Parserer parserer = new Parserer();

        public void separarTokens(RichTextBox textorich)
        {



            string texto = textorich.Text + " ";
            char caracter;
            string concatToken = "";
            bool enterComillas = false;
            bool comentario = false;
            bool comentarioCompleto = false;
            bool asterisco = false;
            contadorfila = 1;
             contadorcolumna = 0;
             columnatemp = 0;
            for (int i = 0; i < texto.Length; i++)
            {
                columnatemp++;
                contadorcolumna++;
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
                                case '&':
                                    concatToken += caracter;
                                    setActualEstado(26);
                                    break;
                                case '|':
                                    concatToken += caracter;
                                    setActualEstado(36);
                                    break;
                                case '<':
                                    concatToken += caracter;
                                    setActualEstado(30);
                                    break;
                                case '>':
                                    concatToken += caracter;
                                    setActualEstado(30);
                                    break;
                                case '=':
                                    concatToken += caracter;
                                    setActualEstado(31);
                                    break;
                                case '!':
                                    concatToken += caracter;
                                    setActualEstado(30);
                                    break;
                                case ';':
                                    concatToken += caracter;
                                    setActualEstado(32);
                                    break;
                                case '(':
                                    concatToken += caracter;
                                    setActualEstado(38);
                                    break;
                                case ')':
                                    concatToken += caracter;
                                    setActualEstado(39);
                                    break;
                                case '_':
                                    concatToken += caracter;
                                    setActualEstado(40);
                                    break;
                                case ',':
                                    concatToken += caracter;
                                    insertarToken(concatToken, 42);
                                    setActualEstado(0);
                                    concatToken = "";
                                    break;
                                case '{':
                                    concatToken += caracter;
                                    insertarToken(concatToken, 43);
                                    setActualEstado(0);
                                    concatToken = "";
                                    break;
                                case '}':
                                    concatToken += caracter;
                                    insertarToken(concatToken, 43);
                                    setActualEstado(0);
                                    concatToken = "";
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion de numeros
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
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    //Estado de que recibe un punto
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
                    //Estado de que recibe un punto
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
                    //Estado de aceptacion que recibe un menos
                    case 4:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
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

                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion que recibe comillas y una cadena 
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
                                case '\n':
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    enterComillas = true;
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
                    //Estado que recibe una e
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
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una r
                    case 10:
                        {
                            switch (caracter)
                            {
                                case 'r':
                                    concatToken += caracter;
                                    setActualEstado(11);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una d
                    case 11:
                        {
                            switch (caracter)
                            {
                                case 'd':
                                    concatToken += caracter;
                                    setActualEstado(12);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una a
                    case 12:
                        {
                            switch (caracter)
                            {
                                case 'a':
                                    concatToken += caracter;
                                    setActualEstado(13);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una d
                    case 13:
                        {
                            switch (caracter)
                            {
                                case 'd':
                                    concatToken += caracter;
                                    setActualEstado(14);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una e
                    case 14:
                        {
                            switch (caracter)
                            {
                                case 'e':
                                    concatToken += caracter;
                                    setActualEstado(15);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una r
                    case 15:
                        {
                            switch (caracter)
                            {
                                case 'r':
                                    concatToken += caracter;
                                    setActualEstado(16);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion recibe una o
                    case 16:
                        {
                            switch (caracter)
                            {
                                case 'o':
                                    concatToken += caracter;
                                    setActualEstado(78);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una f
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
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una a
                    case 18:
                        {
                            switch (caracter)
                            {
                                case 'l':
                                    concatToken += caracter;
                                    setActualEstado(19);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una l
                    case 19:
                        {
                            switch (caracter)
                            {
                                case 's':
                                    concatToken += caracter;
                                    setActualEstado(20);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion que recibe una s
                    case 20:
                        {
                            switch (caracter)
                            {
                                case 'o':
                                    concatToken += caracter;
                                    setActualEstado(78);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe cualquier caracter
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
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;



                            }
                            break;
                        }
                    //Estado de aceptacion que recibe un +
                    case 24:
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
                                    concatToken += caracter;
                                     insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado que recibe el & y acepta &&
                    case 26:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\n':
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '&':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un *
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
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion de los operadores relacionales
                    case 30:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '=':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un =
                    case 31:
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
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                case '=':
                                    concatToken += caracter;
                                    insertarToken(concatToken, 30);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un ;
                    case 32:
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
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un (
                    case 38:
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
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un )
                    case 39:
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
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un _
                    case 40:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(41);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe lo siguiente de id
                    case 41:
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
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                case '{':
                                case '}':
                                case ',':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(41);
                                    break;

                            }
                            break;

                        }
                    //Estado que recibe el | y acepta ||
                    case 36:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\n':
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '|':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;

                        }
                    //Estado de aceptacion que recibe una / y es el estado de aceptacion de los comentarios
                    case 77:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    if (comentarioCompleto == true && asterisco == false)
                                    {
                                        if ((i + 1) != texto.Length)
                                        {
                                            concatToken += caracter;
                                            setActualEstado(77);
                                        }
                                        else
                                        {
                                            concatToken += caracter;
                                            insertarToken(concatToken, 62);
                                            concatToken = "";
                                            setActualEstado(0);
                                            comentario = false;
                                        }
                                    }
                                    else if (comentario == true)
                                    {
                                        if ((i + 1) == texto.Length)
                                        {
                                            insertarToken(concatToken, 78);
                                            concatToken = "";
                                            comentario = false;
                                            setActualEstado(0);
                                        }
                                        else
                                        {
                                            concatToken += caracter;
                                            setActualEstado(77);
                                        }

                                    }




                                    break;
                                case '\n':
                                    if (comentarioCompleto == false && comentario == false)
                                    {
                                        insertarToken(concatToken, getActualEstado());
                                        concatToken = "";
                                        comentario = false;
                                        setActualEstado(0);
                                    }
                                    else if (comentarioCompleto == true)
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                    }
                                    else
                                    {
                                        insertarToken(concatToken, 78);
                                        concatToken = "";
                                        comentario = false;
                                        setActualEstado(0);
                                    }

                                    break;
                                case '/':
                                    if (comentarioCompleto == true || comentario == true)
                                    {
                                        if (asterisco == true)
                                        {
                                            concatToken += caracter;
                                            insertarToken(concatToken, 79);
                                            concatToken = "";
                                            comentario = false;
                                            setActualEstado(0);
                                            comentarioCompleto = false;
                                            asterisco = false;
                                        }
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                        comentario = true;

                                    }
                                    break;
                                case '*':
                                    if (comentarioCompleto == false && comentario == false && asterisco == false)
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                        comentarioCompleto = true;
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                        asterisco = true;
                                    }

                                    break;
                                default:
                                    if (comentario == false && comentarioCompleto == false)
                                    {
                                        insertarToken(concatToken, getActualEstado());
                                        concatToken = "";
                                        i = i - 1;
                                        setActualEstado(0);
                                        break;
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                    }
                                    break;

                            }
                            break;

                        }
                    //Estado para las palabras veradero y falso
                    case 78:
                        {

                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, 20);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                    insertarToken(concatToken, 20);
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;

                        }
                    //Estado de aceptacion que recibe todos los errores en el texto
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
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                case '{':
                                case'}':
                                case ',':

                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    break;
                            }
                            break;
                        }
                }

                //Comparamos si viene un espacio y si es un comentario para que se guarde todo el texto
                if (caracter.Equals('\n') && (!enterComillas) && (!comentarioCompleto))
                {
                    insertarToken(concatToken, 63);
                    contadorfila++;
                    columnatemp = 0;
                    contadorcolumna = 0;
                }
                else
                {
                    enterComillas = false;
                }

            }

        }

        /// <summary>
        /// Metodo para establecer el estado actual
        /// </summary>
        /// <param name="estado"></param>
        public void setActualEstado(int estado)
        {
            this.actualEstado = estado;
        }
        /// <summary>
        /// Metodo para obtener el estado actual
        /// </summary>
        /// <returns></returns>
        public int getActualEstado()
        {
            return this.actualEstado;
        }

        /// <summary>
        /// Metodo para Insertar nuestros tokens mandando una palabra y el numero del estado
        /// </summary>
        /// <param name="palabra"></param>
        /// <param name="estado"></param>
        public void insertarToken(string palabra, int estado)
        {

            Token tokenNuevo;
            switch (estado)
            {
                case 1:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Entero");
                    compararSintaxis(tokenNuevo);
                    break;

                case 3:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Decimal");
                    compararSintaxis(tokenNuevo);
                    break;

                case 4:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorAritmetico");
                    compararSintaxis(tokenNuevo);
                    break;

                case 6:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Cadena");
                    compararSintaxis(tokenNuevo);
                    break;

                case 9:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Caracter");
                    compararSintaxis(tokenNuevo);
                    break;
                case 17:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Caracter");
                    compararSintaxis(tokenNuevo);
                    break;
                case 23:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Caracter");
                    compararSintaxis(tokenNuevo);
                    break;

                case 24:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorAritmetico");
                    compararSintaxis(tokenNuevo);
                    break;
                case 26:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorLogico");
                    compararSintaxis(tokenNuevo);
                    break;
                case 28:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorAritmetico");
                    compararSintaxis(tokenNuevo);
                    break;
                case 30:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorRelacional");
                    compararSintaxis(tokenNuevo);
                    break;
                case 31:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Sentencia");
                    compararSintaxis(tokenNuevo);
                    break;
                case 32:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Sentencia");
                    compararSintaxis(tokenNuevo);
                    break;
                case 38:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Signo");
                    compararSintaxis(tokenNuevo);
                    break;
                case 39:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Signo");
                    compararSintaxis(tokenNuevo);
                    break;
                case 36:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorLogico");
                    compararSintaxis(tokenNuevo);
                    break;

                case 77:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorAritmetico");
                    compararSintaxis(tokenNuevo);
                    break;
                case 78:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Comentario");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 79:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Comentario");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 8:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "OperadorAritmetico");
                    compararSintaxis(tokenNuevo);
                    break;
                case 11:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Cadena");
                    compararSintaxis(tokenNuevo);
                    break;
                case 16:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Booleano");
                    compararSintaxis(tokenNuevo);
                    break;
                case 20:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Booleano");
                    compararSintaxis(tokenNuevo);
                    break;
                case 62:
                    if (palabra.Equals("SI") || palabra.Equals("SINO") || palabra.Equals("SINO_SI") || palabra.Equals("MIENTRAS") || palabra.Equals("HACER") || palabra.Equals("DESDE") || palabra.Equals("HASTA") || palabra.Equals("INCREMENTO") || palabra.Equals("principal") || palabra.Equals("leer") || palabra.Equals("imprimir"))
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Reservada");

                        compararSintaxis(tokenNuevo);
                    }
                    else if (palabra.Equals("entero"))
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Entero");
                        compararSintaxis(tokenNuevo);
                    }
                    else if (palabra.Equals("decimal"))
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Decimal");
                        compararSintaxis(tokenNuevo);
                    }
                    else if (palabra.Equals("cadena"))
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Cadena");
                        compararSintaxis(tokenNuevo);
                    }
                    else if (palabra.Equals("booleano"))
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Booleano");
                        compararSintaxis(tokenNuevo);
                    }
                    else if (palabra.Equals("caracter"))
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Caracter");
                        compararSintaxis(tokenNuevo);
                    }
                    else
                    {
                        tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "Error");
                        compararSintaxis(tokenNuevo);
                    }
                    break;
                case 63:
                    tokenNuevo = new Token(palabra, "Negro", "Enter");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 41:
                    tokenNuevo = new Token(palabra, contadorfila, columnatemp - contadorcolumna, "ID");
                    compararSintaxis(tokenNuevo);
                    break;
                case 42:
                    tokenNuevo = new Token(palabra, "Blanco", "Coma");
                    compararSintaxis(tokenNuevo);
                    break;
                case 43:
                    tokenNuevo = new Token(palabra, "Blanco", "Corchete");
                    compararSintaxis(tokenNuevo);
                    break;
            }
            contadorcolumna = 0;
        }
        /// <summary>
        /// Metodo para obtener nuestro token
        /// </summary>
        /// <returns></returns>
        public ArrayList getTokens()
        {
            return listaTokens;
        }
        /// <summary>
        /// Metodo para vaciar el arraylist
        /// </summary>
        public void vaciarLista()
        {
            listaTokens.Clear();
        }


        public void compararSintaxis(Token token)
        {
            if (parserer.automataPila(token)==false)
            {
                token.setTipo("Error");
            }
            listaTokens.Add(token);
                    
        }
    }
}
