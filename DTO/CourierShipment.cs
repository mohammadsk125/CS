using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CourierShipment
    {
   
        public  string sendername { get; set; }
        public int senderphonenumber { get; set; }
        public string fromaddress { get; set; }
        public string ReceiverName { get; set; }
        public int Receivephonenumber { get; set; }
        public string ToAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string trackingid { get; set; }
       

    }
}
