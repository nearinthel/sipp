using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class EliminarLocal : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                this.checkSesion();
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                string sucursalNombre = Request.QueryString["Local"];
                long rut = long.Parse(Session["rutEmpresa"].ToString());
                Entities.DTOs.DTOLocal sucursal = proxy.getLocal(sucursalNombre, rut);
                lblNombre.Text = sucursal.Nombre;
                lblTelefono.Text = sucursal.Telefono.ToString();
                lblDireccion.Text = sucursal.Direccion;
                lblArea.Text = sucursal.Area.ToString(); ;
                lblLocalidad.Text = sucursal.Localidad;
            }
            catch (Exception exe)
            {

                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAceptar.Checked)
                {
                    long rut = long.Parse(Session["rutEmpresa"].ToString());
                    RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                    string nombre=lblNombre.Text;
                    proxy.borrarLocal(nombre, rut);
                    Response.Redirect("verLocalesEmpresa.aspx");
                }
            }
            catch (Exception exe)
            {
               
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }

            
        }
    }
}