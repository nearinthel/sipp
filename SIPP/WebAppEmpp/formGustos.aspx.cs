using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.DTOs;

namespace WebAppEmpp
{
    public partial class formGustos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();

        
            //Listar los gustos en una lista desplegable
            List<Entities.DTOs.DTOEspecificacion> lstDtoEspecificaciones = proxy.getEspecificaciones().ToList();
            foreach (Entities.DTOs.DTOEspecificacion esp in lstDtoEspecificaciones)
            {
                
                DropDownList1.Items.Add(esp.Nombre);
                
         
            }


            //Listamos las los locales pertenecientes a la empresa en un checkboxlist 
            List<Entities.DTOs.DTOLocal> lstDtoLocales = proxy.getLocalesXEmpresa(long.Parse("1")).ToList();

            foreach (Entities.DTOs.DTOLocal loc in lstDtoLocales)
            {
                string nombre = loc.Nombre;
                CheckBoxList1.Items.Add(nombre);
                DropDownList2.Items.Add(nombre);

            }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //capturamos el precio
            int costo = int.Parse(TextBox1.Text);
            //capturamos el gusto
            string gusto = DropDownList1.SelectedValue;

             
            //hacer un foreach del checkboxlist (locales) y para cada local agregar a la tabla (local, gusto, precio)
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();

            foreach (ListItem item in CheckBoxList1.Items){
                    if(item.Selected){
                        string local = item.Text;

                        proxy.agregarGusto(gusto, local, costo);
  
                      }
                  }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //capturamos el precio
            int costo = int.Parse(TextBox1.Text);
            //capturamos el gusto
            string gusto = DropDownList1.SelectedValue;


            //hacer un foreach del checkboxlist (locales) y para cada local actualizar a la tabla (local, gusto, precio)
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();

            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    string local = item.Text;
                    //proxy.modificarGusto(gusto, local, costo);

                }
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //capturamos el gusto
            string gusto = DropDownList1.SelectedValue;


            //hacer un foreach del checkboxlist (locales) y para cada local borrar de la tabla (local, gusto, precio)
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();

            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    string local = item.Text;
                    //proxy.borrarGusto(gusto, local);

                }
            }
            

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            RemoteServiceLocal.IServiceLocal proxy = new RemoteServiceLocal.ServiceLocalClient();
            String local = DropDownList2.SelectedValue;

            List<DTOEspecificacionLocal> lstEsp = proxy.getEspecificacionesLocal(local).ToList();
            List<datos> gustos = new List<datos>();
            foreach (DTOEspecificacionLocal esp in lstEsp)
            {
                datos gusto = new datos();
                gusto.local = local;
                gusto.gusto = esp.Especificacion.Nombre;
                gusto.costo = esp.costo;
                gustos.Add(gusto);

            }

            GridView1.DataSource = gustos.OrderBy(lst => lst.gusto);
            GridView1.DataBind();


        }


        internal class datos
        {
            public datos()
            {
            }
            public string local { get; set; }
            public string gusto { get; set; }
            public decimal costo { get; set; }


        }

    }
}