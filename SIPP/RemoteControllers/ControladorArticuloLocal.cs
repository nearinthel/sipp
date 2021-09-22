using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using RemoteControllers.Exceptions;


namespace RemoteControllers
{
    public partial class ControladorArticuloLocal
    {
        private static ControladorArticuloLocal instance;

        private ControladorArticuloLocal(){

        }
        public static ControladorArticuloLocal getInstance(){
            if (instance == null)
            {
                instance = new ControladorArticuloLocal(); 
            }
            return instance;
        }


/********************************************************ABM Fredd********************************************************/    
/*A*/   public bool altaArticuloLocal(Articulo articulo, Local local, decimal costo)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                ArticuloLocal relacion = new ArticuloLocal();

                relacion.id = handler.ArticuloLocal.Max(s => s.id);
                relacion.idArticulo = articulo.Nombre;
                relacion.idLocal = local.Nombre;
                relacion.Costo_base = costo;
                relacion.Articulo = articulo;
                relacion.Local = local;

                handler.ArticuloLocal.Add(relacion);
                
                bool salvado;

                int resultado = handler.SaveChanges();
                if (resultado <= 0)
                {
                    throw new NoSalvadoException();

                }
                else
                {
                    salvado = true;
                }
                return salvado;


            }
        }
/*B*/   public bool bajaArticulolocal(string articulo, string local)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

                ArticuloLocal relacion = new ArticuloLocal();

                relacion = (ArticuloLocal)handler.ArticuloLocal.Where(s => s.idLocal == local && s.idArticulo == articulo);

                handler.ArticuloLocal.Remove(relacion);
                
                bool salvado;

                int resultado = handler.SaveChanges();
                if (resultado <= 0)
                {
                    throw new NoSalvadoException();

                }
                else
                {
                    salvado = true;
                }
                return salvado;


            }
        }        
 
        
        
/*M*/  public bool modificarArticulolocal(string articulo, string local, decimal nuevocosto)
        {
            using (AlacartaEntities handler = new AlacartaEntities())
            {

               var relacion = new ArticuloLocal();

               relacion = (ArticuloLocal)handler.ArticuloLocal.Where(s => s.idArticulo == articulo && s.idLocal == local);
                relacion.Costo_base =nuevocosto;
                
                //handler.ArticuloLocal.UPDATE?(relacion);
               
                bool salvado;

                int resultado = handler.SaveChanges();
                if (resultado <= 0)
                {
                    throw new NoSalvadoException();

                }
                else
                {
                    salvado = true;
                }
                return salvado;


            }
        }

/*****************************************************GET Fredd*****************************************************/

    //todos los articulos de un local
    public List<ArticuloLocal> getArticulosLocal(string nombreLocal)
    {
        try
        {
            using (AlacartaEntities contexto = new AlacartaEntities())
            {

                //obtener todos los articulos de un local
                List<ArticuloLocal> listaArticulosLocal = contexto.ArticuloLocal.Where(i => i.idLocal == nombreLocal).ToList();

                //obtener objeto local
                Local loc = contexto.Local.FirstOrDefault(i => i.Nombre == nombreLocal);

                //para cada articulo-local agregar el objeto Articuo y Local
                foreach (ArticuloLocal AL in listaArticulosLocal)
                {
                    Articulo item = contexto.Articulo.FirstOrDefault(i => i.Nombre == AL.idArticulo);
                    AL.Articulo = item;
                    AL.Local = loc;

                }

                return listaArticulosLocal;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

//Leo Pombo
    public ArticuloLocal getArticuloByLocal(string nombreArticulo, string nombreLocal)
    {
        using (AlacartaEntities contexto = new AlacartaEntities())
        {
            ArticuloLocal item = contexto.ArticuloLocal.FirstOrDefault(i => i.idArticulo == nombreArticulo && i.idLocal == nombreLocal);
            contexto.Entry(item).Reference(i => i.Articulo).Load();
            contexto.Entry(item).Reference(i => i.Local).Load();

            if (item == null)
            {
                throw new ObjetoNoExisteException(String.Format("el articulo con nombre \"{0}\" no se pudo encontrar en \"{1}\"", nombreArticulo, nombreLocal));
            }
            return item;
        }
    }
//*******//

  

    }
}
