using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebAppEmpp.Local
{
    public partial class verLocalesEmpresa : WebAppEmpp.PageTemplate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.checkSesion();
            //Session["rutEmpresa"] = 1;
                long rutEmpresa = long.Parse( Session["rutEmpresa"].ToString());
                repetidor.rutEmpresa = rutEmpresa;
               
                List<Entities.DTOs.DTOLocal> sucursales = repetidor.getSucursales(rutEmpresa);
                List<datos> sucursalesGRD = new List<datos>();
              
                    foreach (Entities.DTOs.DTOLocal franquicia in sucursales)
                    {
                        datos variable = new datos();
                        variable.nombre = franquicia.Nombre;
                        variable.direccion = franquicia.Direccion;
                        variable.localidad = franquicia.Localidad;
                        variable.telefono = franquicia.Telefono.ToString();
                        variable.area = franquicia.Area.ToString();
                        sucursalesGRD.Add(variable);


                    }
                    
                        grdPizzerias.DataSource = sucursalesGRD;
                        grdPizzerias.DataBind();
                    
            }
            catch (Exception exe)
            {
                Response.Write("<script language=javascript>alert('Error:" + exe.Message + "');</script>");
            }
        }

        protected void grdPizzerias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPizzerias.PageIndex = e.NewPageIndex;
            grdPizzerias.DataBind();
        }

        protected void grdPizzerias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPizzerias.EditIndex = e.NewEditIndex;
            grdPizzerias.DataBind();
        }

        protected void grdPizzerias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow fila = (GridViewRow)grdPizzerias.Rows[e.RowIndex];
                RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
                TableCell celda = fila.Cells[0];
                string nombre = celda.Text;
                long rut = long.Parse(Session["rutEmpresa"].ToString());
                
                proxy.borrarLocal(nombre, rut);
                grdPizzerias.DeleteRow(e.RowIndex);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception exe)
            {
                
            }
        }

        protected void grdPizzerias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPizzerias.EditIndex = -1;
            grdPizzerias.DataBind();
        }

        protected void grdPizzerias_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {


        }

        protected void grdPizzerias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
            Entities.DTOs.DTOLocal sucursal = new Entities.DTOs.DTOLocal();

            long rut = long.Parse(Session["rutEmpresa"].ToString());
            GridView gv = (GridView)sender;

            GridViewRow fila = (GridViewRow)grdPizzerias.Rows[e.RowIndex];
            DataControlFieldCell celda = fila.Cells[0] as DataControlFieldCell;
            string nombre = celda.Text;
            sucursal = proxy.getLocal(nombre, rut);
            string telefono = ((TextBox)fila.Cells[3].Controls[0]).Text;
            sucursal.Telefono = decimal.Parse(telefono);
            string area = ((TextBox)fila.Cells[4].Controls[0]).Text;
            sucursal.Area = decimal.Parse(area);
            proxy.modificarLocal(sucursal);
            grdPizzerias.EditIndex = e.RowIndex;
            grdPizzerias.DataBind();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

     }
    
    internal class datos
    {
        public datos()
        {
        }
        public string nombre {get;set;}
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string localidad { get; set; }
        public string area{get;set;}
    }
    
}
