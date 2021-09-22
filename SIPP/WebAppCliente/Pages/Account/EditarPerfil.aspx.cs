using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using Entities.DTOs;
using Entities;
using System.Drawing.Imaging;

namespace WebAppCliente.Pages.Account
{
    public partial class EditarPerfil : WebAppCliente.Pages.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkSesion();

            if (!Page.IsPostBack)
            {
                Usuario usr = (Usuario)Session["Usuario"];
                txtEmail.Text = usr.Email;
                txtNombre.Text = usr.Nombre;
                txtApellido.Text = usr.Apellido;
                txtTelefono.Text = usr.Telefono;
                txtCelular.Text = usr.Celular;
                imgPerfil.ImageUrl = "/UploadedImages/" + usr.Id + "/Perfil.jpg";
                List<Ubicacion> lstUbicaciones = new List<Ubicacion>();

                if (Session["ubi"] != null)
                {
                    lstUbicaciones = (List<Ubicacion>)Session["ubi"];
                }
                else
                {
                    RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();

                    DTOUbicacion[] lstDtoUbicaciones = proxy.getUbicaciones(usr.Id);

                    foreach (DTOUbicacion ubi in lstDtoUbicaciones)
                    {
                        lstUbicaciones.Add(new Ubicacion(ubi));
                    }
                }


                grdDirecciones.DataSource = lstUbicaciones;
                grdDirecciones.DataBind();
                Session["ubi"] = lstUbicaciones;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean fileOK = true;
            long idUsuario = ((Usuario)Session["Usuario"]).Id;

            String virtualPath = "/UploadedImages/" + idUsuario + "/";
            String path = Server.MapPath(virtualPath);

            bool pathExist = System.IO.Directory.Exists(Server.MapPath(virtualPath));

            if (!pathExist)
                System.IO.Directory.CreateDirectory(Server.MapPath(virtualPath));

            if (imgUpload.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(imgUpload + ".jpg").ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

                if (allowedExtensions.Contains(fileExtension))
                {
                    fileOK = true;
                }

                if (fileOK)
                {
                    try
                    {
                        Bitmap b = (Bitmap)Bitmap.FromStream(imgUpload.PostedFile.InputStream);
                        //GUARDAMOS COMO JPG
                        b.Save(path + "Perfil.jpg", ImageFormat.Jpeg);

                        //CREAMOS MARCADOR
                    }
                    catch (Exception ex)
                    {
                        fileOK = false;
                        lblError.Text += "La imagen no puede ser subida <br/>";
                    }
                }
                else
                {
                    fileOK = false;
                    lblError.Text += "Tipo de imágen no permitida<br/>";
                }
            }

            if (fileOK)
            {
                RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
                DTOUsuario dt = new DTOUsuario();
                dt.Id = idUsuario;
                dt.Nombre = txtNombre.Text;
                dt.Apellido = txtApellido.Text;
                dt.Celular = txtCelular.Text;
                dt.Telefono = txtTelefono.Text;
                dt.Email = txtEmail.Text;
                if (txtPassword.Text != "") //Si está vacía no cambiamos la contraseña
                {
                    dt.Pass = Encript.EncodePassword(txtPassword.Text);
                }
                else
                {
                    dt.Pass = ((Usuario)Session["Usuario"]).Pass;
                }

                List<DTOUbicacion> lstDtoUbicaciones = new List<DTOUbicacion>();
                List<Ubicacion> lstUbicaciones = (List<Ubicacion>)Session["ubi"];

                foreach (Ubicacion ubi in lstUbicaciones)
                {
                    lstDtoUbicaciones.Add(ubi.getDT());
                }

                dt.Ubicacion = lstDtoUbicaciones;




                bool saveOk = proxy.guardarUsuario(dt);

                if (saveOk)
                {
                    //lblNombre.CssClass = "okLogin";
                    //lblNombre.Text = "Registrado Id:"+dt.Id;
                    //crear sesion
                    lblAlertDirecciones.Text = "";
                    Response.Write("<script language=javascript>alert('Guardado Correctamente');</script>");

                }
                else
                {
                    //lblNombre.CssClass = "errorLogin";
                    // lblNombre.Text = "Registro incorrecto";
                }
            }
        }


        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            RemoteServiceUsuario.ServiceUsuarioClient proxy = new RemoteServiceUsuario.ServiceUsuarioClient();
            string email = "";
            bool usado = false;
            email = txtEmail.Text;
            // usado = proxy.ComprobarEmail(email);

            /*  if (usado == true)
              {
                  lblComprobarEmail.CssClass = "ErrorReg";
                  lblComprobarEmail.Text = "Email NO Disponible";
              }
              else
              {
                  lblComprobarEmail.CssClass = "okLogin";
                  lblComprobarEmail.Text = "Email Disponible";
              }*/
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            String Script = "var fromBehind = true; $('#divPerfil').css('display', 'none');$('#divDatos').css('display', 'none');$('#divDirecciones').css('display', 'block');";

