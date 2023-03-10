using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Entidades;
using Logica;
using Microsoft.VisualBasic;
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
    public partial class AdminVentas : Form
    {
        public AdminVentas()
        {
            InitializeComponent();
        }
        //variables globales
        public int idcliente;
        FacturaLN of = new FacturaLN();
        DetalleFacturaLN odf = new DetalleFacturaLN();
        ComicLN ocl = new ComicLN();
        public void listarComicsVenta()
        {
            dataGridView1.DataSource = ListaVentaComics.listaComics.ToList();
        }
        private void AdminVentas_Load(object sender, EventArgs e)
        {
            ListaVentaComics.VaciarLista();
        }
        public bool validar()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese bien los datos");
                return false;
            }
            else if (ListaVentaComics.listaComics.Count == 0)
            {
                MessageBox.Show("Debe comprar al menos un comic");
                return false;
            }
            else
                return true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmCliente frm = new frmCliente();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    idcliente = frm.id_persona;
                    textBox1.Text = idcliente.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmComic frm = new frmComic();
            frm.ShowDialog();
            listarComicsVenta();
            textBox2.Text = ListaVentaComics.CalcularIva().ToString();
            textBox3.Text = ListaVentaComics.CalcularSubtotal().ToString();
            textBox4.Text = ListaVentaComics.CalcularTotal().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ListaVentaComics.Delete(dataGridView1.CurrentRow.Index);
                listarComicsVenta();
                textBox2.Text = ListaVentaComics.CalcularIva().ToString();
                textBox3.Text = ListaVentaComics.CalcularSubtotal().ToString();
                textBox4.Text = ListaVentaComics.CalcularTotal().ToString();
            }
            catch(Exception ex)
            {

            }
        }
       
       
        private void button5_Click(object sender, EventArgs e)
        {       
            try {
                if (ListaVentaComics.listaComics.Count>0)
                {
                    int cantidad = int.Parse(Interaction.InputBox("Ingrese la cantidad de comics que desea comprar"));
                    int id_comic = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    int stock = ocl.getComic(id_comic).Stock;
                    if (stock >= cantidad)
                    {
                        ListaVentaComics.UpdateCantidad(dataGridView1.CurrentRow.Index, cantidad);
                        listarComicsVenta();
                    }
                    else
                        MessageBox.Show("No hay stock suficiente, únicamente contamos con " + stock + " items en el iventario");

                }else
                    MessageBox.Show("Debe seleccionar un comic");
            }
            catch(Exception ex)
            {
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string facturaPath;
            if (validar())
            {
                int id_cliente = int.Parse(textBox1.Text);
                DateTime fecha = dateTimePicker1.Value;
                decimal iva = decimal.Parse(textBox2.Text);
                decimal subtotal = decimal.Parse(textBox3.Text);
                decimal total = decimal.Parse(textBox4.Text);
                Factura factura = new Factura(idcliente, fecha, iva, subtotal, total);
                of.CreateFactura(factura);
                int id_factura = of.getFacturaID();
                foreach (VentaComics comic in ListaVentaComics.listaComics)
                {
                    DetalleFactura detalleFactura = new DetalleFactura(id_factura, comic.Id, comic.Cantidad);
                    odf.CreateDetalleFactura(detalleFactura);
                }
                MessageBox.Show("Venta realizada exitosamente!");
                ReporteFactura frm = new ReporteFactura();
                ReportDocument rep = new ReportDocument();
                ParameterField pf = new ParameterField();
                ParameterFields pfs = new ParameterFields();
                ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                pf.Name = "@idfactura";
                pdv.Value = id_factura;
                pf.CurrentValues.Add(pdv);
                pfs.Add(pf);
                frm.crystalReportViewer1.ParameterFieldInfo = pfs;
                string executablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string parentPath = Directory.GetParent(Directory.GetParent(executablePath).FullName).FullName;
                facturaPath = Path.Combine(parentPath, "ReportFactura.rpt");
                rep.Load(@facturaPath);
                frm.crystalReportViewer1.ReportSource = rep;
                frm.Show();
                parentPath = Directory.GetParent(parentPath).FullName;
                facturaPath = Path.Combine(parentPath, "Facturas PDF", "factura " + id_factura + ".pdf");
                MessageBox.Show("Factura Generada exitosamente!");  
                rep.ExportToDisk(ExportFormatType.PortableDocFormat, @facturaPath);
                ListaVentaComics.listaComics.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                listarComicsVenta();
            }
        }
    }
}
