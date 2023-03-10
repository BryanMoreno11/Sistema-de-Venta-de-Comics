using Logica;
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
    public partial class EditComic : Form
    {
        public EditComic()
        {
            InitializeComponent();
        }
        //variables globales
        public ComicPersonalizado auxiliar;
        public int opc;
        public Comic CrearObjeto(string metodo)
        {
            Comic oc;
            string nombre = textBox1.Text;
            int serie = int.Parse(textBox2.Text);
            int genero = (int) comboBox1.SelectedValue;
            int editorial = (int)comboBox2.SelectedValue;
            int autor= int.Parse(textBox3.Text);
            string descripcion = textBox4.Text;
            decimal precio = decimal.Parse(textBox5.Text);
            int stock = int.Parse(textBox6.Text);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imagen = ms.ToArray();
            if (metodo.Equals("Insertar"))
                oc = new Comic(nombre,serie,genero,autor,editorial,descripcion,precio,stock,imagen);
            else
                oc = new Comic(auxiliar.Id,nombre, serie, genero, autor,editorial, descripcion, precio, stock, imagen);      
            return oc;
        }

        private void setDatos()
        {
            ComicLN ocl = new ComicLN();
            Comic ob = ocl.getComic(auxiliar.Id);
            textBox1.Text = auxiliar.Nombre;
            textBox2.Text = ob.Id_serie.ToString();
            comboBox1.Text= auxiliar.Genero;
            comboBox2.Text = auxiliar.Editorial;
            textBox3.Text = ob.Id_autor.ToString();
            textBox4.Text = auxiliar.Descripcion;
            textBox5.Text = auxiliar.Precio.ToString();
            textBox6.Text= auxiliar.Stock.ToString();
            if (auxiliar.Imagen != null)
            {
                byte[] img = (byte[])auxiliar.Imagen;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            } 
        }
        public bool validar()
        {
            try
            {
                decimal.Parse(textBox5.Text);
                int.Parse(textBox6.Text);
            }
            catch(Exception ex)
            {
                return false;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedIndex<0 || pictureBox1.Image == null)
            {      
                return false;
            }
            return true;
        }
        public void MostrarComboBoxGenero()
        {
            GeneroLN ogln = new GeneroLN();
            comboBox1.DataSource = ogln.ViewGeneroFiltro("");
            comboBox1.SelectedIndex = 0;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }

        public void MostrarComboBoxEditorial()
        {
            EditorialLN oel = new EditorialLN();
            comboBox2.DataSource = oel.ViewEditorialFiltro("");
            comboBox2.SelectedIndex = 0;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id";
        }

        public void CargarSeries()
        {
            try
            {
                frmSerie frm = new frmSerie();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    int id = frm.codigo;
                    textBox2.Text = id.ToString();
                }
                else
                {
                    frm.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void CargarAutores()
        {
            try
            {
                frmAutor frm = new frmAutor();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    int id = frm.codigo;
                    textBox3.Text = id.ToString();
                }
                else
                {
                    frm.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditComic_Load(object sender, EventArgs e)
        {
            MostrarComboBoxGenero();
            MostrarComboBoxEditorial();
            if (opc == 1 && auxiliar != null)
            {
                setDatos();
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            CargarSeries();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CargarAutores();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DialogResult = DialogResult.OK;      
            }
            else
                MessageBox.Show("Ingrese correctamente los datos");
        }
    }
}