            if (!txtNombreDireccion.Text.Equals(""))
            {
                if (!txtDireccion.Text.Equals("") && !txtLatitud.Text.Equals("") && !txtLongitud.Text.Equals(""))
                {
                    List<Ubicacion> lstUbicaciones = new List<Ubicacion>();
                    if (Session["ubi"] != null)
                    {
                        lstUbicaciones = (List<Ubicacion>)Session["ubi"];
                    }
                    Ubicacion ubi = new Ubicacion();
                    ubi.Nombre_referencia = txtNombreDireccion.Text;
                    ubi.Direccion = txtDireccion.Text;
                    ubi.Latitud = txtLatitud.Text;
                    ubi.Longitud = txtLongitud.Text;
                    ubi.Id_usuario = ((Usuario)Session["Usuario"]).Id;
                    if (hiddEdit.Value == "Add")
                    {
                        bool ubiExistente = false;
                        foreach (Ubicacion temp in lstUbicaciones)
                        {
                            if (temp.Nombre_referencia == ubi.Nombre_referencia)
                            {
                                ubiExistente = true;
                            }
                        }

                        if (!ubiExistente)
                        {
                            lstUbicaciones.Add(ubi);
                            grdDirecciones.DataSource = lstUbicaciones;
                            grdDirecciones.DataBind();
                            Session["ubi"] = lstUbicaciones;
                            lblDireccionStatus.Text = "";
                            txtLatitud.Text = "";
                            txtLongitud.Text = "";
                            txtNombreDireccion.Text = "";
                            txtDireccion.Text = "";
                            lblAlertDirecciones.Text = "Atención. Estas direcciones no serán guardadas hasta que no presione guardar";
                        }
                        else
                        {
                            Script += "$('#tblMap').slideDown();";
                            Script += "placeMarkerFromDB(new google.maps.LatLng(" + txtLatitud.Text + ", " + txtLongitud.Text + "));";
                            lblDireccionStatus.Text = "Ya existe una dirección con ese nombre";
                        }
                    }
                    else
                    {
                        for (int i = 0; i < lstUbicaciones.Count; i++)
                        {
                            if (lstUbicaciones[i].Nombre_referencia == ubi.Nombre_referencia)
                            {
                                lstUbicaciones[i] = ubi;
                            }
                        }
                        grdDirecciones.DataSource = lstUbicaciones;
                        grdDirecciones.DataBind();
                        Session["ubi"] = lstUbicaciones;
                        lblDireccionStatus.Text = "";
                        txtLatitud.Text = "";
                        txtLongitud.Text = "";
                        txtNombreDireccion.Text = "";
                        txtDireccion.Text = "";
                        txtNombreDireccion.ReadOnly = false;
                        hiddEdit.Value = "Add";
                        lblAlertDirecciones.Text = "Atención. Estas direcciones no serán guardadas hasta que no presione guardar";
                    }
                }
                else
                {
                    Script += "$('#tblMap').slideDown();";
                    lblDireccionStatus.Text = "Debe seleccionar su dirección en el mapa y completar la caja de texto";
                }
            }
            else
            {
                Script += "$('#tblMap').slideDown();";
                Script += "placeMarkerFromDB(new google.maps.LatLng(" + txtLatitud.Text + ", " + txtLongitud.Text + "));";
                lblDireccionStatus.Text = "Debe ingresar un nombre que identifique esta dirección";

            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", Script, true);
        }

        protected void grdDirecciones_rowEdit(int index)
        {
            String Script = "var fromBehind = true; $('#divPerfil').css('display', 'none');$('#divDatos').css('display', 'none');$('#divDirecciones').css('display', 'block');";
            String nombre = grdDirecciones.Rows[index].Cells[0].Text;
            List<Ubicacion> lstUbicaciones = new List<Ubicacion>();

            if (Session["ubi"] != null)
            {
                lstUbicaciones = (List<Ubicacion>)Session["ubi"];
            }

            Ubicacion ubi = new Ubicacion();
            int indice = 0;

            for (int i = 0; i < lstUbicaciones.Count; i++)
            {
                if (lstUbicaciones[i].Nombre_referencia == nombre)
                {
                    indice = i;
                    ubi = lstUbicaciones[i];
                }
            }

            Script += "placeMarkerFromDB(new google.maps.LatLng(" + ubi.Latitud + ", " + ubi.Longitud + "));";
            txtDireccion.Text = ubi.Direccion;
            txtNombreDireccion.Text = ubi.Nombre_referencia;
            txtNombreDireccion.ReadOnly = true;
            txtLatitud.Text = ubi.Latitud;
            txtLongitud.Text = ubi.Longitud;

            hiddEdit.Value = "Edit";
            /*grdDirecciones.DataSource = lstUbicaciones;
            grdDirecciones.DataBind();
            Session["ubi"] = lstUbicaciones;
            lblDireccionStatus.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
            txtNombreDireccion.Text = "";
            txtDireccion.Text = "";*/
            lblAlertDirecciones.Text = "Atención. Estas direcciones no serán guardadas hasta que no presione guardar";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", Script, true);
        }

        protected void grdDirecciones_rowDelete(int index)
        {
            String Script = "var fromBehind = true; $('#divPerfil').css('display', 'none');$('#divDatos').css('display', 'none');$('#divDirecciones').css('display', 'block');$('#tblMap').slideUp();";
            String nombre = grdDirecciones.Rows[index].Cells[0].Text;
            List<Ubicacion> lstUbicaciones = new List<Ubicacion>();
            if (Session["ubi"] != null)
            {
                lstUbicaciones = (List<Ubicacion>)Session["ubi"];
            }

            for (int i = 0; i < lstUbicaciones.Count; i++)
            {
                if (lstUbicaciones[i].Nombre_referencia == nombre)
                {
                    lstUbicaciones.RemoveAt(i);
                }
            }
            grdDirecciones.DataSource = lstUbicaciones;
            grdDirecciones.DataBind();
            Session["ubi"] = lstUbicaciones;
            lblDireccionStatus.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
            txtNombreDireccion.Text = "";
            txtDireccion.Text = "";
            lblAlertDirecciones.Text = "Atención. Estas direcciones no serán guardadas hasta que no presione guardar";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", Script, true);
        }

        protected void grdDirecciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Editar":
                    grdDirecciones_rowEdit(Convert.ToInt32(e.CommandArgument));
                    break;
            }
        }

        protected void grdDirecciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            grdDirecciones_rowDelete(e.RowIndex);
        }
    }
}