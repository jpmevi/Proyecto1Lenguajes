using System;
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
    public partial class Form1 : Form
    {
        Archivos archivo = new Archivos();
        GeneradorTokens tokensclase = new GeneradorTokens();
        Token tokens;
        public Form1()
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

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string texto = archivo.leerArchivo(openFileDialog1);
            richTextBox1.Text = texto;
            label1.Text = archivo.getnombre();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.guardarComo(saveFileDialog1, richTextBox1.Text);
            label1.Text = archivo.getnombre();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.guardar(richTextBox1);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo.archivonuevo(saveFileDialog1, richTextBox1);
            label1.Text = archivo.getnombre();
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tokensclase.vaciarLista();
            tokensclase.separarTokens(richTextBox1.Text);
            ArrayList listatokens = tokensclase.getTokens();
            richTextBox1.Clear();
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
                        }
                        
                        break;
                    case "Enter":
                        richTextBox1.AppendText(Environment.NewLine);
                        break;
                }
                richTextBox1.SelectionColor = Color.White;
                
            }
            
        }
    }
}
