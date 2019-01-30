using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargaArchivos_Hilos
{
    public partial class Hilos : Form
    {
        public Hilos()
        {
            InitializeComponent();
        }

        private void btnSeleccionArchivo_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog seleccion = new OpenFileDialog();
            seleccion.Filter = "Cursor Files|*.txt";
            seleccion.Title = "Selecciona un archivo de texto";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (seleccion.ShowDialog() == DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                this.Cursor = new Cursor(seleccion.OpenFile());
            }
        }
    }
}
