﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    public partial class IDE : Form
    {
        //Generamos nuestros objetos
        Archivos archivo = new Archivos();
        GeneradorTokens tokensclase = new GeneradorTokens();
        public IDE()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Llamamos nuestro metodo para abir archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string texto = archivo.leerArchivo(openFileDialog1);
            richTextBox1.Clear();
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.AppendText(texto);
            label5.Text = archivo.getnombre();
            richTextBox1.SelectionColor = Color.White;
            
        }

        /// <summary>
        /// Llamamos nuestro metodo para guardar como
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.guardarComo(saveFileDialog1, richTextBox1.Text);
            label5.Text = archivo.getnombre();
        }
        /// <summary>
        /// Llamamos nuestro metodo para guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.guardar(richTextBox1);
        }
        /// <summary>
        /// Llamamos nuestro metodo para crear nuevo archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.archivonuevo(saveFileDialog1, richTextBox1);
            label5.Text = archivo.getnombre();
            richTextBox1.Text = "";
        }

        /// <summary>
        /// Obtenemos lo que escribio el usuario y lo comparamos con los tokens para que los vaya pintando e imprimiendo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            tokensclase.vaciarLista();
            tokensclase.separarTokens(richTextBox1.Text);
            ArrayList listatokens = tokensclase.getTokens();
            richTextBox1.Clear();
            richTextBox2.Clear();
            for (int i = 0; i < listatokens.Count; i++)
            {
                Token tokenizer = (Token)listatokens[i];
                switch (tokenizer.getTipo())
                {
                    case "Entero":
                        richTextBox1.SelectionColor = Color.Orchid;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Decimal":
                        richTextBox1.SelectionColor = Color.LightBlue;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Cadena":
                        richTextBox1.SelectionColor = Color.DarkGray;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "OperadorAritmetico":
                        richTextBox1.SelectionColor = Color.SteelBlue;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "OperadorLogico":
                        richTextBox1.SelectionColor = Color.SteelBlue;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Signo":
                        richTextBox1.SelectionColor = Color.SteelBlue;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "OperadorRelacional":
                        richTextBox1.SelectionColor = Color.SteelBlue;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Sentencia":
                        richTextBox1.SelectionColor = Color.Pink;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Caracter":
                        richTextBox1.SelectionColor = Color.Sienna;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Booleano":
                        richTextBox1.SelectionColor = Color.Orange;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Comentario":
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        break;
                    case "Error":
                        if (tokenizer.getToken().Equals("SI") || tokenizer.getToken().Equals("SINO") || tokenizer.getToken().Equals("SINO_SI") || tokenizer.getToken().Equals("MIENTRAS") || tokenizer.getToken().Equals("HACER") || tokenizer.getToken().Equals("DESDE") || tokenizer.getToken().Equals("HASTA") || tokenizer.getToken().Equals("INCREMENTO"))
                        {
                            richTextBox1.SelectionColor = Color.Green;
                            richTextBox1.AppendText(tokenizer.getToken());
                            richTextBox1.AppendText(" ");
                        }else{
                        richTextBox1.SelectionColor = Color.Yellow;
                        richTextBox1.AppendText(tokenizer.getToken());
                        richTextBox1.AppendText(" ");
                        richTextBox2.SelectionColor = Color.Yellow;
                        richTextBox2.AppendText(tokenizer.getToken());
                        richTextBox2.AppendText(Environment.NewLine);
                        }
                        
                        break;
                    case "Enter":
                        richTextBox1.AppendText(Environment.NewLine);
                        break;
                }
                richTextBox1.SelectionColor = Color.White;
                
            }
            
        }

        /// <summary>
        /// Hacemos que cuente la linea y la columna cada vez que presione el mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(index);

            int firstChar = richTextBox1.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            label3.Text = Convert.ToString("Linea: "+(line+1));
            label4.Text = Convert.ToString("Columna: " + column);
            richTextBox1.SelectionColor = Color.White;
        }

        /// <summary>
        /// Llamamos el metodo de guardar como para que exporte los errores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void erroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length>0)
            {
                archivo.guardarComo(saveFileDialog1, richTextBox2.Text);
            }else{
                MessageBox.Show("No hay ningun error para exportar");
            }
            
        }

        /// <summary>
        /// Cada vez que presiona una tecla va cambiando la fila y columna 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int index = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(index);

            int firstChar = richTextBox1.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;
            label3.Text = Convert.ToString("Linea: " + (line + 1));
            label4.Text = Convert.ToString("Columna: " + column);
            richTextBox1.SelectionColor = Color.White;
        }

        /// <summary>
        /// Guardamos el archivo actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            archivo.guardar(richTextBox1);
        }

        /// <summary>
        /// Limpiamos los cuadros de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        /// <summary>
        /// Cambiamos el color al default cuando salga del cuadro de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.White;
        }
    }
}