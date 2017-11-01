using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Exceptions
{
    //WCF Exceptions are marked with DataContract and DataMembers
    //You cannot enherit from Exception as usual, as it is not serializable by WCFS datacontractserializer
    [DataContract]
    public class BookingExistsException
    {
        [DataMember]
        public string Message { get; set; }
        public BookingExistsException(string message)
        {
            Message = message;
        }

    }
}
