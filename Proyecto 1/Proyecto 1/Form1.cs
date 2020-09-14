using System;
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
            archivo.guardarComo(saveFileDialog1,richTextBox1.Text);
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
            tokensclase.separarTokens(richTextBox1.Text);
            string[] tokens = tokensclase.gettokens();
            int tokenslenght = tokens.Length;
            for (int i = 0; i < tokens.Length; i++)
            {
                richTextBox2.Text += tokens[i]+ Environment.NewLine;
            }
        }
    }
}
