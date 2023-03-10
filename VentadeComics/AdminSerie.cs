using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentadeComics
{
    public partial class AdminSerie : Form
    {
        SerieLN osl= new SerieLN();
        public AdminSerie()
        {
            InitializeComponent();
        }

        public void ListarSerie(string var, string tipo)
        {
            dataGridView1.DataSource = osl.ViewSerieFiltro(var,tipo).ToList();

        }

    
        
        private void AdminSerie_Load(object sender, EventArgs e)
        {
            ListarSerie(textBox1.Text,"Miniatura");
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListarSerie(textBox1.Text,"Miniatura");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            EditSerie frm = new EditSerie();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Serie os = frm.CrearObjeto("Insertar");
                osl.CreateSerie(os);
                frm.Hide();
                ListarSerie(textBox1.Text,"Miniatura");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                int row = dataGridView1.CurrentRow.Index;
                ListarSerie(textBox1.Text, "Completo");
                Serie os = dataGridView1.Rows[row].DataBoundItem as Serie;
                ListarSerie(textBox1.Text, "Miniatura");
                EditSerie frm = new EditSerie();
                frm.auxiliar = os;
                frm.setDatos();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    osl.UpdateSerie(frm.CrearObjeto("Modificar"));
                    frm.Hide();
                    ListarSerie(textBox1.Text, "Miniatura");
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

                osl.DeleteSerie(dataGridView1.CurrentRow.DataBoundItem as Serie);
                ListarSerie(textBox1.Text, "Miniatura");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
    }
   
}
