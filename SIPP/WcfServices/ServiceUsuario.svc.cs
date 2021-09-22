using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Entities;
using Entities.DTOs;
using RemoteControllers;

namespace WcfServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuario.svc o ServiceUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuario : IServiceUsuario
    {
        public List<DTOValoracion> obtenerValoracionesDeEmpresa(long rut)
        {

            List<Valoracion> lst = ControladorEmpresa.obtenerValoracionesDeEmpresa(rut);
            List<DTOValoracion> lstDT = new List<DTOValoracion>();

            foreach (Valoracion v in lst)
            {
                lstDT.Add(v.getDT());
            }
            return lstDT;

            
        }

        public DTOValoracion ingresarValoracion(DTOValoracion v)
        {
            Valoracion val = ControladorEmpresa.ingresarValoracion(new Valoracion(v));

            return val.getDT();
        }
        public DTOEmpresa obtenerEmpresaPorLocal(string local)
        {
            
            Empresa emp = ControladorEmpresa.obtenerEmpresaPorLocal(local);

            return emp.getDTO();
        }


        public List<DTOPedido> obtenerPedidosDeUsuario(DTOUsuario u)
       {
           List<DTOPedido> lstDT = new List<DTOPedido>();
           Usuario us = new Usuario(u);
           List<Pedido> lst = ControladorUsuario.obtenerPedidosDeUsuario(us);

           foreach (Pedido p in lst)
           {
               lstDT.Add(p.getDT());
           }
           return lstDT;
       }

        public List<DTOUsuario> getUsuarios()
        {
            List<DTOUsuario> lstDT = new List<DTOUsuario>();
            List<Usuario> lst = ControladorUsuario.getUsuarios();
            foreach (Usuario u in lst)
            {
                lstDT.Add(u.getDT());
            }
            return lstDT;
        }

        public List<DTOUbicacion> getUbicaciones(long idUsuario)
        {
            List<DTOUbicacion> lstDT = new List<DTOUbicacion>();
            List<Ubicacion> lst = ControladorUbicacion.getUbicacionesDeUsuario(idUsuario);
            foreach (Ubicacion u in lst)
            {
                lstDT.Add(u.getDT());
            }
            return lstDT;
        }

        public DTOUsuario loginUsuario(DTOUsuario u)
        {
            Usuario user = ControladorUsuario.loginUsuario(
                new Usuario(u)
                );

            return user.getDT();
        }

        public DTOUsuario ObtenerUsuario(long id)
        {
            /*Usuario user = ControladorUsuario.loginUsuario(
                new Usuario(u)
                );*/
            Usuario user = ControladorUsuario.ObtenerUsuario(id);

            return user.getDT();
        }

        public DTOUsuario registroUsuario(DTOUsuario u)
        {
            Usuario usr = ControladorUsuario.registroUsuario(new Usuario(u));

            return usr.getDT();
        }

        public bool guardarUsuario(DTOUsuario u)
        {
            return ControladorUsuario.guardarUsuario(new Usuario(u));
        }

        public bool ComprobarEmail(DTOUsuario u)
        {
            bool usado;

            //bool user = ControladorUsuario.ComprobarEmail(u);

            usado = ControladorUsuario.ComprobarEmail(new Usuario(u)) ;

            return usado;
        }

        public DTOPedido IngresarPedido(DTOPedido p)
        {
            Pedido ped = new Pedido(p);
            return ControladorPedido.ingresarPedido(ped).getDT();
        }

    }
}
