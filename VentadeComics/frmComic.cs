using Entidades;
using Logica;
using Microsoft.VisualBasic;
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
    public partial class frmComic : Form
    {
        public frmComic()
        {
            InitializeComponent();
        }
        //variables globales
        ComicLN ocl = new ComicLN();
        public void listarComic(string valor, string tipo)
        {
            dataGridView1.DataSource = ocl.ViewComicVistaFiltro(valor, tipo);
        }
        private void frmComic_Load(object sender, EventArgs e)
        {
            listarComic(textBox1.Text, "Miniatura");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarComic(textBox1.Text, "Miniatura");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ComicPersonalizado ob= dataGridView1.CurrentRow.DataBoundItem as ComicPersonalizado;           
                int cantidad = int.Parse(Interaction.InputBox("Ingrese la cantidad de comics que desea comprar"));
                if (ob.Stock < cantidad)
                {
                    MessageBox.Show("No hay stock suficiente, unicamente contamos con " + ob.Stock + " items en el iventario");
                }
                else
                {
                    VentaComics ov = new VentaComics(ob.Id, ob.Nombre, ob.Precio, cantidad);
                    ListaVentaComics.insert(ov);
                }
                

            }
            catch(Exception ex)
            {

            }
        }
    }
}
