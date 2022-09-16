using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SendingModel
    {
        public string sendername { get; set; }
        public int senderphonenumber { get; set; }
        public string fromaddress { get; set; }
        public string ReceiverName { get; set; }
        public int Receivephonenumber { get; set; }
        public string ToAddress { get; set; }
        
    }
}