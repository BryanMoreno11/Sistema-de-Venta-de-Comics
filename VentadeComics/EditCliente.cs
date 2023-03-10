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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VentadeComics
{
    public partial class EditCliente : Form
    {
        public EditCliente()
        {
            InitializeComponent();
        }
        //variables globales
        public Cliente auxiliar;
        public Cliente CrearObjeto(string metodo)
        {
            Cliente oc;
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            char sexo = Convert.ToChar(comboBox1.SelectedItem.ToString());
            string cedula = textCedula.Text;
            DateTime fecha = dateTimePicker1.Value;
            string direccion = textBox3.Text;
            string telefono = textBox4.Text;
            string correo = textBox5.Text;
            if (metodo.Equals("Insertar"))
                oc = new Cliente(nombre,apellido,sexo,cedula,fecha,direccion,telefono,correo);
            else
                oc = new Cliente(auxiliar.Id,nombre, apellido, sexo,cedula, fecha, direccion, telefono, correo);
            return oc;
        }

        public void setDatos()
        {
            textBox1.Text = auxiliar.Nombre;
            textBox2.Text = auxiliar.Apellido;
            comboBox1.Text = auxiliar.Sexo.ToString();
            dateTimePicker1.Value = auxiliar.Fecha;
            textBox3.Text = auxiliar.Direccion;
            textBox4.Text = auxiliar.Telefono;
            textBox5.Text = auxiliar.Correo;
            textCedula.Text = auxiliar.Cedula;
        }

        public bool validar()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textCedula.Text == "" || comboBox1.SelectedIndex<0)
            {
                MessageBox.Show("Ingrese correctamente los datos");
                return false;
            }
            return true;
        }
        private void EditCliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
