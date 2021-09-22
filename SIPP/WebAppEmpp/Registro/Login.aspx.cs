using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }
        protected void cvEmpresa_ServerValidate(object source, ServerValidateEventArgs args)
        {
           
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();


                bool existe = proxy.comprobarRazonLogin(args.Value.ToString().Trim().ToLower());
                args.IsValid = false;
                if (existe != false)
                {
                    args.IsValid = true;
                }
        

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {

                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                Entities.DTOs.DTOEmpresa enterprise = new Entities.DTOs.DTOEmpresa();
                string nombreEmpresa = txtEmpresa.Text;
                string passEmpresa = proxy.encodePass(txtPass.Text.Trim());
                enterprise = proxy.loginEmpresa(nombreEmpresa.Trim().ToLower(), passEmpresa);
                if (enterprise != null)
                {
                    Session["Empresa"] = enterprise;
                    Session["rutEmpresa"] = enterprise.Rut;
                    Session["passEmpresa"] = passEmpresa;
                    Response.Redirect("PerfilEmpresa.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Empresa incorrecta o pass incorrecto');</script>");
                }
            
            }
     
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Empresa incorrecta o pass incorrecto');</script>");

            }


        }


    }
}