using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data.Entity;
using System.Transactions;

namespace RemoteControllers
{
    public class ControladorEspecificacion
    {
        private static ControladorEspecificacion instance;

        public static ControladorEspecificacion getInstance()
        {
            if (instance == null)
            {
                instance = new ControladorEspecificacion();
            }
            return instance;
        }

        private ControladorEspecificacion()
        {
        }


/*Fredd*/public List<Especificacion> getEspecificaciones()
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List<Especificacion> lstDir = contexto.Especificacion.Select(s => s).ToList();
                    return lstDir;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

/*Fredd*/public long getidespesificacion(string nombre)
{
    try
    {
        using (AlacartaEntities contexto = new AlacartaEntities())
        {
            Especificacion esp =(Especificacion) contexto.Especificacion.Where(s => s.Nombre== nombre);
            return esp.id;
        }
    }
    catch (Exception ex)
    {
        throw ex;
    }
}



    }

}
