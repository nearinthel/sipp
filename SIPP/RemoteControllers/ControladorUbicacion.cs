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

    public class ControladorUbicacion
    {
        private static ControladorUbicacion instance;

        private ControladorUbicacion() { }

        public static ControladorUbicacion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControladorUbicacion();
                }
                return instance;
            }
        }

        public static List<Ubicacion> getUbicacionesDeUsuario(long idUsuario)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List < Ubicacion > lstDir = contexto.Ubicacion.Where(ubi => ubi.Id_usuario == idUsuario).ToList();
                    return lstDir;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
