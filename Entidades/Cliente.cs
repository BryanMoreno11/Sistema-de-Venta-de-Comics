using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellido;
        private char sexo;
        private string cedula;
        private DateTime fecha;
        private string direccion;
        private string telefono;
        private string correo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Cedula { get => cedula; set => cedula = value; }

        public Cliente(int id, string nombre, string apellido, char sexo,string cedula, DateTime fecha, string direccion, string telefono, string correo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Cedula = cedula;
            this.Fecha = fecha;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public Cliente( string nombre, string apellido, char sexo,string cedula, DateTime fecha, string direccion, string telefono, string correo)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Cedula = cedula;
            this.Fecha = fecha;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }
    }
}
