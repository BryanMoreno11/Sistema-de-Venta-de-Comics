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
    public partial class AdminAutor : Form
    {
        public AdminAutor()
        {
            InitializeComponent();
        }
        //variables globales
        AutorLN oal = new AutorLN();
        public void ListarAutor(string var, string tipo)
        {
            dataGridView1.DataSource = oal.ViewAutorFiltro(var, tipo);
        }

        private void AdminAutor_Load(object sender, EventArgs e)
        {
            ListarAutor(textBox1.Text, "Miniatura");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListarAutor(textBox1.Text, "Miniatura");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            EditAutor frm = new EditAutor();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Autor oa = frm.CrearObjeto("Insertar");
                oal.CreateAutor(oa);
                frm.Hide();
                ListarAutor(textBox1.Text, "Miniatura");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                int row = dataGridView1.CurrentRow.Index;
                ListarAutor(textBox1.Text, "Completo");
                Autor oa = dataGridView1.Rows[row].DataBoundItem as Autor;
                ListarAutor(textBox1.Text, "Miniatura");
                EditAutor frm = new EditAutor();
                frm.auxiliar = oa;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    oal.UpdateAutor(frm.CrearObjeto("Modificar"));
                    frm.Hide();
                    ListarAutor(textBox1.Text, "Miniatura");
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
                oal.DeleteAutor(dataGridView1.CurrentRow.DataBoundItem as Autor);
                ListarAutor(textBox1.Text, "Miniatura");
            }catch(Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
