using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentadeComics
{
    public class DetalleFacturaCD
    {
        public static void InsertarDetalleFactura(Entidades.DetalleFactura of)
        {

            BDComicsDataContext DB = null;
            try
            {

                using (DB = new BDComicsDataContext())
                {
                    DB.CP_InsertarDetalleFactura(of.Id_factura, of.Id_comic, of.Cantidad);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new DatosExcepciones("Error al insertar tabla DetalleFactura", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
