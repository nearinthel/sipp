using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using RemoteControllers.Exceptions;
using System.Xml.Linq;

namespace RemoteControllers
{

    public partial class ControladorLocal:ControladorHerenciable
    {

        private static ControladorLocal instance;

        public static ControladorLocal getInstance()
        {
            if (instance == null)
            {
                instance = new ControladorLocal();
            }
            return instance;
        }

        private ControladorLocal()
        {
        }

        public bool registroLocal(Local sucursal)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                Local nuevaSucursal = handler.Local.Add(sucursal);
  
                return this.salvar(handler);
            }
        }

        public bool modificarLocal(string nombreSucursal, long rutEmpresaLocal, Local sucursal)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {


                Local sucursalModificada = handler.Local.FirstOrDefault(s => s.Nombre == nombreSucursal && s.Rut_empresa == rutEmpresaLocal);
                //if (sucursalModificada != null)
                //{
                //sucursalModificada.Nombre = sucursal.Nombre;
                //sucursalModificada.Latitud = sucursal.Latitud;
                //sucursalModificada.Direccion = sucursal.Direccion;
                //sucursalModificada.Longitud = sucursal.Longitud;
                //sucursalModificada.Pedido = sucursal.Pedido;
                //sucursalModificada.Rut_empresa = sucursal.Rut_empresa;
                //sucursalModificada.Telefono = sucursal.Telefono;
                //sucursalModificada.Localidad = sucursal.Localidad;
                handler.Entry(sucursalModificada).CurrentValues.SetValues(sucursal);
                return this.salvar(handler);
             }
        }

        public bool modificarPassLocal(string nombre, long rut, string pass)
        {
            using(AlacartaEntities handler=new AlacartaEntities()){

                Local sucursal = handler.Local.FirstOrDefault(l => l.Rut_empresa == rut && l.Nombre == nombre);
                sucursal.Pass = pass;

                return this.salvar(handler);

            }
        }

        public Local getLocalPorNombre(string nombreLocal, long rutEmpresaLocal)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Local sucursal = handler.Local.FirstOrDefault(s => s.Nombre == nombreLocal && s.Rut_empresa == rutEmpresaLocal);
                if (sucursal == null)
                {
                    throw new ObjetoNoExisteException(String.Format("el local con nombre \"{0}\" ", nombreLocal));
                }
                return sucursal;
            }
        }


        //LOCALES localesPorArea POMBO
        public List<Local> getLocalesPorArea(string latitudCliente, string longitudCliente)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List<Local> locales = contexto.Local.SqlQuery("SELECT * FROM dbo.Local WHERE (SQRT(((SQUARE((" + latitudCliente + " - Latitud))) + (SQUARE((" + longitudCliente + " - Longitud))))) * 111.319  <= Area)").ToList();
                    if (locales == null)
                    {
                        return null;
                    }
                    else
                        return locales;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<string> getLocalidades()
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {


                List<Local> lstLocal = (from sucursal in handler.Local
                                        select sucursal).ToList();
                List<string> lstLocalidad = new List<string>();
                string localidadAux = " ";
                foreach (Local sucursal in lstLocal)
                {
                    if (localidadAux != sucursal.Localidad)
                    {
                        lstLocalidad.Add(sucursal.Localidad);
                        localidadAux = sucursal.Localidad;
                    }
                }
                return lstLocalidad;

            }
        }
        public List<Local> getLocalesPorLocalidad(string lugar)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                //List<Local> locales = handler.Local.Where(s => s.Localidad == lugar).ToList();
                List<Local> locales = (from loc in handler.Local
                                       where loc.Localidad == lugar
                                       select loc).ToList();
                return locales;
            }

        }

//-----------------------------------LOCALES POR EMPRESAA--------Fredd------------------//
        public List<Local> getLocalesPorEmpresa(long idempresa)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                
                List<Local> locales = (from loc in handler.Local where loc.Rut_empresa == idempresa select loc).ToList();
                return locales;
            }

        }

        public List<Local> getLocalesXEmpresa(long empresa)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List<Local> lstDir = contexto.Local.Where(s => s.Rut_empresa==empresa).ToList();
                    return lstDir;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
//fin

        public bool borrarLocal(string nombreLocal, long rutEmpresa)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                Local sucursalBorrar = handler.Local.FirstOrDefault(s => s.Nombre == nombreLocal && s.Rut_empresa == rutEmpresa);
                sucursalBorrar.Empresa = null;
                
                if (sucursalBorrar.ArticuloLocal != null)
                {
                    List<Articulo> items = (from art in sucursalBorrar.ArticuloLocal
                                            select art.Articulo).ToList();
                    ControladorArticuloLocal controller = ControladorArticuloLocal.getInstance();
                    foreach (Articulo it in items)
                    {
                        controller.bajaArticulolocal(it.Nombre, nombreLocal);


                    }
                }

                handler.Local.Remove(sucursalBorrar);

                return this.salvar(handler);
            }
        }

        public Local loginLocal(string nombreLocal, string pass)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                Local sucursal = handler.Local.FirstOrDefault(suc => suc.Nombre == nombreLocal && suc.Pass == pass);
  
               
               return sucursal;
                
            }

        }

        public bool agregarEmpresaLocal(long rut, Local sucursal)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {
                ControladorEmpresa enterpriseController = ControladorEmpresa.getInstance();
                Empresa enterprise = ControladorEmpresa.getEmpresa(rut);
                sucursal.Empresa = enterprise;
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

        public List<Pedido> getPedidos(string nombreLocal)
        {
            using(AlacartaEntities handler=new AlacartaEntities()){
                List<Pedido> pedidos = (from ped in handler.Pedido
                                        where ped.Local.Nombre == nombreLocal
                                        select ped).ToList();
                return pedidos;

            }
        }
        public bool comprobarNombreLocalLogin(string nombreLocal)
        {
            using(AlacartaEntities handler=new AlacartaEntities()){
                bool existe = false;
                Local sucursal = handler.Local.FirstOrDefault(loc => loc.Nombre == nombreLocal);
                if (sucursal != null)
                {
                    existe = true;
                }
                return existe;
            }
        }
   
    }
}
