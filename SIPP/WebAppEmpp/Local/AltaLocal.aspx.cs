using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class AltaLocal : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                Entities.DTOs.DTOLocal sucursal = new Entities.DTOs.DTOLocal();
               
                sucursal.Nombre = txtNombre.Text.Trim().ToLower();
                sucursal.Telefono = decimal.Parse(txtTelefono.Text);
                decimal area = decimal.Parse(txtArea.Text);
                sucursal.Area =area;
                
                sucursal.Direccion = txtDireccion.Text;
                sucursal.Localidad = txtLocalidad.Text;
                
                
                

                sucursal.Latitud = latbox.Text;
                sucursal.Longitud = longbox.Text;
                //sucursal.Rut_empresa = 1;
                sucursal.Rut_empresa = long.Parse(Session["rutEmpresa"].ToString());
                proxy.registroLocal(sucursal);
                Response.Redirect("verLocalesEmpresa.aspx");
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }

    }
}