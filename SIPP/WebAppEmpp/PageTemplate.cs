using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEmpp
{
    public partial class PageTemplate : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
         
        //}

        protected void checkSesion()
        {
            if (Session["Empresa"] != null || Session["Local"] != null)
            {

                //Response.Redirect("/Default.aspx");
            }
            else
            {
                //if (Session["Local"] != null)
                //{
                //    //Response.Redirect("/Default.aspx");
                //}
                //else
                //{
                    Response.Redirect("/Default.aspx");
                //}
            }
        }

    }
}