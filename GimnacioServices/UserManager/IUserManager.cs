using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace GimnacioServices
{
    [ServiceContract]
    internal interface IUserManager
    {
        [OperationContract]
        User GetUser(string email, string password);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId;

        [DataMember]
        public string Type;

        [DataMember]
        public string Name;

        [DataMember]
        public string MiddleName;

        [DataMember]
        public string LastName;

        [DataMember]
        public string Curp;

        [DataMember]
        public string Email;

        [DataMember]
        public string Password;

        [DataMember]
        public int MemberId;
    }
}
