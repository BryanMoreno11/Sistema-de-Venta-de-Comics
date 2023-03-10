using Entidades;
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

namespace VentadeComics
{
    public partial class AdminComic : Form
    {
        public AdminComic()
        {
            InitializeComponent();
        }
        //variables globales
        ComicLN ocl= new ComicLN();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void listarComic(string valor, string tipo)
        {
            dataGridView1.DataSource = ocl.ViewComicVistaFiltro(valor, tipo).ToList();
        }
        private void AdminComic_Load(object sender, EventArgs e)
        {
            listarComic(textBox1.Text, "Miniatura");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditComic frm = new EditComic();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Comic oc = frm.CrearObjeto("Insertar");
                ocl.CreateComic(oc);
                frm.Hide();
                listarComic(textBox1.Text, "Miniatura");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Esta seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        ComicPersonalizado objeto = dataGridView1.CurrentRow.DataBoundItem as ComicPersonalizado;
                        Comic oc = ocl.getComic(objeto.Id);
                        ocl.DeleteComic(oc);
                        listarComic("","Miniatura");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int row = dataGridView1.CurrentRow.Index;
                listarComic(textBox1.Text, "Completo");
                ComicPersonalizado oc = dataGridView1.Rows[row].DataBoundItem as ComicPersonalizado;
                listarComic(textBox1.Text, "Miniatura");
                EditComic frm = new EditComic();
                frm.auxiliar = oc;
                frm.opc=1;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ocl.UpdateComic(frm.CrearObjeto("Modificar"));
                    frm.Hide();
                    listarComic(textBox1.Text, "Miniatura");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarComic(textBox1.Text, "Miniatura");
        }
    }
}
