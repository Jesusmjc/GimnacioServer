using GimnacioDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GimnacioServices
{
    [ServiceContract]
    internal interface IClassManager
    {
        [OperationContract]
        int RegisterClass(Class newClass);

        [OperationContract]
        List<Class> GetClasses();

        [OperationContract]
        List<Class> GetBookClassesByMember(int IdMember);

        [OperationContract]
        int GetTotalAssistantsToClass(int IdClass);

        [OperationContract]
        int BookClass(int classId, int idMember); 
    }

    [DataContract]
    public class Class
    {
        [DataMember]
        public int ClassId;

        [DataMember]
        public DateTime Date;

        [DataMember]
        public int Capacity;

        [DataMember]
        public string Comments;

        [DataMember]
        public string Type;

        [DataMember]
        public int TrainerId;
    }
}
