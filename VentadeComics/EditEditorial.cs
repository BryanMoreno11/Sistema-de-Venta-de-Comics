using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentadeComics
{
    public partial class EditEditorial : Form
    {
        public EditEditorial()
        {
            InitializeComponent();
        }
        //variables globales
        public Editorial auxiliar;
        private void EditEditorial_Load(object sender, EventArgs e)
        {

        }
        public Editorial CrearObjeto(string metodo)
        {
            Editorial oe;
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            if (metodo.Equals("Insertar"))
                oe = new Editorial(nombre, descripcion);
            else
                oe = new Editorial(auxiliar.Id, nombre, descripcion);
            return oe;

        }

        public void setDatos()
        {
            textBox1.Text = auxiliar.Nombre;
            textBox2.Text = auxiliar.Descripcion;
        }

        public bool validar()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Ingrese correctamente los datos");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DialogResult = DialogResult.OK;
            }    
        }
    }
}
