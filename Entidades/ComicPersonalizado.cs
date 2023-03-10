using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ComicPersonalizado
    {
        private int id;
        private string nombre;
        private string serie;
        private string genero;
        private string descripcion;
        private string editorial;
        private string autor;
        private decimal precio;
        private int stock;
        private byte[] imagen;
        public ComicPersonalizado()
        {
        }

        public ComicPersonalizado(int id, string nombre, string serie, string genero, string autor,string editorial,string descripcion,  decimal precio, int stock, byte[] imagen)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Serie = serie;
            this.Genero = genero;
            this.Autor = autor;
            this.Editorial = editorial;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.Imagen = imagen;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public string Editorial { get => editorial; set => editorial = value; }
    }
}
