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
               SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Filter = "JPEG(.JPG)|.JPG|BMP(.BMP)|.BMP|PNG(.PNG)|.PNG";
            Image Imagen = pictureBox1.Image;
            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                Imagen.Save(Guardar.FileName);
                MessageBox.Show("Se guardo exitosamente");
                this.Close();
            }
                  
                    
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar");
            }
        
    }
    }
}
