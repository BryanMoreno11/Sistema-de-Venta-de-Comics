using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EditorialLN
    {
        public List<Entidades.Editorial> ViewEditorialFiltro(string valor)
        {
            List<Entidades.Editorial> lista = new List<Entidades.Editorial>();
            Entidades.Editorial oe;

            try
            {
                List<CP_ListarEditorialResult> auxLista = EditorialCD.ListarEditorial(valor);
                foreach (CP_ListarEditorialResult obj in auxLista)
                {
                    oe = new Entidades.Editorial(obj.id, obj.nombre, obj.descripcion);
                    lista.Add(oe);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al mostar editorial con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }
        public bool CreateEditorial(Entidades.Editorial oe)
        {

            try
            {
                EditorialCD.InsertarEditorial(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar editorial en la BD");
            }
        }

        public bool UpdateEditorial(Entidades.Editorial oe)
        {

            try
            {
                EditorialCD.ModificarEditorial(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al modificar editorial en la BD");
            }
        }

        public bool DeleteEditorial(Entidades.Editorial oe)
        {

            try
            {
                EditorialCD.EliminarEditorial(oe);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar editorial en la BD");
            }
        }
    }
}
