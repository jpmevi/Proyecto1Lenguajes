using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    public partial class Arbol : Form
    {
        public Arbol()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Arbol_Shown(object sender, EventArgs e)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"..\arbol.jpeg");
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            pictureBox1.Image = Image.FromStream(ms); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile= new SaveFileDialog();
                //Filtro para .gt
                savefile.Filter = "jpg files (*.jpeg)|*.jpeg";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    //Comprueba si el archivo existe
                    if (File.Exists(savefile.FileName))
                    {
                        //Mandamos los datos a la direccion del archivo
                        string gt = savefile.FileName;
                        Graphviz g = new Graphviz();
                        g.crearGrafo(IDE.nodos, gt);
                        this.Close();
                    }
                    else
                    {
                        //Mandamos los datos a la direccion del archivo
                        string gt = savefile.FileName;
                        Graphviz g = new Graphviz();
                        g.crearGrafo(IDE.nodos, gt);
                        this.Close();
                    }
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar");
            }
        
    }
    }
}
