using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using RemoteControllers.Exceptions;
using RemoteControllers;

namespace RemoteControllers
{
    public partial class ControladorEspecificacionLocal
    {
        private static ControladorEspecificacionLocal instance;

        private ControladorEspecificacionLocal()
        {

        }
        public static ControladorEspecificacionLocal getInstance()
        {
            if (instance == null)
            {
                instance = new ControladorEspecificacionLocal();
            }
            return instance;
        }


/*----------------------------------------------------ABM Fredd-------------------------------------------------------*/

        public bool agregarGusto(string espesificacion, string local, int costo)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {


                EspecificacionLocal item = new EspecificacionLocal();
                item.costo = costo;
                item.idLocal = local;
                ControladorEspecificacion control = RemoteControllers.ControladorEspecificacion.getInstance();
                item.idEspecificacion = control.getidespesificacion(espesificacion);

                handler.EspecificacionLocal.Add(item);
                bool salvado = false;

                int resultado = handler.SaveChanges();
                if (resultado <= 0)
                {
                    throw new NoSalvadoException();

                }
                else
                {
                    salvado = true;
                }
                return salvado;
            }

        }


        public bool modificarGusto(string espesificacion, string local, int costo)
        {




            bool correcto = true;

            if (correcto)
            {
                return correcto;
            }
            else
            {
                return correcto;
            }

        }


        public bool borrarGusto(string espesificacion, string local)
        {




            bool correcto = true;

            if (correcto)
            {
                return correcto;
            }
            else
            {
                return correcto;
            }

        }




/*****************************************************GET Fredd*****************************************************/

        public List<EspecificacionLocal> getEspecificacionesLocal(string nombreLocal)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {

                    //obtener todos los articulos de un local
                    List<EspecificacionLocal> listaEspecificacionesLocal = contexto.EspecificacionLocal.Where(e => e.idLocal == nombreLocal).ToList();

                    //obtener objeto local
                    Local loc = contexto.Local.FirstOrDefault(i => i.Nombre == nombreLocal);

                    //para cada articulo-local agregar el objeto Especificacion y Local
                    foreach (EspecificacionLocal EL in listaEspecificacionesLocal)
                    {
                        Especificacion item = contexto.Especificacion.FirstOrDefault(i => i.id == EL.idEspecificacion);
                        EL.Especificacion = item;
                        EL.Local = loc;

                    }

                    return listaEspecificacionesLocal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
