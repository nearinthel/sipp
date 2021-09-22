using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entities.DTOs;
using RemoteControllers;
using Entities;


namespace WcfServices
{
    public class ServiceLocal : IServiceLocal
    {

        public  DTOEmpresa obtenerEmpresaPorLocal(string local) {
            //ControladorEmpresa controller = ControladorEmpresa.getInstance();
            Empresa emp = ControladorEmpresa.obtenerEmpresaPorLocal(local);

            return emp.getDTO();
        }




        public string encodePass(string pass)
        {
            string passEncriptada = Encript.EncodePassword(pass);
            return passEncriptada;
        }

/*------------------------------------------------- E M P R E S A ------------------------------------------------------*/

        public bool registroEmpresa(Entities.DTOs.DTOEmpresa enterprise)
        {
            Empresa microsoft = new Empresa(enterprise);
            ControladorEmpresa controller = ControladorEmpresa.getInstance();
            bool registrado=controller.registroEmpresa(microsoft);
            return registrado;

        }

        public bool modificarEmpresa(Entities.DTOs.DTOEmpresa enterprise, long rutEmpresa)
        {
            Empresa microsoft = new Empresa(enterprise);
            ControladorEmpresa controller = ControladorEmpresa.getInstance();
            bool modificado = controller.modificarEmpresa(microsoft, rutEmpresa);
            return modificado;
        }

        public DTOEmpresa loginEmpresa(string nombreEmpresa, string passEmpresa)
        {
            ControladorEmpresa controller = ControladorEmpresa.getInstance();

            DTOEmpresa enterprise = controller.loginEmpresa(nombreEmpresa, passEmpresa).getDTO();
            return enterprise;

        }
        public bool borrarEmpresa(long rut)
        {
            ControladorEmpresa controller = ControladorEmpresa.getInstance();
            bool resultado = controller.removeEmpresa(rut);
            return resultado;
        }

        public bool comprobarRut(long rut)
        {
            ControladorEmpresa controller = ControladorEmpresa.getInstance();
            return controller.comprobarRut(rut);
        }

        public bool comprobarRazonLogin(string razonSocial){
            ControladorEmpresa controller=ControladorEmpresa.getInstance();
            return controller.comprobarRazonSocialLogin(razonSocial);
        }


/*--------------------------------------------------A R T I C U L O S ------------------------------------------------------*/

        public bool agregarArticulo(Entities.DTOs.DTOArticulo item)
        {
            Articulo itemAgregar = new Articulo(item);
            ControladorArticulo controller = ControladorArticulo.getInstance();
            bool agregado = controller.agregarArticulo(itemAgregar);

            return agregado;
        }

        //public bool modificarArticulo(Entities.DTOs.DTOArticulo item, Entities.DTOs.DTOLocal sucursal)
        //{
        //    Articulo itemModificar = new Articulo(item);
        //    Local localItem = new Local(sucursal);
        //    ControladorArticulo controller = ControladorArticulo.getInstance();

        //    return controller.modificarArticulo(itemModificar, localItem);

        //}

        public bool borrarArticulo(Entities.DTOs.DTOArticulo item)
        {
            Articulo itemBorrar = new Articulo(item);
            ControladorArticulo controller = ControladorArticulo.getInstance();
            return controller.removerArticulo(itemBorrar);

        }

/*fredd*/public List<Entities.DTOs.DTOArticulo> getArticulos()
        {
            List<DTOArticulo> lstDT = new List<DTOArticulo>();
            List<Articulo> lst = ControladorArticulo.getArticulos();
            foreach (Articulo u in lst)
            {
                lstDT.Add(u.getDTO());
            }
            return lstDT;
        }
/*fredd*/public DTOArticulo getArticulo(string nombreArticulo) 
        {
            ControladorArticulo controler = ControladorArticulo.getInstance();
            DTOArticulo articulo = controler.getArticulo(nombreArticulo).getDTO();
            return articulo;
        
        }


/*--------------------------------------------------Articulo L O C A L ------------------Fredd----------------------------*/
/*A*/   public bool altaArticuloLocal(Articulo articulo, Local local, decimal costo)
        {
            ControladorArticuloLocal controller = ControladorArticuloLocal.getInstance();
            return controller.altaArticuloLocal(articulo, local, costo);
        }

/*B*/   public bool bajaArticuloLocal(string articulo, string local)
        {
            ControladorArticuloLocal controller = ControladorArticuloLocal.getInstance();
            return controller.bajaArticulolocal(articulo, local);
        }

/*M*/   public bool modificarArticuloLocal(string articulo, string local, decimal nuevocosto)
        {
            ControladorArticuloLocal controller = ControladorArticuloLocal.getInstance();
            return controller.modificarArticulolocal(articulo, local, nuevocosto);
        }

        
/*leo*/ public DTOArticuloLocal getArticuloByLocal(string nombreArticulo, string nombreLocal)
        {
            ControladorArticuloLocal controller = ControladorArticuloLocal.getInstance();
            DTOArticuloLocal item = controller.getArticuloByLocal(nombreArticulo, nombreLocal).getDTO();
            return item;
        }

