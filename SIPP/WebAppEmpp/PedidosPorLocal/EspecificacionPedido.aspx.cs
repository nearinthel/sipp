using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class EspecificacionPedido : WebAppEmpp.PageTemplate
    {
        protected string descripcionPedido = "";
        protected Entities.DTOs.DTOPedido pedido;
        protected Entities.DTOs.DTOEstado state;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.checkSesion();

                Entities.DTOs.DTOLocal sucursal = new Entities.DTOs.DTOLocal();
                sucursal = (Entities.DTOs.DTOLocal)Session["Local"];
                string nombreLocal=sucursal.Nombre;
                string nombreCliente=Request.QueryString["Usuario"];
                long idPedido=long.Parse(Request.QueryString["Pedido"]);
              
                RemoteServiceLocal.IServiceLocal proxyLocal = new RemoteServiceLocal.ServiceLocalClient();
                //pedido = proxyLocal.getPedido(idPedido);
                pedido = proxyLocal.getPedidos(nombreLocal).ToList().FirstOrDefault(ped => ped.Id == idPedido);
                state = new Entities.DTOs.DTOEstado();
                state = proxyLocal.getEstadoPorPedido(pedido.Id);


                latbox.Text = pedido.LatitudDireccion;
                longbox.Text = pedido.LongitudDireccion;
                lblNombre.Text = nombreCliente;
                lblDireccion.Text = pedido.DireccionPedido;
                txtContenido.Text = "Descripcion del Pedido:"+Environment.NewLine +pedido.Descripcion;
                if(!Page.IsPostBack)
                {
                    switch (state.TipoEstado)
                    {
                        case 2:
                            lblEstado.Text = "A)Enviado";
                            txtFechas.Text = "Pedido:" + state.FechaPedido + Environment.NewLine +
                                "Empezada a prepararse:" + state.FechaProceso + Environment.NewLine +
                                "Enviada:" + state.FechaEnviado + Environment.NewLine + "(formato;año/mes/dia min:hora)";
                            
                            ddlEstado.Visible = false;
                            
                            btnConfirmar.Visible = false;
                            break;
                        case 1:
                            lblEstado.Text = "B)En Proceso";
                            txtFechas.Text = "Pedido:" + state.FechaPedido + Environment.NewLine +
                                "Empezada a prepararse:" + state.FechaProceso + Environment.NewLine +
                                 "(formato;año/mes/dia min:hora)";
                            ddlEstado.Items.Add("A) Enviado");
                            break;
                        case 0:
                            lblEstado.Text = "C)En Espera";
                            txtFechas.Text = "Pedido:" + state.FechaPedido + Environment.NewLine +
                                 "(formato;año/mes/dia min:hora)";
                             ddlEstado.Items.Add("A) Enviado");
                            ddlEstado.Items.Add("B) En Proceso");
                            break;
                    }
                }

            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
               
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
          
                switch (ddlEstado.SelectedIndex)
                {
                    case 0:
                        state.TipoEstado = 2;
                        
                        break;
                    case 1:
                        state.TipoEstado = 1;
                        
                        break;
               
                }
                
                
                bool guardado = proxy.modificarEstado(state);
                
                Response.Redirect("verPedidos.aspx");
               
               
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }
        
        

    }
    

}