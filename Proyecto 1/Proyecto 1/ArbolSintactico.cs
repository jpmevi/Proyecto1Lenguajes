using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_1
{
    class ArbolSintactico
    {
       private string path;
       private string path2;

        public void crearArchivo(String nombre)
        {
            //Path de la carpeta
            path = @"..\Arboles";
            //Path del archivo
            path2 = path + @"\"+nombre+".txt";
            //Crear carpeta
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            //Crear archivo
            if (!File.Exists(path2))
            {
                //Crea el archivo
                using (StreamWriter sw = File.CreateText(path2))
                {
                    sw.Close();
                }
                //Le agrega texto al archivo
                ingresarTexto("PRUEBA");
            }
        }

        public void ingresarTexto(string texto)
        {
            //Le agrega texto al archivo
            using (StreamWriter sw = File.AppendText(path2))
            {
                sw.WriteLine(texto);
                sw.Close();
            }
        }

        static void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
    }
}
