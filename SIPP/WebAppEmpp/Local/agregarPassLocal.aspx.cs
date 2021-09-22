using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Local
{
    public partial class agregarPassLocal : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkSesion();
               
              
                    RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                     
                    long rut=long.Parse(Session["rutEmpresa"].ToString());
                    string nombreLocal=Request.QueryString["Local"];
                    Entities.DTOs.DTOLocal sucursal = proxy.getLocal(nombreLocal, rut);
                    lblNombre.Text = nombreLocal;
                    txtHiddenRut.Text = rut.ToString();

           
                
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
                string pass=proxy.encodePass(txtPass.Text);
                proxy.modificarPassLocal(rut, nombreLocal, pass);
               
                Response.Redirect("verLocalesEmpresa.aspx");
               
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

    }
}