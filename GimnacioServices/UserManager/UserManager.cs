using GimnacioDataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnacioServices
{
    public partial class GimnacioService : IUserManager
    {
        public User GetUser(string email, string password)
        {
            User user = new User();

            try
            {
                using (var context = new GimnacioEntities())
                {
                    var userFromDB = context.Usuarios.Where(usuario => usuario.contrasena == password
                                                            && usuario.correoElectronico == email).FirstOrDefault();

                    if (userFromDB != null)
                    {
                        user.UserId = userFromDB.IdUsuario;
                        user.Type = userFromDB.tipo;
                        user.Name = userFromDB.nombre;
                        user.MiddleName = userFromDB.apellidoPaterno;
                        user.LastName = userFromDB.apellidoMaterno;
                        user.Email = userFromDB.correoElectronico;
                    }
                }
            }
            catch (Exception ex) when (ex is SqlException | ex is DbEntityValidationException | ex is EntityException)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.ToString());
                user = null;
            }

            return user;
        }
    }
}
