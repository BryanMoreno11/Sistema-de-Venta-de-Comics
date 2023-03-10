using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentaComics
    {
        private int id;
        private string nombre;
        private decimal precio;
        private int cantidad;

        public VentaComics()
        {
        }

        public VentaComics(int id, string nombre, decimal precio, int cantidad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
