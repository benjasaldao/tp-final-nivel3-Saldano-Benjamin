using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string imageUrl { get; set; }
        public bool isAdmin { get; set; }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                if(value != "") {
                    _email = value;
                } else
                {
                    throw new Exception("Email vacio");
                }
            }
        }
    }
}
