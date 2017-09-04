using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactRepository.DomainModel
{
    public class Contact
    {
        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string HomeNumber { get; set; }
        public byte[] Photo { get; set; }
        
        public string Base64Photo { get { return Photo!=null?Convert.ToBase64String(Photo):""; } }
        public bool HasPhoto { get { return Photo != null; } }
    }
}
