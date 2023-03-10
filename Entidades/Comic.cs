using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comic
    {
        private int id;
        private string nombre;
        private int id_serie;
        private int id_genero;
        private int id_autor;
        private int id_editorial;
        private string descripcion;
        private decimal precio;
        private int stock;
        private byte[] imagen;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id_serie { get => id_serie; set => id_serie = value; }
        public int Id_genero { get => id_genero; set => id_genero = value; }
        public int Id_autor { get => id_autor; set => id_autor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public int Id_editorial { get => id_editorial; set => id_editorial = value; }

        public Comic(string nombre, int id_serie, int id_genero, int id_autor, int id_editorial,string descripcion, decimal precio, int stock, byte[] imagen)
        {
            this.Nombre = nombre;
            this.Id_serie = id_serie;
            this.Id_genero = id_genero;
            this.Id_autor = id_autor;
            this.Id_editorial = id_editorial;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.Imagen = imagen;
        }

        public Comic()
        {
        }

        public Comic(int id, string nombre, int id_serie, int id_genero, int id_autor, int id_editorial,string descripcion, decimal precio, int stock, byte[] imagen)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Id_serie = id_serie;
            this.Id_genero = id_genero;
            this.Id_autor = id_autor;
            this.Id_editorial = id_editorial;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.Imagen = imagen;
        }
    }

}
