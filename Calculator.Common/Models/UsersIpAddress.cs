using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Common.Models
{
    public class UsersIpAddress
    {
        public int Id { get; set; }
        public string IpAdress { get; set; } =string.Empty;
        public DateTime AddDate { get; set; }
    }
}
