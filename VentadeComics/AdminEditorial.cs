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
    public partial class AdminEditorial : Form
    {
        public AdminEditorial()
        {
            InitializeComponent();
        }
        //variables globales
        EditorialLN oel = new EditorialLN();

        public void listarEditorial(string valor)
        {
            dataGridView1.DataSource = oel.ViewEditorialFiltro(valor).ToList();
        }
        private void AdminEditorial_Load(object sender, EventArgs e)
        {
            listarEditorial(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarEditorial(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditEditorial frm = new EditEditorial();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Editorial oe = frm.CrearObjeto("Insertar");
                oel.CreateEditorial(oe);
                frm.Hide();
                listarEditorial(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                Editorial oe = dataGridView1.CurrentRow.DataBoundItem as Editorial;
                EditEditorial frm = new EditEditorial();
                frm.auxiliar = oe;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    oel.UpdateEditorial(frm.CrearObjeto("Modificar"));
                    frm.Hide();
                    listarEditorial(textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                oel.DeleteEditorial(dataGridView1.CurrentRow.DataBoundItem as Editorial);
                listarEditorial(textBox1.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
