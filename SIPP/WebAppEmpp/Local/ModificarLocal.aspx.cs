using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebAppEmpp.Local
{
    public partial class ModificarLocal : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.checkSesion();
                long rutEmpresa = long.Parse(Session["rutEmpresa"].ToString());
               
                repetidor.rutEmpresa = rutEmpresa;

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
                Entities.DTOs.DTOLocal sucursal = proxy.getLocal(nombreOriginal, rut);
                if (txtNombre.Text != "")
                {
                    sucursal.Nombre = txtNombre.Text.Trim().ToLower();
                }
                if (txtTelefono.Text != "")
                {
                    sucursal.Telefono = decimal.Parse(txtTelefono.Text);
                }
                if(txtArea.Text!="")
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
                Response.Redirect("/Registro/PerfilEmpresa.aspx");
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

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string sucursal = lblNombre.Text;
                string url = "EliminarLocal.aspx?Local=" + sucursal;
                Response.Redirect(url);
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
                string url = "agregarPassLocal.aspx?Local=" + sucursal;
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }
    }


}