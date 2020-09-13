using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Proyecto_1
{
    class Archivos
    {
        //Atributos de nuestro objeto
        private string patharchivo;
        private FileInfo pathnombre;
        private string nombre;


        public String openFileDialog(OpenFileDialog openFile)
        {

            String fileContent = string.Empty;
            String path = string.Empty;
            //Filtro del filedialog
            openFile.Filter = "gt files (*.gt)|*.gt";
            //If para abrir el archivo
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Ruta del archivo

                setpathActual(openFile.FileName);

                path = openFile.FileName;
            }
            else
            {
                MessageBox.Show("El archivo seleccionado no es valido");
            }
            return path;
        }


        //Merodo para leer el archivo
        public String leerArchivo(OpenFileDialog open)
        {
            string contenido = "";
            try
            {
                //Obtenemos la direccion y el filedialog 
                openFileDialog(open);
                string path = getpath();

                //Usamos StramReader para leer el archivo
                using (StreamReader oSR = File.OpenText(path))
                {
                    string s = "";
                    while ((s = oSR.ReadLine()) != null)
                    {
                        contenido += s + Environment.NewLine;
                    }
                }
                //Establecemos el nombre del archivo
                pathnombre = new FileInfo(getpath());
                nombre = pathnombre.Name;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el archivo");
            }
            //Regresamos el contenido del archivo
            return contenido;
        }

        //Metodo para guardar un documento y ponerle nombre
        public void guardarComo(SaveFileDialog savefile, String contenidotexto)
        {
            try
            {
                //Filtro para .gt
                savefile.Filter = "gt files (*.gt)|*.gt";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    //Comprueba si el archivo existe
                    if (File.Exists(savefile.FileName))
                    {
                        //Mandamos los datos a la direccion del archivo
                        string gt = savefile.FileName;
                        StreamWriter textoguardar = File.CreateText(gt);
                        textoguardar.Write(contenidotexto);
                        //Cerrramos el Streamwriter
                        textoguardar.Flush();
                        textoguardar.Close();
                        setpathActual(gt);
                    }
                    else
                    {
                        //Mandamos los datos a la direccion del archivo
                        string gt = savefile.FileName;
                        StreamWriter textoguardar = File.CreateText(gt);
                        textoguardar.Write(contenidotexto);
                        //Cerrramos el Streamwriter
                        textoguardar.Flush();
                        textoguardar.Close();
                        setpathActual(gt);
                    }
                }
                //Establecemos el nombre del archivo
                pathnombre = new FileInfo(getpath());
                nombre = pathnombre.Name;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar");
            }
        }

        //Metodo para guardar archivo
        public void guardar(RichTextBox richbox)
        {
            try
            {
                //Usamos la propiedad del richtextbox para guardar texto en un archivo
                richbox.SaveFile(getpath(), RichTextBoxStreamType.PlainText);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo guardar el archivo");
            }
        }

        //Metodo para crear un archivo nuevo
        public void archivonuevo(SaveFileDialog savefile, RichTextBox rich)
        {
            try
            {
                //Filtro para que solo busque .gt
                savefile.Filter = "gt files (*.gt)|*.gt";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(savefile.FileName))
                    {
                        //Comparamos si tiene texto el archivo actual y si lo quiere guardar
                        if (rich.Text.Length > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Desea Guardar el archivo antes de crear uno nuevo?", "Guardar archivo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                guardar(rich);
                            }
                        }

                        string gt = savefile.FileName;
                        setpathActual(gt);
                    }
                    else
                    {
                        //Comparamos si tiene texto el archivo actual y si lo quiere guardar
                        if (rich.Text.Length > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("Desea Guardar el archivo antes de crear uno nuevo?", "Guardar archivo", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                guardar(rich);
                            }
                        }

                        //Establecemos la direccion del archivo
                        string gt = savefile.FileName;
                        setpathActual(gt);
                    }
                }

                //Establecemos el nombre del archivo
                pathnombre = new FileInfo(getpath());
                nombre = pathnombre.Name;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al crear archivo");
            }
        }

        //Metodos Get y set
        public String getpath()
        {
            return this.patharchivo;
        }
        public void setpathActual(String path)
        {
            this.patharchivo = path;
        }
        public String getnombre()
        {
            return this.nombre;
        }
    }

}
