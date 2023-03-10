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
    public partial class AdminCliente : Form
    {
        public AdminCliente()
        {
            InitializeComponent();
        }
        //variables globales
        ClienteLN ocl = new ClienteLN();
        public void listarCliente(string valor)
        {
            dataGridView1.DataSource = ocl.ViewClienteFiltro(valor).ToList();
        }
        private void AdminCliente_Load(object sender, EventArgs e)
        {
            listarCliente(textBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarCliente(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditCliente frm = new EditCliente();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Cliente oc = frm.CrearObjeto("Insertar");
                ocl.CreateCliente(oc);
                frm.Hide();
                listarCliente(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente oc = dataGridView1.CurrentRow.DataBoundItem as Cliente;
                EditCliente frm = new EditCliente();
                frm.auxiliar = oc;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ocl.UpdateCliente(frm.CrearObjeto("Modificar"));
                    frm.Hide();
                    listarCliente(textBox1.Text);
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

                ocl.DeleteCliente(dataGridView1.CurrentRow.DataBoundItem as Cliente);
                listarCliente(textBox1.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
