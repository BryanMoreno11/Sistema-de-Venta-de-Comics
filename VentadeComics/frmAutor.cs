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
    public partial class frmAutor : Form
    {
        public frmAutor()
        {
            InitializeComponent();
        }
        //variables globales
        AutorLN oal = new AutorLN();
        public int codigo = -1;

        public void listarAutor(string valor,string tipo) {
            dataGridView1.DataSource = oal.ViewAutorFiltro(valor, tipo).ToList();
            
        }
        private void frmAutor_Load(object sender, EventArgs e)
        {
            listarAutor(textBox1.Text, "Miniatura");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarAutor(textBox1.Text, "Miniatura");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                codigo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }
    }
}
