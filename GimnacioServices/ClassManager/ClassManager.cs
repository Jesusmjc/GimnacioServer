using GimnacioDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.ServiceModel;
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
                Console.WriteLine(ex.InnerException);
                return -1;
            }
        }

        public int ValidateDateIsAvailable(DateTime classDateTime)
        {
            int result = 0;

            try
            {
                using (var context = new GimnacioEntities())
                {
                    var classOnSameDate = context.Clases.Any(c => c.fecha == classDateTime);


                    if (classOnSameDate != null)
                    {
                        result = 1;
                    }
                }

                return result;
            }
            catch (Exception ex) when (ex is SqlException | ex is DbEntityValidationException | ex is EntityException)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.ToString());
                return -1;
            }         
        }
    }
}
