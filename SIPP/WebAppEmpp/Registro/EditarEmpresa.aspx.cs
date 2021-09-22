using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebAppEmpp.Registro
{
    public partial class EditarEmpresa : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkSesion();
                Entities.DTOs.DTOEmpresa entreprise = (Entities.DTOs.DTOEmpresa)Session["Empresa"];
                
                //txtRSocial.Text = entreprise.RazonSocial.ToString();
                //txtTelefono.Text = entreprise.Telefono.ToString();
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
                string razon;
                string telefono;

                if (txtRSocial.Text != "")
                {

                     razon = txtRSocial.Text.Trim().ToLower();
                }
                else
                {
                    razon = ((Entities.DTOs.DTOEmpresa)Session["Empresa"]).RazonSocial;
                }
                if (txtTelefono.Text != "")
                {
                    telefono = txtTelefono.Text;
                }
                else
                {
                    telefono = ((Entities.DTOs.DTOEmpresa)Session["Empresa"]).Telefono;
                }
              
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                Entities.DTOs.DTOEmpresa dt = new Entities.DTOs.DTOEmpresa();
                string pass = Session["passEmpresa"].ToString();
                dt.Rut = long.Parse(Session["rutEmpresa"].ToString());
                dt.RazonSocial = razon;//txtRSocial.Text.Trim().ToLower();
                dt.Telefono = telefono;//txtTelefono.Text;
                dt.Pass = pass;
                                 
                proxy.modificarEmpresa(dt, dt.Rut);

                Session["Empresa"] = dt;
                agregarImagen(dt.Rut);
               
                Response.Redirect("PerfilEmpresa.aspx");
                
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
               
                
            }
        }

        protected void agregarImagen(long rut)
        {
            try
            {

                String imgPath = "/Images/Logos/" + rut + "/";
                String imgUrl = Server.MapPath(imgPath);
                bool pathExist = System.IO.Directory.Exists(imgUrl);

                if (!pathExist)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(imgPath));
                }

                if (fuLogo.HasFile)
                {
                    string ext = fuLogo.PostedFile.FileName;
                    ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                    string[] formatos = new string[] { "jpg", "jpeg", "bmp", "png", "gif" };
                    if (Array.IndexOf(formatos, ext) < 0)
                    {
                        Response.Write("<script language=javascript>alert('Formato de imagen no valido');</script>");
                    }
                    else
                    {
                        Bitmap bit = new Bitmap(Bitmap.FromStream(fuLogo.PostedFile.InputStream));
                        bit.Save(imgUrl + "Logo.jpg", ImageFormat.Jpeg);
                    }

                }
  
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");


            }

        }

    }


}