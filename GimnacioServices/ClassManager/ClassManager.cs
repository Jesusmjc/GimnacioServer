using GimnacioDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.Entity.Core.Metadata.Edm;

namespace GimnacioServices
{
    public partial class GimnacioService : IClassManager
    {
        public int RegisterClass(Class newClass)
        {
            try
            {
                int result = 0;

                using (var context = new GimnacioEntities())
                {
                    Clases classToBeSaved = new Clases
                    {
                        fecha = newClass.Date,
                        cupoMaximo = newClass.Capacity,
                        comentarios = newClass.Comments,
                        tipo = newClass.Type,
                        IdEntrenador = newClass.TrainerId
                    };

                    context.Clases.Add(classToBeSaved);
                    result = context.SaveChanges();
                }

                return result;
            }
            catch (Exception ex) when (ex is SqlException | ex is DbEntityValidationException | ex is EntityException)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public List<Class> GetClasses()
        {
            List<Class> classes = new List<Class>();

            try
            {
                using (var context = new GimnacioEntities())
                {
                    
                    var dbClasses = context.Clases.Where(e => e.fecha > DateTime.Now).ToList();
                    foreach (var dbClass in dbClasses)
                    {
                        Class clazz = new Class();
                        clazz.ClassId = dbClass.IdClase;
                        clazz.Date = (DateTime)dbClass.fecha;
                        clazz.Capacity = (int)dbClass.cupoMaximo;
                        clazz.Type = dbClass.tipo;
                        clazz.Comments = dbClass.comentarios;
                        clazz.TrainerId = (int)dbClass.IdEntrenador; 

                        classes.Add(clazz); 
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                classes = null;
            }

            return classes;
        }

        public List<Class> GetBookClassesByMember(int IdMember)
        {
            List<Class> bookedClasses = new List<Class>();

            try
            {
                using (var context = new GimnacioEntities())
                {
                    var user = context.Usuarios.Where(e => e.IdUsuario == IdMember).FirstOrDefault();
                    var dbBookedClassesIds = context.MiembrosClases.Where(e => e.IdMiembro == user.IdMiembro).ToList();

                    foreach (var bookedClass in dbBookedClassesIds)
                    {
                        var dbClass = context.Clases.Where(e => e.IdClase == bookedClass.IdClase ).FirstOrDefault();

                        Class dtoClass = new Class();
                        dtoClass.ClassId = dbClass.IdClase;
                        dtoClass.Date = (DateTime)dbClass.fecha;
                        dtoClass.Capacity = (int)dbClass.cupoMaximo;
                        dtoClass.Type = dbClass.tipo;
                        dtoClass.Comments = dbClass.comentarios;
                        dtoClass.TrainerId = (int)dbClass.IdEntrenador; 

                        bookedClasses.Add(dtoClass);
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                bookedClasses = null; 
            }

            return bookedClasses; 
        }

        public int GetTotalAssistantsToClass(int IdClass)
        {
            int result = 0;

            try
            {
                using (var context = new GimnacioEntities())
                {
                    result = context.MiembrosClases.Where(e => e.IdClase == IdClass).Count(); 
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                result = -1; 
            }

            return result; 
        }

        public int BookClass(int classId, int idMember)
        {
            int result = -1;

            try
            {

                using (var context = new GimnacioEntities())
                {

                    var user = context.Usuarios.Where(e => e.IdUsuario == idMember).FirstOrDefault();

                    MiembrosClases bookClass = new MiembrosClases();
                    bookClass.IdMiembro = user.IdMiembro;
                    bookClass.IdClase = classId;

                    context.MiembrosClases.Add(bookClass);

                    result = context.SaveChanges(); 
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result; 
        }
    }

}
