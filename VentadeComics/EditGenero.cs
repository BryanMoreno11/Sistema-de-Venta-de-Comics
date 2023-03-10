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
    public partial class EditGenero : Form
    {
        public EditGenero()
        {
            InitializeComponent();
        }
        //Variables globales
        public Genero auxiliar = new Genero();
        private void EditGenero_Load(object sender, EventArgs e)
        {

        }
        public Genero CrearObjeto(string metodo)
        {
            Genero og;
            string nombre = textBox1.Text;    
            string descripcion = textBox2.Text;
            if (metodo.Equals("Insertar"))
                og = new Genero(nombre, descripcion);
            else
                og = new Genero(auxiliar.Id, nombre,  descripcion);
            return og;

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
