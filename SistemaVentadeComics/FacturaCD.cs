using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class FacturaCD
    {
       
        public static void InsertarFactura(Entidades.Factura of)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarFactura(of.Id_cliente, of.Fecha,of.Iva,of.Subtotal,of.Total);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla Factura", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<CP_ListarFacturaResult> ListarFactura()
        {
            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    return DB.CP_ListarFactura().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al listar el procedimiento Listar PA Factura", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