        public List<Entities.DTOs.DTOArticuloLocal> getArticulosLocal(string nombreLocal)
        {
            List<DTOArticuloLocal> lstDT = new List<DTOArticuloLocal>();
            ControladorArticuloLocal controller = ControladorArticuloLocal.getInstance();
            List<ArticuloLocal> lst = controller.getArticulosLocal(nombreLocal);
            foreach (ArticuloLocal u in lst)
            {
                lstDT.Add(u.getDTO());
            }

            return lstDT;
        }

/*--------------------------------------------------L O C A L E S ------------------------------------------------------*/

        public bool registroLocal(Entities.DTOs.DTOLocal sucursal)
        {
            Local sucursalAgregar = new Local(sucursal);
            ControladorLocal controller = ControladorLocal.getInstance();
            bool resultado = controller.registroLocal(sucursalAgregar);
            return resultado;
        }

        public bool modificarLocal(Entities.DTOs.DTOLocal sucursal)
        {
            Local sucursalModificar = new Local(sucursal);
            ControladorLocal controller = ControladorLocal.getInstance();
            bool resultado = controller.modificarLocal(sucursalModificar.Nombre, sucursalModificar.Rut_empresa, sucursalModificar);
            return resultado;
        }

        public DTOLocal getLocal(string nombreSucursal, long rut)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            DTOLocal sucursalObtener = controller.getLocalPorNombre(nombreSucursal, rut).getDTO();
            return sucursalObtener;

        }
        public bool borrarLocal(string nombreLocal, long rut)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            return controller.borrarLocal(nombreLocal, rut);
        }

        public List<string> getLocalidades()
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            List<string> lstLocal = controller.getLocalidades();
            return lstLocal;
        }

        public List<DTOLocal> getLocalesPorArea(string latitudCliente, string longitudCliente)

        {
            ControladorLocal controller = ControladorLocal.getInstance();
            List<Local> lstLocal = controller.getLocalesPorArea(latitudCliente, longitudCliente);
            List<DTOLocal> lstDTOLocal = new List<DTOLocal>();
            foreach (Local sucursal in lstLocal)
            {
                lstDTOLocal.Add(sucursal.getDTO());
            }
            return lstDTOLocal;
        }

        public List<Entities.DTOs.DTOLocal> getLocalesPorLocalidad(string lugar)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            List<Local> lstLocal = controller.getLocalesPorLocalidad(lugar);
            List<DTOLocal> lstDTOLocal = new List<DTOLocal>();
            foreach (Local sucursal in lstLocal)
            {
                lstDTOLocal.Add(sucursal.getDTO());
            }
            return lstDTOLocal;
        }

/*Fredd*/public List<Entities.DTOs.DTOLocal> getLocalesPorEmpresa(long idempresa)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            List<Local> lstLocal = controller.getLocalesPorEmpresa(idempresa);
            List<DTOLocal> lstDTOLocal = new List<DTOLocal>();
            foreach (Local sucursal in lstLocal)
            {
                lstDTOLocal.Add(sucursal.getDTO());
            }
            return lstDTOLocal;

        }

