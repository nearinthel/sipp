using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class CambiarDireccionLocal :WebAppEmpp.PageTemplate
    {
        Entities.DTOs.DTOLocal sucursal;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            try
            {
                this.checkSesion();
                RemoteServiceLocal.IServiceLocal proxy =new RemoteServiceLocal.ServiceLocalClient();
                string sucursalNombre=Request.QueryString["Local"];
                long rut = long.Parse(Session["rutEmpresa"].ToString());
                sucursal=proxy.getLocal(sucursalNombre, rut);
                lblNombre.Text = sucursalNombre;
                latbox.Text=sucursal.Latitud;
                longbox.Text=sucursal.Longitud;
                lblDireccion.Text=sucursal.Direccion;
                lblLocalidad.Text=sucursal.Localidad;

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


                if (txtDireccion.Text != "")
                {
                    sucursal.Direccion = txtDireccion.Text;
                }
                if (txtLocalidad.Text != "")
                {
                    sucursal.Localidad = txtLocalidad.Text;
                }
                if (latboxNuevo.Text != "")
                {
                    sucursal.Latitud = latboxNuevo.Text;
                }
                if (longboxNuevo.Text != "")
                {
                    sucursal.Longitud = longboxNuevo.Text;
                }

                proxy.modificarLocal(sucursal);
                Response.Redirect("/Local/verLocalesEmpresa.aspx");

            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Local/verLocalesEmpresa.aspx");
        }

        
    }
}