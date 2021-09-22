using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Registro
{
    public partial class CambiarPass : WebAppEmpp.PageTemplate
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

                    Entities.DTOs.DTOEmpresa entrepriseSession = (Entities.DTOs.DTOEmpresa)Session["Empresa"];

                    if (proxy.encodePass(txtPassActual.Text) == entrepriseSession.Pass)
                    {
                        entrepriseSession.Pass = proxy.encodePass(txtPassNueva.Text);
                        Session["Empresa"] = entrepriseSession;
                        Session["passEmpresa"] = entrepriseSession.Pass;
                        proxy.modificarEmpresa(entrepriseSession, entrepriseSession.Rut);
                        Response.Redirect("PerfilEmpresa.aspx");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('La Contraseña no puede cambiarse porque la contraseña original no es la correcta');</script>");
                    }
                }
            
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }


        }

    }
}