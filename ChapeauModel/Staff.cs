using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Staff
    {
        public int Staff_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int phoneNumber { get; set; }
        public string emailAdress { get; set; }
        public string salt { get; set; }
        public string passWord { get; set; }
    }
}
