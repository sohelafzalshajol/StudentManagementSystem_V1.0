using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EUserReg
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public int ReligionId { get; set; }
        public DateTime EntryDate { get; set; }
        public string UserImage { get; set; }
    }
}
