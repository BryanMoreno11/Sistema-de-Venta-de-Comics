using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Serie
    {
        private int id;
        private string nombre;
        private string descripcion;
        private byte[] imagen;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }

        public Serie(int id,string nombre, string descripcion, byte[] imagen)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }
        public Serie(string nombre, string descripcion, byte[] imagen)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }

    }
}
