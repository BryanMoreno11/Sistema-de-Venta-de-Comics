using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VentadeComics
{
    public partial class EditAutor : Form
    {
        public EditAutor()
        {
            InitializeComponent();
        }
        //variables globales
        public Autor auxiliar;
        public Autor CrearObjeto(string metodo)
        {
            Autor oa;
            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string descripcion = textBox3.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imagen = ms.ToArray();
            if (metodo.Equals("Insertar"))
                oa = new Autor(nombre, apellido,descripcion, imagen);
            else
                oa = new Autor(auxiliar.Id, nombre,apellido, descripcion, imagen);
            return oa;

        }

        public void setDatos()
        {
            textBox1.Text = auxiliar.Nombre;
            textBox2.Text = auxiliar.Apellido;
            textBox3.Text = auxiliar.Descripcion;
            if (auxiliar.Imagen != null)
            {
                byte[] img = (byte[])auxiliar.Imagen;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        public bool validar()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Ingrese correctamente los datos");
                return false;
            }
            return true;
        }

        private void EditAutor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            DialogResult dr = of.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(of.FileName);
            }
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
