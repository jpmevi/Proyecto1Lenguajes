using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    class GeneradorTokens
    {
        private string[] tokens;
        private int contador = 0;


        public void separarTokens(String texto)
        {
            texto = texto + " ";
            tokens = new string[texto.Length];
            char caracter;
            string tempToken = "";
            bool comillas = false;

            for (int i = 0; i < texto.Length; i++)
            {
               
                caracter = texto[i];
                switch (caracter)
                {
                    case ' ':
                    case '\r':
                    case '\t':
                    case '\b':
                    case '\f':
                        if (!tempToken.Equals(" ") && comillas == false)
                        {
                            if (!tempToken.Equals(""))
                            {
                                almacenarTokens(tempToken);
                            }
                            almacenarTokens("espacio");
                            tempToken = "";
                        }else if(comillas==true){
                            tempToken += caracter;
                        }
                        break;
                    case '\n':
                         if (!tempToken.Equals("") && comillas == false)
                        {
                            almacenarTokens(tempToken);
                            almacenarTokens("enter");
                            tempToken = "";
                        }
                         else if (comillas == true)
                         {
                             tempToken += caracter;
                         }
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '<':
                    case '>':
                    case '=':
                    case '(':
                    case ')':
                    case '!':
                    case ';':
                        if (!tempToken.Equals("") && comillas == false)
                        {
                            almacenarTokens(tempToken);
                            almacenarTokens(caracter.ToString());
                            tempToken = "";
                        }else if(comillas==true){
                            tempToken += caracter;
                        }
                        break;
                    case '"':
                        if (comillas == false)
                        {
                            if(!tempToken.Equals("")){
                                almacenarTokens(tempToken);
                                tempToken = "";
                            }
                            comillas = true;
                            tempToken = tempToken + caracter;
                        }
                        else if (comillas == true)
                        {
                            tempToken = tempToken + caracter;
                            almacenarTokens(tempToken);
                            tempToken = "";
                            comillas = false;
                        }
                        break;
                    default:
                        tempToken = tempToken + caracter;
                        break;

                }
            }
        }

        public void almacenarTokens(string token)
        {
            tokens[contador] = token;
            contador++;
        }

        private string[] refactorarArray()
        {
            int cont = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] != null )
                {
                    cont++;
                    
                }
            }
            string[] tokensfinal = new string[cont];
            for (int i = 0; i < tokensfinal.Length; i++)
            {

                    tokensfinal[i] = tokens[i];
                
            }
            return tokensfinal;
        }

        public string[] gettokens()
        {
            return refactorarArray();
        }
    }
}
