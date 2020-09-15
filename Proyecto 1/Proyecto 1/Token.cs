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
        private string token;
        private string color;
        private string valor;
        


        public Token(string token, string color, string valor)
        {
            this.token = token;
            this.color = color;
            this.valor = valor;
        }


       
        public string getTipo()
        {
            return this.valor;
        }
        public string getToken()
        {
            return this.token;
        }
    }
}
