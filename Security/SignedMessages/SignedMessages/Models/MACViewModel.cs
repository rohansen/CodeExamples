using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignedMessages.Models
{
    public class MACViewModel
    {
        public string MAC { get; set; }
        public string PublicKey { get; set; }
        public string Message { get; set; }
    }
}