using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entities;
using Entities.DTOs;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceLocal" in both code and config file together.
    [ServiceContract]
    public interface IServiceLocal

    {
        

        [OperationContract]
        string encodePass(string pass);

/*------------------------------------------------- E M P R E S A ------------------------------------------------------*/
        [OperationContract]
        bool registroEmpresa(Entities.DTOs.DTOEmpresa enterprise);

        [OperationContract]
        bool modificarEmpresa(Entities.DTOs.DTOEmpresa enterprise, long rutEmpresa);

        [OperationContract]
        DTOEmpresa loginEmpresa(string nombreEmpresa, string passEmpresa);

        [OperationContract]
       bool borrarEmpresa(long rut);

        [OperationContract]
        bool comprobarRut(long rut);

        [OperationContract]
        bool comprobarRazonLogin(string razonSocial);

/*------------------------------------------------- A R T I C U L O ------------------------------------------------------*/

        [OperationContract]
        bool agregarArticulo(Entities.DTOs.DTOArticulo item);

      //[OperationContract]
      //bool modificarArticulo(Entities.DTOs.DTOArticulo item, Entities.DTOs.DTOLocal sucursal);

        [OperationContract]
        bool borrarArticulo(Entities.DTOs.DTOArticulo item);

        [OperationContract]
        List<Entities.DTOs.DTOArticulo> getArticulos();

        [OperationContract]
        DTOArticulo getArticulo(string nombreArticulo);

/*------------------------------------------------- Articulo L O C A L  Fredd----------------------------------------------------*/
        [OperationContract]
        bool altaArticuloLocal(Articulo articulo, Local local, decimal nuevocosto);

        [OperationContract]
        bool bajaArticuloLocal(string articulo, string local);

        [OperationContract]
        bool modificarArticuloLocal(string articulo, string local, decimal nuevocosto);

        // pombo
        [OperationContract]
        DTOArticuloLocal getArticuloByLocal(string nombreArticulo, string nombreLocal);
        
        [OperationContract]
        List<Entities.DTOs.DTOArticuloLocal> getArticulosLocal(string nombreLocal);
        

/*------------------------------------------------- L O C A L E S -------------------------------------------------------*/

        [OperationContract]
        bool registroLocal(Entities.DTOs.DTOLocal sucursal);

        [OperationContract]
        bool modificarLocal(Entities.DTOs.DTOLocal sucursal);

        [OperationContract]
        DTOLocal getLocal(string nombreLocal, long rut);

        [OperationContract]
        bool borrarLocal(string nombreLocal, long rut);

        [OperationContract]
        List<DTOLocal> getLocalesPorArea(string latitudCliente, string longitudCliente);

        [OperationContract]
        List<Entities.DTOs.DTOLocal> getLocalesPorLocalidad(string lugar);

        [OperationContract]
        List<string> getLocalidades();
//Fredd
        [OperationContract]
        List<Entities.DTOs.DTOLocal> getLocalesPorEmpresa(long idempresa);
//Fredd
        [OperationContract]
        List<Entities.DTOs.DTOLocal> getLocalesXEmpresa(long empresa);


        [OperationContract]
        bool modificarPassLocal(long rut, string nombre, string pass);

        [OperationContract]
        DTOLocal loginLocal(string nombreLocal, string pass);

/*------------------------------------------ E S P E C I F I C A C I O N E S  --------------------------------------------*/


        [OperationContract]
        List<Entities.DTOs.DTOEspecificacion> getEspecificaciones();


/*------------------------------------------------- Especificacion L O C A L  Fredd----------------------------------------*/
        [OperationContract]
        List<DTOEspecificacionLocal> getEspecificacionesLocal(string nombreLocal);
        
        [OperationContract]
        bool agregarGusto(string espesificacion, string local, int costo);

        [OperationContract]
        bool modificarGusto(string espesificacion, string local, int costo);

        [OperationContract]
        bool borrarGusto(string espesificacion, string local);

        [OperationContract]
        List<DTOPedido> getPedidos(string nombreLocal);

        [OperationContract]
        DTOPedido getPedido(long id);

        [OperationContract]
        bool guardarPedido(DTOPedido ped);

        [OperationContract]
        bool comprobarNombreLocalLogin(string nombreLocal);


        //..................................Estado........................//

        [OperationContract]
         bool agregarEstado(DTOEstado state);

        [OperationContract]
        bool modificarEstado(DTOEstado state);

        [OperationContract]
        bool elimarEstado(DTOEstado state);

        [OperationContract]
        DTOEstado getEstado(long id);

        [OperationContract]
        DTOEstado getEstadoPorPedido(long idPedido);
     
    }
}
