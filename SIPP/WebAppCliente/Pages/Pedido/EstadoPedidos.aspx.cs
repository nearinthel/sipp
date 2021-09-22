using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entities.DTOs;
using Entities;

namespace WebAppCliente.Pages.Pedido
{
    public partial class PantallaEstados : WebAppCliente.Pages.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();

            if (!Page.IsPostBack)
            {
                Console.Write("Hola");
                //DTOUsuario usr = ((Usuario)Session["Usuario"]).getDT(); 
                ////Entities.Pedido peed =
                //Usuario usr = (Usuario)Session["Usuario"];


                //RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();

                //DTOPedido[] lstPedidos = proxy.obtenerPedidosDeUsuario(usr.getDT());



                Usuario usr = (Usuario)Session["Usuario"];

                List<Entities.Pedido> lstPedidos = new List<Entities.Pedido>();


                RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
               // Usuario usr = new Usuario(proxy.getUsuarios().ToList().FirstOrDefault(s=>s.Id==26));
                DTOPedido[] lstDtoPedidos = proxy.obtenerPedidosDeUsuario(usr.getDT());

                foreach (DTOPedido ped in lstDtoPedidos)
                {
                    lstPedidos.Add(new Entities.Pedido(ped));
                }

                //Entities.Pedido p = new Entities.Pedido();
                //p.Id = 12;
                //p.Costo = 7678;
                //p.Descripcion = "ahhhhhhhhhhhhhh";
                //p.Estado = true;

                
                //lstPedidos.Add(p);
                tablaEstados.DataSource = lstPedidos;
                tablaEstados.DataBind();
                Session["pedidos"] = lstPedidos;
            }

        }

        protected void tablaEstados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            Usuario usr = (Usuario)Session["Usuario"];

            List<Entities.Pedido> lstPedidos = new List<Entities.Pedido>();


            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();

            DTOPedido[] lstDtoPedidos = proxy.obtenerPedidosDeUsuario(usr.getDT());

            foreach (DTOPedido ped in lstDtoPedidos)
            {
                lstPedidos.Add(new Entities.Pedido(ped));
            }

            
            tablaEstados.DataSource = lstPedidos;
            tablaEstados.DataBind();
            Session["pedidos"] = lstPedidos;
        }

        protected void tablaEstados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string jprueba = "hola";

            

            if (e.Row.Cells[3].Text == "True") { e.Row.Cells[3].Text = "Entregado";
            e.Row.Cells[4].Text = "<a href='feedback.aspx?loc=" + e.Row.Cells[1].Text + "' ><span class='label label-warning'>Danos tu Opinion</span><a>";
            e.Row.CssClass = "success alert-success";

            
 
            }
            if (e.Row.Cells[3].Text == "False") { e.Row.Cells[3].Text = "En Proceso";
            e.Row.CssClass = "alert warning";

            }
            if (e.Row.Cells[2].Text != "Costo") { e.Row.Cells[2].Text = "$ " + e.Row.Cells[2].Text; }

        }

        
    }
}
