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
    public partial class frmSerie : Form
    {
        public frmSerie()
        {
            InitializeComponent();
        }
        //variables globales
        SerieLN osl = new SerieLN();
        public int codigo = -1;

        public void listarSerie(string valor, string tipo)
        {
            dataGridView1.DataSource = osl.ViewSerieFiltro(valor, tipo).ToList();
        }
        
        private void frmSerie_Load(object sender, EventArgs e)
        {
            listarSerie(textBox1.Text, "Miniatura");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                codigo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarSerie(textBox1.Text, "Miniatura");
        }
    }
}
