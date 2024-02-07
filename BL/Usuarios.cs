using System.Diagnostics;

namespace BL
{
    public class Usuarios
    {
        public static ML.Result GetByEmail(string Email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ProyectoDeMensajeriaAlexisAguileraMejiaContext context = new DL.ProyectoDeMensajeriaAlexisAguileraMejiaContext())
                {
                    var query = (from aliasUsuarios in context.Usuarios
                                 where aliasUsuarios.Email == Email
                                 select new
                                 {
                                     UsuariosID = aliasUsuarios.UsuariosId,
                                     Nombre = aliasUsuarios.Nombre,
                                     ApellidoPaterno = aliasUsuarios.ApellidoPaterno,
                                     ApellidoMaterno = aliasUsuarios.ApellidoMaterno,
                                     Edad = aliasUsuarios.Edad,
                                     Email = aliasUsuarios.Email,
                                     Password = aliasUsuarios.Password
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuarios usuarios = new ML.Usuarios();
                        usuarios.Email = query.Email;
                        usuarios.Password = query.Password;

                        result.Object = usuarios;
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros en la base de datos";
                    }
                }
            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ProyectoDeMensajeriaAlexisAguileraMejiaContext context = new DL.ProyectoDeMensajeriaAlexisAguileraMejiaContext())
                {
                    var query = (from aliasUsuarios in context.Usuarios
                                 select new
                                 {
                                     UsuariosID = aliasUsuarios.UsuariosId,
                                     Nombre = aliasUsuarios.Nombre,
                                     ApellidoPaterno = aliasUsuarios.ApellidoPaterno,
                                     ApellidoMaterno = aliasUsuarios.ApellidoMaterno,
                                     Edad = aliasUsuarios.Edad,
                                     Email = aliasUsuarios.Email,
                                     Password = aliasUsuarios.Password,
                                     Imagen = aliasUsuarios.Imagen
                                 }).ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.Usuarios usuarios = new ML.Usuarios();
                            usuarios.UsuariosID = registro.UsuariosID;
                            usuarios.Nombre = registro.Nombre;
                            usuarios.ApellidoPaterno = registro.ApellidoPaterno;
                            usuarios.ApellidoMaterno = registro.ApellidoMaterno;
                            usuarios.Edad = registro.Edad;
                            usuarios.Email = registro.Email;
                            usuarios.Password = registro.Password;
                            usuarios.Imagen = registro.Imagen;
                            result.Objects.Add(usuarios);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int UsuariosID)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ProyectoDeMensajeriaAlexisAguileraMejiaContext context = new DL.ProyectoDeMensajeriaAlexisAguileraMejiaContext())
                {
                    var query = (from aliasUsuarios in context.Usuarios
                                 where aliasUsuarios.UsuariosId == UsuariosID
                                 select new
                                 {
                                     UsuariosID = aliasUsuarios.UsuariosId,
                                     Nombre = aliasUsuarios.Nombre,
                                     ApellidoPaterno = aliasUsuarios.ApellidoPaterno,
                                     ApellidoMaterno = aliasUsuarios.ApellidoMaterno,
                                     Edad = aliasUsuarios.Edad,
                                     Email = aliasUsuarios.Email,
                                     Password = aliasUsuarios.Password,
                                     Imagen = aliasUsuarios.Imagen
                                 }).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuarios usuarios = new ML.Usuarios();
                        usuarios.UsuariosID = query.UsuariosID;
                        usuarios.Nombre = query.Nombre;
                        usuarios.ApellidoPaterno = query.ApellidoPaterno;
                        usuarios.ApellidoMaterno = query.ApellidoMaterno;
                        usuarios.Edad = query.Edad;
                        usuarios.Email = query.Email;
                        usuarios.Password = query.Password;
                        usuarios.Imagen = query.Imagen;
                        result.Object = usuarios;
                        result.Correct = true;
                    }
                    else
                    {
                        result.ErrorMessage = "No se encontraron registros";
                        result.Correct = false;
                    }
                }
            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}