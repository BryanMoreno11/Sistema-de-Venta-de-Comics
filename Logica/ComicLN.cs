using SistemaVentadeComics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using System.Windows.Forms;

namespace Logica
{
    public class ComicLN
    {
        public List<Entidades.ComicPersonalizado> ViewComicVistaFiltro(string valor, string tipo)
        {
            byte[] imagen = null;
            List<Entidades.ComicPersonalizado> lista = new List<Entidades.ComicPersonalizado>();
            Entidades.ComicPersonalizado oc;

            try
            {
                List<CP_ListarVistaComicResult> auxLista = ComicCD.ListarVistaComicFiltro(valor);
                foreach (CP_ListarVistaComicResult obj in auxLista)
                {
                    imagen = null;
                    if (obj.imagen != null)
                    {

                        imagen = obj.imagen.ToArray();
                        if (tipo.Equals("Miniatura"))
                        {
                            Image originalImage = Image.FromStream(new MemoryStream(imagen));
                            Image thumbnailImage = originalImage.GetThumbnailImage(100, 150, null, IntPtr.Zero);
                            imagen = imageToByteArray(thumbnailImage);
                        }
                    }
                    oc = new Entidades.ComicPersonalizado(obj.id, obj.nombre, obj.serie,obj.genero,obj.autor,obj.editorial,obj.descripcion,obj.precio,obj.stock, imagen);
                    lista.Add(oc);
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

        public List<Entidades.Comic> ViewComicFiltro(string valor)
        {
            List<Entidades.Comic> lista = new List<Entidades.Comic>();
            Entidades.Comic oc;
            byte[] imagen=null;
            try
            {
                List<CP_ListarComicFiltroResult> auxLista = ComicCD.ListarComicFiltro(valor);
                foreach (CP_ListarComicFiltroResult obj in auxLista)
                {
                    imagen = null;
                    imagen = obj.imagen.ToArray();
                    oc = new Entidades.Comic(obj.id,obj.nombre,obj.id_serie,obj.id_genero,obj.id_autor,obj.id_editorial,obj.descripcion,obj.precio,obj.stock,imagen);
                    lista.Add(oc);
                }
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al mostar pelicula con procedimiento almacenado", ex);
            }
            finally
            {

            }
            return lista;
        }



        public bool CreateComic(Entidades.Comic oc)
        {

            try
            {
                ComicCD.InsertarComic(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar serie en la BD");
            }
        }

        public bool UpdateComic(Entidades.Comic oc)
        {

            try
            {
                ComicCD.ModificarComic(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al modificar serie en la BD");
            }
        }

        public bool DeleteComic(Entidades.Comic oc)
        {

            try
            {
                ComicCD.EliminarComic(oc);
                return true;
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error al insertar actor en la BD");
            }
        }

        public Entidades.Comic getComic(int cod)
        {

            try
            {
                int pos = -1;
                List<Entidades.Comic> lista = ViewComicFiltro("").ToList();
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Id == cod)
                    {
                        pos = i;
                        break;
                    }
                }

                return lista[pos];
            }
            catch (Exception ex)
            {
                throw new LogicaExepciones("Error encontrar comic");
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}
