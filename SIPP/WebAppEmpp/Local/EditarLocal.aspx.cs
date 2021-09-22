using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class EditarLocal :WebAppEmpp.PageTemplate
    {
        Entities.DTOs.DTOLocal sucursal;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkSesion();

                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                string sucursalNombre = Request.QueryString["Local"];
                long rut =long.Parse(Session["rutEmpresa"].ToString());
                sucursal = proxy.getLocal(sucursalNombre, rut);
                lblNombre.Text = sucursal.Nombre;
                
                lblTelefono.Text = sucursal.Telefono.ToString();
                lblArea.Text = sucursal.Area.ToString();
               


            }
            catch (Exception exe)
            {
               
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }


        }

        protected void lnkCambiarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                string sucursal=lblNombre.Text;
                string url = "CambiarDireccionLocal.aspx?Local=" + sucursal;
                Response.Redirect(url);

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

                long rut = long.Parse(Session["rutEmpresa"].ToString());
                string nombreOriginal = lblNombre.Text;
                sucursal = proxy.getLocal(nombreOriginal, rut);
                if (txtNombre.Text != "")
                {
                    sucursal.Nombre = txtNombre.Text.Trim().ToLower();
                }
                if (txtTelefono.Text != "")
                {
                    sucursal.Telefono = decimal.Parse(txtTelefono.Text);
                }
                if (txtArea.Text != "")
                {
                    sucursal.Area = (decimal.Parse(txtArea.Text));
                }
                

                proxy.modificarLocal(sucursal);
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("verLocalesEmpresa.aspx");
            }

            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }

        protected void lnkPass_Click(object sender, EventArgs e)
        {
            try
            {
                string sucursal = lblNombre.Text;
                string url = "modificarPassLocal.aspx?Local=" + sucursal;
                Response.Redirect(url);
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }
        
    }
}