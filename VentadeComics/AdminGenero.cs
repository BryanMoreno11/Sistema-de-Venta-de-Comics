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
    public partial class AdminGenero : Form
    {
        public AdminGenero()
        {
            InitializeComponent();
        }
        //variables globales
        GeneroLN ogl = new GeneroLN();
        
        public void listarGenero(string var)
        {
            dataGridView1.DataSource = ogl.ViewGeneroFiltro(var).ToList();
        }


        private void AdminGenero_Load(object sender, EventArgs e)
        {
            listarGenero(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditGenero frm = new EditGenero();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Genero og = frm.CrearObjeto("Insertar");
                ogl.CreateGenero(og);
                frm.Hide();
                listarGenero(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                Genero og = dataGridView1.CurrentRow.DataBoundItem as Genero;
                EditGenero frm = new EditGenero();
                frm.auxiliar = og;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ogl.UpdateGenero(frm.CrearObjeto("Modificar"));
                    frm.Hide();
                    listarGenero(textBox1.Text);
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

                ogl.DeleteGenero(dataGridView1.CurrentRow.DataBoundItem as Genero);
                listarGenero(textBox1.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarGenero(textBox1.Text);
        }
    }
}
