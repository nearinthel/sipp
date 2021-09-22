using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using System.Data.Entity;
using System.Transactions;

namespace RemoteControllers
{
    public class ControladorUsuario
    {

        private static ControladorUsuario instance;

        private ControladorUsuario() { }

        public static ControladorUsuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ControladorUsuario();
                }
                return instance;
            }
        }

        public static List<Usuario> getUsuarios()
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    List<Usuario> lstDir = contexto.Usuario.Select(s => s).ToList();
                    return lstDir;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario loginUsuario(Usuario u)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    String hash = Encript.EncodePassword(u.Pass);

                    Usuario user = contexto.Usuario.FirstOrDefault(usr => usr.Email == u.Email && usr.Pass == hash);
                    if (user != null)
                        return user;
                    else
                        return new Usuario(0, "", "", "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario ObtenerUsuario(long id)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {


                    Usuario user = contexto.Usuario.FirstOrDefault(usr => usr.Id == id);
                    if (user != null)
                        return user;
                    else
                        return new Usuario(0, "", "", "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool guardarUsuario(Usuario u)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    String hash = Encript.EncodePassword(u.Pass);

                    Usuario user = contexto.Usuario.FirstOrDefault(usr => usr.Id == u.Id);

                    user.Nombre = u.Nombre;
                    user.Apellido = u.Apellido;
                    user.Telefono = u.Telefono;
                    user.Celular = u.Celular;
                    user.Email = u.Email;
                    user.Pass = u.Pass;

                    List<Ubicacion> lstUbi = contexto.Ubicacion.Where(ubi => ubi.Id_usuario == u.Id).ToList();
                    if (lstUbi != null)
                    {
                        foreach (Ubicacion ubi in lstUbi)
                        {
                            contexto.Ubicacion.Remove(ubi);
                        }
                    }

                    foreach (Ubicacion ubi in u.Ubicacion)
                    {
                        contexto.Ubicacion.Add(ubi);
                    }

                    int result = contexto.SaveChanges();
                    bool retorno = false;
                    if (result > 0)
                    {
                        retorno = true;
                    }

                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static Usuario registroUsuario(Usuario u)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    String hash = Encript.EncodePassword(u.Pass);

                    Usuario usr = new Usuario();
                    usr.Nombre = u.Nombre;
                    usr.Apellido = u.Apellido;
                    usr.Telefono = u.Telefono;
                    usr.Celular = u.Celular;
                    usr.Email = u.Email;
                    usr.Pass = u.Pass;


                    Usuario usrResult = contexto.Usuario.Add(usr);
                    int result = contexto.SaveChanges();
                    long id = contexto.Usuario.Max(us => us.Id);

                    if (result > 0)
                    {
                        usr.Id = id;

                        return usr;
                    }

                    else
                        return new Usuario(0, "", "", "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public static bool ComprobarEmail(Usuario u)
        {
            try
            {

                using (AlacartaEntities contexto = new AlacartaEntities())
                {
                    Usuario user = contexto.Usuario.FirstOrDefault(usr => usr.Email == u.Email);

                    if (user != null)
                        return false;
                    else
                        return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public static List<Pedido> obtenerPedidosDeUsuario(Usuario u)
        {
            try
            {
                using (AlacartaEntities contexto = new AlacartaEntities())
                {


                    //Usuario usr = new Usuario();
                    List<Pedido> lstPedidos = contexto.Pedido.Where(ped => ped.Id_usuario == u.Id).ToList();





                    if (lstPedidos == null)
                    {


                        return null;
                    }

                    else
                        return lstPedidos;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }







    }
}
