using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ListaVentaComics
    {
        public static List<VentaComics> listaComics = new List<VentaComics>();
        public static void insert(VentaComics ob)
        {
            listaComics.Add(ob);
        }

        public static void UpdateCantidad(int pos, int cantidad)
        {
            listaComics[pos].Cantidad=cantidad;
        }

        public static void Delete(int pos)
        {
            listaComics.RemoveAt(pos);
        }

        public static void VaciarLista()
        {
            listaComics.Clear();
        }

        public static decimal CalcularSubtotal()
        {
            return (decimal) listaComics.Sum(p => p.Cantidad * p.Precio);         
        }

        public static decimal CalcularIva()
        {
            return (decimal)listaComics.Sum(p => (p.Cantidad * p.Precio)*0.12m);
        }

        public static decimal CalcularTotal()
        {
            return (decimal)CalcularSubtotal() + CalcularIva();
        }
    }
}
