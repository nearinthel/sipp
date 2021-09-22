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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuario

    {
        [OperationContract]
        List<DTOValoracion> obtenerValoracionesDeEmpresa(long rut);
        [OperationContract]
        DTOValoracion ingresarValoracion(DTOValoracion v);
        [OperationContract]
        DTOEmpresa obtenerEmpresaPorLocal(string local);

        [OperationContract]
        List<DTOPedido> obtenerPedidosDeUsuario(DTOUsuario u);

        [OperationContract]
        List<DTOUsuario> getUsuarios();

        [OperationContract]
        DTOUsuario registroUsuario(DTOUsuario u);

        [OperationContract]
        DTOUsuario loginUsuario(DTOUsuario u);

        [OperationContract]
        DTOUsuario ObtenerUsuario(long id);//

        [OperationContract]
        bool guardarUsuario(DTOUsuario u);

        [OperationContract]
        bool ComprobarEmail(DTOUsuario u);

        [OperationContract]
        List<DTOUbicacion> getUbicaciones(long idUsuario);

        [OperationContract]
        DTOPedido IngresarPedido(DTOPedido p);

    }
}
