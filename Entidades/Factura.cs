using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        private int id;
        private int id_cliente;
        private DateTime fecha;
        private decimal iva;
        private decimal subtotal;
        private decimal total;

        public Factura()
        {
        }

        public Factura(int id_cliente, DateTime fecha, decimal iva, decimal subtotal, decimal total)
        {
            this.Id_cliente = id_cliente;
            this.Fecha = fecha;
            this.Iva = iva;
            this.Subtotal = subtotal;
            this.Total = total;
        }

        public Factura(int id,int id_cliente, DateTime fecha, decimal iva, decimal subtotal, decimal total)
        {
            this.Id = id;
            this.Id_cliente = id_cliente;
            this.Fecha = fecha;
            this.Iva = iva;
            this.Subtotal = subtotal;
            this.Total = total;
        }

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Total { get => total; set => total = value; }
        public int Id { get => id; set => id = value; }
    }
}
