using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.PedidosPorLocal
{
    public partial class verPedidos : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //this.checkSesion();

                string nombreLocal = "pizza1";//((Entities.DTOs.DTOLocal)Session["Local"]).Nombre;
                

                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                RemoteServiceUsuario.IServiceUsuario userProxy = new RemoteServiceUsuario.ServiceUsuarioClient();
                Entities.DTOs.DTOLocal sucursal = new Entities.DTOs.DTOLocal();
                sucursal = proxy.getLocal(nombreLocal, 1);
                Session["Local"] = sucursal;
                List<Entities.DTOs.DTOUsuario> usuarios = userProxy.getUsuarios().ToList();
                List<Entities.DTOs.DTOPedido> pedidos = new List<Entities.DTOs.DTOPedido>();
                Entities.DTOs.DTOEstado state = new Entities.DTOs.DTOEstado();
                pedidos = proxy.getPedidos(nombreLocal).ToList();

                List<datos> lstDatos = new List<datos>();
                foreach (Entities.DTOs.DTOPedido ped in pedidos)
                {
                    datos auxiliar = new datos();
                    auxiliar.id = ped.Id.ToString();

                    auxiliar.Usuario = usuarios.FirstOrDefault(user => user.Id == ped.Id_usuario).Nombre;
                    auxiliar.Descripcion = ped.Descripcion;
                    auxiliar.Direccion = ped.DireccionPedido;
                    

                    auxiliar.Costo = ped.Costo.ToString();
                    state = proxy.getEstadoPorPedido(ped.Id);
                    switch (state.TipoEstado)
                    {
                        case 2:
                            auxiliar.Estado = "A)Enviado";
                            break;
                        case 1:
                            auxiliar.Estado = "B)En Proceso";
                            break;
                        case 0:
                            auxiliar.Estado = "C)En Espera";
                            break;
                    }
                
                    auxiliar.FechaPedido = state.FechaPedido;
                    lstDatos.Add(auxiliar);
              
                }
               
                grdPedidos.DataSource = lstDatos.OrderBy(lst => lst.Estado).ThenBy(lst=>lst.FechaPedido).ToList();
                grdPedidos.DataBind();
               
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
            
        }
        internal class datos
        {
            public datos()
            {
            }
            public string id { get; set; }
            public string Usuario { get; set; }
            public string Descripcion { get; set; }
            public string Direccion { get; set; }
            public string Costo { get; set; }
            public string Estado { get; set; }
            public string FechaPedido { get; set; }

        }

        protected void grdPedidos_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            grdPedidos.PageIndex = e.NewPageIndex;
            grdPedidos.DataBind();
        }

    }
}