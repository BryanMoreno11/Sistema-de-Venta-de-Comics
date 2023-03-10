using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {
        private int id_factura;
        private int id_comic;
        private int cantidad;

        public int Id_factura { get => id_factura; set => id_factura = value; }
        public int Id_comic { get => id_comic; set => id_comic = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public DetalleFactura(int id_factura, int id_comic, int cantidad)
        {
            this.Id_factura = id_factura;
            this.Id_comic = id_comic;
            this.Cantidad = cantidad;
        }

        public DetalleFactura()
        {
        }

    }
}
