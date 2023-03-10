using SistemaVentadeComics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class GeneroLN
    {
        public List<Entidades.Genero> ViewGeneroFiltro(string valor)
        {
            List<Entidades.Genero> lista = new List<Entidades.Genero>();
            Entidades.Genero og;

            try
            {
                List<CP_ListarGeneroFiltroResult> auxLista = GeneroCD.ListarGeneroFiltro(valor);
                foreach (CP_ListarGeneroFiltroResult obj in auxLista)
                {
                    og = new Entidades.Genero(obj.id, obj.nombre, obj.descripcion);
                    lista.Add(og);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al mostar serie con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }
        public bool CreateGenero(Entidades.Genero og)
        {

            try
            {
                GeneroCD.InsertarGenero(og);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar autor en la BD");
            }
        }

        public bool UpdateGenero(Entidades.Genero og)
        {

            try
            {
                GeneroCD.ModificarGenero(og);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al modificar autor en la BD");
            }
        }

        public bool DeleteGenero(Entidades.Genero og)
        {

            try
            {
                GeneroCD.EliminarGenero(og);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar autor en la BD");
            }
        }
      
    }
}
