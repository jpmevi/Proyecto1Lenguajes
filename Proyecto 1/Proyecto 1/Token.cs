using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Token
    {

        //Atributos de nuestro objeto
        private string token;
        private string color;
        private int fila;
        private int columna;
        private string valor;
        

        /// <summary>
        /// Constructor de nuestro objeto
        /// </summary>
        /// <param name="token"></param>
        /// <param name="color"></param>
        /// <param name="valor"></param>
        public Token(string token, string color, string valor)
        {
            this.token = token;
            this.color = color;
            this.valor = valor;
        }

        public Token(string token, int fila, int columna, string valor)
        {
            this.token = token;
            this.columna = columna;
            this.fila = fila;
            this.columna = columna;
            this.valor = valor;
        }


       /// <summary>
       /// Metodo para obtener el tipo de nuestro objeto
       /// </summary>
       /// <returns></returns>
        public string getTipo()
        {
            return this.valor;
        }
        /// <summary>
        /// Metodo que returna nuestro token
        /// </summary>
        /// <returns></returns>
        public string getToken()
        {
            return this.token;
        }
        public int getFila()
        {
            return this.fila;
        }
        public int getColumna()
        {
            return this.columna;
        }
    }
}
