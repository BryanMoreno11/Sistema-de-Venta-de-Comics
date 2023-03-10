using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        private int id;
        private string nombre;
        private string apellido;
        private string descripcion;
        private byte[] imagen;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }

        public Autor(int id, string nombre, string apellido, string descripcion, byte[] imagen)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }

        public Autor( string nombre, string apellido, string descripcion, byte[] imagen)
        { 
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
        }

        public Autor()
        {
        }
    }
}
