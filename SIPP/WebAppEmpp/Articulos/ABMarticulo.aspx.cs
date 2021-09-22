using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppEmpp.Articulos
{
    public partial class alta1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Listamos los articulos
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();
            List<Entities.DTOs.DTOArticulo> lstDtoArticulos = proxy.getArticulos().ToList();

            foreach (Entities.DTOs.DTOArticulo art in lstDtoArticulos)
            {
                DropDownList1.Items.Add(art.Nombre);
            }

            //long empresa = Session["RutEmpresa"];
            List<Entities.DTOs.DTOLocal> lstDtoLocales = proxy.getLocalesXEmpresa(long.Parse("1")).ToList();

            foreach (Entities.DTOs.DTOLocal loc in lstDtoLocales)
            {
                string nombre = loc.Nombre;
                CheckBoxList1.Items.Add(nombre);
               
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();
            
            //Capturamos el articulo y el costo
            
            Entities.DTOs.DTOArticulo articulo = proxy.getArticulo(DropDownList1.SelectedValue);
            
            decimal costo = decimal.Parse(TextBox1.Text);

            //por cada local seleccionado se agregara el mismo articulo
            string nomlocal = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    nomlocal= CheckBoxList1.Items[i].Value;
                    Entities.DTOs.DTOLocal local = proxy.getLocal(nomlocal, (long)Session["RutEmpresa"]);

                    //bool guardado = proxy.altaArticuloLocal(articulo, local, costo);
                    //if (guardado != true)
                    //{
                    //    Console.WriteLine("Error agregando: " + articulo + " " + nomlocal);
                    //}

                }
            }
           
        }

        //Boton modificar (string articulo, local/s; decimal precio)
        //tomar estos valores y hacer update a las tablas

        protected void Button2_Click(object sender, EventArgs e)
        {
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();

            //Capturamos el articulo y el costo
            string articulo = DropDownList1.SelectedValue;
            decimal costo = decimal.Parse(TextBox1.Text);

            //por cada local seleccionado se modifica el precio
            //habria que revisar si existe el articulo-local que se va a updatear

            string nomlocal = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    nomlocal = CheckBoxList1.Items[i].Value;

                    bool guardado = proxy.modificarArticuloLocal(articulo, nomlocal, costo);
                    
                    if (guardado != true)
                    {
                        Console.WriteLine("Error modificando: " + articulo + " " + nomlocal);
                    }

                }
            }


        }
        //fin boton modificar
      
        //Boton borrar
        //selecciona local/es y articulo y ejecuta Delete en la tabla 
        protected void Button3_Click(object sender, EventArgs e)
        {
            RemoteServiceLocal.ServiceLocalClient proxy = new RemoteServiceLocal.ServiceLocalClient();

            //Capturamos el articulo 
            string articulo = DropDownList1.SelectedValue;
           

            //por cada local seleccionado se borra de la BD
            //habria que revisar si existe el articulo-local que se va a updatear

            string nomlocal = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    nomlocal = CheckBoxList1.Items[i].Value;

                    //bool guardado = proxy.borrarArticulo(articulo, nomlocal);

                    //if (guardado != true)
                    //{
                    //    Console.WriteLine("Error borrando: " + articulo + " " + nomlocal);
                    //}

                }
            }


        }

    }
}