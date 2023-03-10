using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FacturaLN
    {
        public int getFacturaID()
        {
            List<Entidades.Factura> lista = new List<Entidades.Factura>();
            Entidades.Factura of;

            try
            {
                List<CP_ListarFacturaResult> auxLista = FacturaCD.ListarFactura();
                foreach (CP_ListarFacturaResult obj in auxLista)
                {
                    of = new Entidades.Factura(obj.id, obj.id_cliente, obj.fecha, obj.iva, obj.subtotal, obj.Total);
                    lista.Add(of);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al mostar serie con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista[lista.Count-1].Id;
        }

        public bool CreateFactura(Entidades.Factura of)
        {

            try
            {
                FacturaCD.InsertarFactura(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar factura en la BD");
            }
        }


    }
}
