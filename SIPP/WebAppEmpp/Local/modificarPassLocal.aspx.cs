using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class modificarPassLocal :WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkSesion();
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                Entities.DTOs.DTOLocal sucursal = (Entities.DTOs.DTOLocal)Session["Local"];

                lblNombre.Text = sucursal.Nombre;
                txtHiddenRut.Text = sucursal.Rut_empresa.ToString();



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
                     
                string nombreLocal =lblNombre.Text;
                long rut =long.Parse(txtHiddenRut.Text);
                Entities.DTOs.DTOLocal sucursal = proxy.getLocal(nombreLocal, rut);
                string passOriginal=proxy.encodePass(txtPassActual.Text.Trim());

                if (passOriginal == sucursal.Pass)
                {
                    string pass = proxy.encodePass(txtPassNueva.Text);
                    proxy.modificarPassLocal(rut, nombreLocal, pass);
                   

                    Response.Redirect("/PedidosPorLocal/verPedidos.aspx");

                
                }
                
                else
                {
                    Response.Write("<script language=javascript>alert('La contraseña inicial no es la correcta');</script>");
                }
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

                
                Response.Redirect("/PedidosPorLocal/verPedidos.aspx");

            }


            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }

        }
   
    }
}
