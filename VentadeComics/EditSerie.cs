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
    public partial class EditSerie : Form
    {
        public EditSerie()
        {
           
            InitializeComponent();
        }
        
        public Serie auxiliar;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
        public Serie CrearObjeto(string metodo)
        {
            Serie os;
            string nombre = textBox1.Text;
            string descripcion = textBox2.Text;
            System.IO.MemoryStream ms= new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imagen = ms.ToArray();
            if(metodo.Equals("Insertar"))
                os = new Serie(nombre,descripcion,imagen);
            else
                os = new Serie(auxiliar.Id,nombre, descripcion, imagen);
            return os;

        }
        
        public void setDatos()
        {
            textBox1.Text = auxiliar.Nombre;
            textBox2.Text = auxiliar.Descripcion; 
            if (auxiliar.Imagen != null)
            {
                byte[] img = (byte[])auxiliar.Imagen;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }
        
        public bool validar()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || pictureBox1.Image==null )
            {
                MessageBox.Show("Ingrese correctamente los datos");
                return false;
            }
            return true;
        }
        private void EditSerie_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