/*Fredd*/public List<Entities.DTOs.DTOLocal> getLocalesXEmpresa(long empresa)
        {
            ControladorLocal controller = ControladorLocal.getInstance();

            List<DTOLocal> lstDT = new List<DTOLocal>();
            List<Local> lst = controller.getLocalesXEmpresa(empresa);
            foreach (Local u in lst)
            {
                lstDT.Add(u.getDTO());
            }
            return lstDT;
        }

        public bool modificarPassLocal(long rut, string nombre, string pass){
            ControladorLocal controller=ControladorLocal.getInstance();
            return controller.modificarPassLocal(nombre,rut,pass);
        }

        public DTOLocal loginLocal(string nombreLocal, string pass)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            return controller.loginLocal(nombreLocal, pass).getDTO();
        }

/*-------------------------------------------- E S P E C I F I C A C I O N E S -----------------------------------------------*/

        public List<Entities.DTOs.DTOEspecificacion> getEspecificaciones()
        {
            ControladorEspecificacion controller = ControladorEspecificacion.getInstance();

            List<DTOEspecificacion> lstDT = new List<DTOEspecificacion>();
            List<Especificacion> lst = controller.getEspecificaciones();
            foreach (Especificacion u in lst)
            {
                lstDT.Add(u.getDT());
            }
            return lstDT;
        }

        public List<DTOPedido> getPedidos(string nombreLocal)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            List<DTOPedido> pedidos = new List<DTOPedido>();
            foreach (Pedido ped in controller.getPedidos(nombreLocal))
            {
                pedidos.Add(ped.getDT());
            }
            return pedidos;
        }


/*--------------------------------------------------Especificacion L O C A L Fredd ---------------------------------------------*/     
/*A*/   public bool agregarGusto(string espesificacion, string local, int costo)
        {
            ControladorEspecificacionLocal controller = ControladorEspecificacionLocal.getInstance();
            return controller.agregarGusto(espesificacion, local, costo);
        }

        
/*B*/   public bool borrarGusto(string espesificacion, string local)
        {
            ControladorEspecificacionLocal controller = ControladorEspecificacionLocal.getInstance();
            return controller.borrarGusto(espesificacion, local);
        }

       
 /*M*/  public bool modificarGusto(string espesificacion, string local, int costo)
        {
            ControladorEspecificacionLocal controller = ControladorEspecificacionLocal.getInstance();
            return controller.modificarGusto(espesificacion, local, costo);
        }

        public List<DTOEspecificacionLocal> getEspecificacionesLocal(string nombreLocal)
        {
            List<DTOEspecificacionLocal> lstDT = new List<DTOEspecificacionLocal>();
            ControladorEspecificacionLocal controller = ControladorEspecificacionLocal.getInstance();
            //List<EspecificacionLocal> lst = controller.getEspecificacionesLocal(nombreLocal);
            //foreach (EspecificacionLocal u in lst)
            ///{
           //     lstDT.Add(u.getDTO());
            //}

            return lstDT;
        }

        public DTOPedido getPedido(long id)
        {
            return ControladorPedido.ObtenerPedido(id).getDT();
            
        }

        public bool guardarPedido(DTOPedido ped){
            return ControladorPedido.guardarPedido(new Pedido(ped));
        }

        public bool comprobarNombreLocalLogin(string nombreLocal)
        {
            ControladorLocal controller = ControladorLocal.getInstance();
            return controller.comprobarNombreLocalLogin(nombreLocal);
        }
        //...............................Estado.........................................//

        public bool agregarEstado(DTOEstado state)
        {
            ControladorEstado controller = ControladorEstado.getInstance();
            return controller.newEstado(new Estado(state));
        }
        public bool modificarEstado(DTOEstado state)
        {
            ControladorEstado controller = ControladorEstado.getInstance();
            return controller.modifyEstado(new Estado(state));
        }

        public bool elimarEstado(DTOEstado state)
        {
            ControladorEstado controller = ControladorEstado.getInstance();
            return controller.removeEstado(new Estado(state));
        }

        public DTOEstado getEstado(long id)
        {
            ControladorEstado controller = ControladorEstado.getInstance();
            return controller.getEstado(id).getDTO();
        }

        public DTOEstado getEstadoPorPedido(long idPedido)
        {
            ControladorEstado controller = ControladorEstado.getInstance();
            DTOEstado dto=new DTOEstado();
            dto=controller.getEstadoPorPedido(idPedido).getDTO();
            return dto;
        }

    }        
   
}
