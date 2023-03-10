using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DetalleFacturaLN
    {
        public bool CreateDetalleFactura(Entidades.DetalleFactura of)
        {

            try
            {
                DetalleFacturaCD.InsertarDetalleFactura(of);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar detalle factura en la BD");
            }
        }
    }
}
